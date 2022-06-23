using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Trailer")]
	public class Trailer
	{
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }

        [MaxLength(2084)]
        public string? TrailerUrl { get; set; }

        [MaxLength(2084)]
        public string? Name { get; set; }

        public Movie Movie { get; set; }
    }
}

