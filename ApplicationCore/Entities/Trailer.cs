using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
 
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        public int MovieId { get; set; }

        //Define A foreign key, references Table Movie Id, Key name is MovieId
        public Movie Movie { get; set; }
    }
}
