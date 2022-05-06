using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Persistence;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Dlna;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.MediaInfo;
using MediaBrowser.Model.Serialization;

namespace MediaBrowser.Providers.MediaInfo
{
    class FFProbeAudioInfo
    {
        private readonly IMediaEncoder _mediaEncoder;
        private readonly IItemRepository _itemRepo;
        private readonly IApplicationPaths _appPaths;
        private readonly IJsonSerializer _json;
        private readonly ILibraryManager _libraryManager;
        private readonly IMediaSourceManager _mediaSourceManager;

        private readonly CultureInfo _usCulture = new CultureInfo("en-US");

        public FFProbeAudioInfo(IMediaSourceManager mediaSourceManager, IMediaEncoder mediaEncoder, IItemRepository itemRepo, IApplicationPaths appPaths, IJsonSerializer json, ILibraryManager libraryManager)
        {
            _mediaEncoder = mediaEncoder;
            _itemRepo = itemRepo;
            _appPaths = appPaths;
            _json = json;
            _libraryManager = libraryManager;
            _mediaSourceManager = mediaSourceManager;
        }

        public async Task<ItemUpdateType> Probe<T>(T item, MetadataRefreshOptions options,
            CancellationToken cancellationToken)
            where T : Audio
        {
            var path = item.Path;
            var protocol = item.PathProtocol ?? MediaProtocol.File;

            if (!item.IsShortcut || options.EnableRemoteContentProbe)
            {
                if (item.IsShortcut)
                {
                    path = item.ShortcutPath;
                    protocol = _mediaSourceManager.GetPathProtocol(path);
                }

                var result = await _mediaEncoder.GetMediaInfo(new MediaInfoRequest
                {
                    MediaType = DlnaProfileType.Audio,
                    MediaSource = new MediaSourceInfo
                    {
                        Path = path,
                        Protocol = protocol
                    }

                }, cancellationToken).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested();

                Fetch(item, cancellationToken, result);
            }

            return ItemUpdateType.MetadataImport;
        }

        /// <summary>
        /// Fetches the specified audio.
        /// </summary>
        /// <param name="audio">The audio.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="mediaInfo">The media information.</param>
        /// <returns>Task.</returns>
        protected void Fetch(Audio audio, CancellationToken cancellationToken, Model.MediaInfo.MediaInfo mediaInfo)
        {
            var mediaStreams = mediaInfo.MediaStreams;

            audio.Container = mediaInfo.Container;
            audio.TotalBitrate = mediaInfo.Bitrate;

            audio.RunTimeTicks = mediaInfo.RunTimeTicks;
            audio.Size = mediaInfo.Size;

            //var extension = (Path.GetExtension(audio.Path) ?? string.Empty).TrimStart('.');
            //audio.Container = extension;

            FetchDataFromTags(audio, mediaInfo);

            _itemRepo.SaveMediaStreams(audio.Id, mediaStreams, cancellationToken);
        }

        /// <summary>
        /// Fetches data from the tags dictionary
        /// </summary>
        /// <param name="audio">The audio.</param>
        /// <param name="data">The data.</param>
        private void FetchDataFromTags(Audio audio, Model.MediaInfo.MediaInfo data)
        {
            // Only set Name if title was found in the dictionary
            if (!string.IsNullOrEmpty(data.Name))
            {
                audio.Name = data.Name;
            }

            if (audio.SupportsPeople && !audio.LockedFields.Contains(MetadataFields.Cast))
            {
                var people = new List<PersonInfo>();

                foreach (var person in data.People)
                {
                    PeopleHelper.AddPerson(people, new PersonInfo
                    {
                        Name = person.Name,
                        Type = person.Type,
                        Role = person.Role
                    });
                }

                _libraryManager.UpdatePeople(audio, people);
            }

            audio.Album = data.Album;
            audio.Artists = data.Artists;
            audio.AlbumArtists = data.AlbumArtists;
            audio.IndexNumber = data.IndexNumber;
            audio.ParentIndexNumber = data.ParentIndexNumber;
            audio.ProductionYear = data.ProductionYear;
            audio.PremiereDate = data.PremiereDate;

            // If we don't have a ProductionYear try and get it from PremiereDate
            if (audio.PremiereDate.HasValue && !audio.ProductionYear.HasValue)
            {
                audio.ProductionYear = audio.PremiereDate.Value.ToLocalTime().Year;
            }

            if (!audio.LockedFields.Contains(MetadataFields.Genres))
            {
                audio.Genres = Array.Empty<string>();

                foreach (var genre in data.Genres)
                {
                    audio.AddGenre(genre);
                }
            }

            if (!audio.LockedFields.Contains(MetadataFields.Studios))
            {
                audio.SetStudios(data.Studios);
            }

            audio.SetProviderId(MetadataProviders.MusicBrainzAlbumArtist, data.GetProviderId(MetadataProviders.MusicBrainzAlbumArtist));
            audio.SetProviderId(MetadataProviders.MusicBrainzArtist, data.GetProviderId(MetadataProviders.MusicBrainzArtist));
            audio.SetProviderId(MetadataProviders.MusicBrainzAlbum, data.GetProviderId(MetadataProviders.MusicBrainzAlbum));
            audio.SetProviderId(MetadataProviders.MusicBrainzReleaseGroup, data.GetProviderId(MetadataProviders.MusicBrainzReleaseGroup));
            audio.SetProviderId(MetadataProviders.MusicBrainzTrack, data.GetProviderId(MetadataProviders.MusicBrainzTrack));
        }
    }
}
