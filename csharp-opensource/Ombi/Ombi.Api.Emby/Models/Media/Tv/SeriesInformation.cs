﻿using System;
using Ombi.Api.Emby.Models.Movie;

namespace Ombi.Api.Emby.Models.Media.Tv
{
    public class SeriesInformation
    {

        public string Name { get; set; }
        public string ServerId { get; set; }
        public string Id { get; set; }
        public string Etag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastMediaAdded { get; set; }
        public bool CanDelete { get; set; }
        public bool CanDownload { get; set; }
        public bool SupportsSync { get; set; }
        public string SortName { get; set; }
        public DateTime PremiereDate { get; set; }
        public EmbyExternalurl[] ExternalUrls { get; set; }
        public string Path { get; set; }
        public string OfficialRating { get; set; }
        public string Overview { get; set; }
        public string ShortOverview { get; set; }
        public object[] Taglines { get; set; }
        public string[] Genres { get; set; }
        public float CommunityRating { get; set; }
        public int VoteCount { get; set; }
        public long CumulativeRunTimeTicks { get; set; }
        public long RunTimeTicks { get; set; }
        public string PlayAccess { get; set; }
        public int ProductionYear { get; set; }
        public EmbyRemotetrailer[] RemoteTrailers { get; set; }
        public EmbyProviderids ProviderIds { get; set; }
        public bool IsFolder { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
        public EmbyPerson[] People { get; set; }
        public EmbyStudio[] Studios { get; set; }
        public int LocalTrailerCount { get; set; }
        public EmbyUserdata UserData { get; set; }
        public int RecursiveItemCount { get; set; }
        public int ChildCount { get; set; }
        public string DisplayPreferencesId { get; set; }
        public string Status { get; set; }
        public string AirTime { get; set; }
        public string[] AirDays { get; set; }
        public object[] Tags { get; set; }
        public object[] Keywords { get; set; }
        public EmbyImagetags ImageTags { get; set; }
        public string[] BackdropImageTags { get; set; }
        public object[] ScreenshotImageTags { get; set; }
        public string LocationType { get; set; }
        public string HomePageUrl { get; set; }
        public object[] LockedFields { get; set; }
        public bool LockData { get; set; }

    }
}