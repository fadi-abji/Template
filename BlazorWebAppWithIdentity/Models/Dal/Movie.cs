﻿using BlazorWebAppWithIdentity.Criterias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAppWithIdentity.Models.Dal
{
    public class Movie : IObject
    {
        public int Id { get; set; }

        public Guid Uid { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        public DateOnly ReleaseDate { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$")]
        public string? Genre { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^(G|PG|PG-13|R|NC-17)$")]
        public string? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedAt { get; set; }
        public int ChangedBy { get; set; }
    }
}