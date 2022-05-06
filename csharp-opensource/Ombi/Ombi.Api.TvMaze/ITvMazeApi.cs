﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ombi.Api.TvMaze.Models;

namespace Ombi.Api.TvMaze
{
    public interface ITvMazeApi
    {
        Task<IEnumerable<TvMazeEpisodes>> EpisodeLookup(int showId);
        Task<List<TvMazeSeasons>> GetSeasons(int id);
        Task<List<TvMazeSearch>> Search(string searchTerm);
        Task<TvMazeShow> ShowLookup(int showId);
        Task<TvMazeShow> ShowLookupByTheTvDbId(int theTvDbId);
    }
}