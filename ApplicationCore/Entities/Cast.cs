using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Cast")]
    public class Cast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string ProfilePath { get; set; }

        public string Character { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
