using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models;
using ApplicationCore.Entities;
namespace ApplicationCore.Models.Response
{
    public class MovieDetailResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
      
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public decimal? Rating { get; set; }
  
        public List<CastResponseModel> Casts { get; set; }
        
        public class CastResponseModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string TmdbUrl { get; set; }
            public string ProfilePath { get; set; }
            public string Character { get; set; }
        }
        public List<GenreResponseModel> Genres { get; set; }
        public class GenreResponseModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

        
        }
    }
}
