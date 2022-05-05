﻿using System;
using System.Globalization;
using AutoMapper;
using Ombi.Api.TvMaze.Models;
using Ombi.Core.Models.Requests;
using Ombi.Core.Models.Search;
using Ombi.Helpers;
using TraktApiSharp.Objects.Get.Shows;
using TraktApiSharp.Objects.Get.Shows.Common;
using Ombi.Store.Repository.Requests;

//using TraktApiSharp.Objects.Get.Shows;
//using TraktApiSharp.Objects.Get.Shows.Common;

namespace Ombi.Mapping.Profiles
{
    public class TvProfile : Profile
    {
        public TvProfile()
        {
            CreateMap<TvMazeSearch, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.show.externals.thetvdb))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.show.premiered))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.show.externals.imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.show.network.name))
                .ForMember(dest => dest.NetworkId, opts => opts.MapFrom(src => src.show.network.id.ToString()))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.show.summary.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.score.ToString(CultureInfo.CurrentUICulture)))
                .ForMember(dest => dest.Runtime, opts => opts.MapFrom(src => src.show.runtime.ToString()))
                .ForMember(dest => dest.SeriesId, opts => opts.MapFrom(src => src.show.id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.show.name))
                .ForMember(dest => dest.Banner, opts => opts.MapFrom(src => !string.IsNullOrEmpty(src.show.image.medium) ? src.show.image.medium.ToHttpsUrl() : string.Empty))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.show.status));

            CreateMap<TvMazeShow, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.externals.thetvdb))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.premiered))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.externals.imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.network.name))
                .ForMember(dest => dest.NetworkId, opts => opts.MapFrom(src => src.network.id.ToString()))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.summary.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.rating.ToString()))
                .ForMember(dest => dest.Runtime,
                    opts => opts.MapFrom(src => src.runtime.ToString(CultureInfo.CurrentUICulture)))
                .ForMember(dest => dest.SeriesId, opts => opts.MapFrom(src => src.id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.name))
                .ForMember(dest => dest.Banner,
                    opts => opts.MapFrom(src => !string.IsNullOrEmpty(src.image.medium)
                        ? src.image.medium.ToHttpsUrl()
                        : string.Empty))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.status));



            //CreateMap<TvMazeCustomSeason, SeasonRequests>()
            //    .ConstructUsing(x =>
            //    {
            //        var season = new SeasonRequests
            //        {
            //            SeasonNumber = x.SeasonNumber
            //        };
            //        foreach (var ep in x.EpisodeNumber)
            //        {
            //            season.Episodes.Add(new EpisodeRequests
            //            {
            //                EpisodeNumber = ep,   
            //            });
            //        }
            //        return season;
            //    });



            CreateMap<TraktShow, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => Convert.ToInt32(src.Ids.Tvdb.ToString())))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.FirstAired.HasValue ? src.FirstAired.Value.ToString("yyyy-MM-ddTHH:mm:ss") : string.Empty))
                .ForMember(dest => dest.Banner, opts => opts.MapFrom(src => src.Images.Banner.Full))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.Ids.Imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.Network))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.Overview.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating.ToString()))
                .ForMember(dest => dest.Runtime, opts => opts.MapFrom(src => src.Runtime.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status.DisplayName))
                .ForMember(dest => dest.Trailer, opts => opts.MapFrom(src => src.Trailer))
                .ForMember(dest => dest.Homepage, opts => opts.MapFrom(src => src.Homepage));

            CreateMap<TraktTrendingShow, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => Convert.ToInt32(src.Show.Ids.Tvdb.ToString())))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.Show.FirstAired.HasValue ? src.Show.FirstAired.Value.ToString("yyyy-MM-ddTHH:mm:ss") : string.Empty))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.Show.Ids.Imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.Show.Network))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.Show.Overview.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Show.Rating.ToString()))
                .ForMember(dest => dest.Runtime, opts => opts.MapFrom(src => src.Show.Runtime.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Show.Title))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Show.Status.DisplayName))
                .ForMember(dest => dest.Trailer, opts => opts.MapFrom(src => src.Show.Trailer))
                .ForMember(dest => dest.Homepage, opts => opts.MapFrom(src => src.Show.Homepage));

            CreateMap<TraktMostAnticipatedShow, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => Convert.ToInt32(src.Show.Ids.Tvdb.ToString())))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.Show.FirstAired.HasValue ? src.Show.FirstAired.Value.ToString("yyyy-MM-ddTHH:mm:ss") : string.Empty))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.Show.Ids.Imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.Show.Network))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.Show.Overview.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Show.Rating.ToString()))
                .ForMember(dest => dest.Runtime, opts => opts.MapFrom(src => src.Show.Runtime.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Show.Title))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Show.Status.DisplayName))
                .ForMember(dest => dest.Trailer, opts => opts.MapFrom(src => src.Show.Trailer))
                .ForMember(dest => dest.Homepage, opts => opts.MapFrom(src => src.Show.Homepage));

            CreateMap<TraktMostWatchedShow, SearchTvShowViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => Convert.ToInt32(src.Show.Ids.Tvdb.ToString())))
                .ForMember(dest => dest.FirstAired, opts => opts.MapFrom(src => src.Show.FirstAired.HasValue ? src.Show.FirstAired.Value.ToString("yyyy-MM-ddTHH:mm:ss") : string.Empty))
                .ForMember(dest => dest.ImdbId, opts => opts.MapFrom(src => src.Show.Ids.Imdb))
                .ForMember(dest => dest.Network, opts => opts.MapFrom(src => src.Show.Network))
                .ForMember(dest => dest.Overview, opts => opts.MapFrom(src => src.Show.Overview.RemoveHtml()))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Show.Rating.ToString()))
                .ForMember(dest => dest.Runtime, opts => opts.MapFrom(src => src.Show.Runtime.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Show.Title))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Show.Status.DisplayName))
                .ForMember(dest => dest.Trailer, opts => opts.MapFrom(src => src.Show.Trailer))
                .ForMember(dest => dest.Homepage, opts => opts.MapFrom(src => src.Show.Homepage));
        }
    }
}