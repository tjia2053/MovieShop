using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("MovieCrew")]
	public class MovieCrew
	{
        public int MovieId { get; set; }
        public int CrewId { get; set; }

        [MaxLength(128)]
        [Required]
        public string Department { get; set; }

        [MaxLength(128)]
        [Required]
        public string Job { get; set; }

        public Movie Movie { get; set; }
        public Crew Crew { get; set; }
    }
}

