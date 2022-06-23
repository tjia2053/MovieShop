using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("MovieCast")]
	public class MovieCast
	{
        public int MovieId { get; set; }
        public int CastId { get; set; }

        [MaxLength(450)]
        [Required]
        public string Character { get; set; }

        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
    }
}

