using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Favorite")]
	public class Favorite
	{
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

