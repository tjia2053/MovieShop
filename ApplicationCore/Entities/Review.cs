using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Review")]
    public class Review
	{
        public int MovieId { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        [Required]
        public decimal Rating { get; set; }

        [MaxLength(4096)]
        public string? ReviewText { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}

