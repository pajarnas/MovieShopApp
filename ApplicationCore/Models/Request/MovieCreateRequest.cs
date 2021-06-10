using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.Request
{
    public class MovieCreateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public double Revenue { get; set; }
        public double Budget { get; set; }
        public string IMDBUrl { get; set; }
        public string TMDBUrl { get; set; }
        public string PostUrl { get; set; }
        public string BackDropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public double Price { get; set; }
        

    }   
}
