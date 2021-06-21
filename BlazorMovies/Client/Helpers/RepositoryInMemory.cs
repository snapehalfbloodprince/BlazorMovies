using BlazorMovies.Shared.Entities;
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
                new Movie {Title = "Spiderman",
                    ReleaseDate = new DateTime(2019,7,2),
                    Poster = "https://cinema.everyeye.it/public/immagini/28082019/spider-man-far-from-home_notizia-2.jpg"
                },
                new Movie {Title = "Moana",
                    ReleaseDate = new DateTime(2016,11,23),
                    Poster="https://images.moviesanywhere.com/5b2c656f643292cfd35771668badc820/44dda68f-dfb2-4974-97aa-239f27e6951f.jpg"
                },
                new Movie {Title = "Inception", 
                    ReleaseDate = new DateTime(2010,7,16),
                    Poster="https://c8.alamy.com/compit/ryhbxj/poster-del-filmato-inizio-2010-ryhbxj.jpg"
                },
            };
        }
    }
}
