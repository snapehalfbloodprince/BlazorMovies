﻿using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Title = "Spiderman", ReleaseDate = new DateTime(2019,7,2)},
                new Movie {Title = "Moana", ReleaseDate = new DateTime(2016,11,23)},
                new Movie {Title = "Inception", ReleaseDate = new DateTime(2010,7,16)},
            };
        }
    }
}
