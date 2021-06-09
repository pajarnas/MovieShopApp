using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.APIModels
{
    public class User
    {
        public int id { get; set; }
        public List<string> purchase { get; set; }
        public List<string> favourite { get; set; }
        public List<string> unfavourite { get; set; }
        public List<string> review { get; set; }
        public int movieId { get; set; }
    }
}
