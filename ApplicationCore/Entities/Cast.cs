﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Cast")]
    public class Cast
	{
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string? Name { get; set; }

        [MaxLength(4096)]
        public string? Gender { get; set; }

        [MaxLength(4096)]
        public string? TmdbUrl { get; set; }

        [MaxLength(2048)]
        public string? ProfilePath { get; set; }

        public ICollection<MovieCast> MoviesOfCast { get; set; }
    }
}

