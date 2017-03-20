using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        [MinLength(2)]
        public string ReviewerName { get; set; }

        [Required]
        [MinLength(2)]
        public string RestaurantName { get; set; }

        [Required]
        [MinLength(10)]
        public string ReviewContent { get; set; }

        [Required]
        // This calls our custom validation attribute
        [InThePast]
        public DateTime DateVisited { get; set; }

        [Required]
        [RangeAttribute(1,5)]
        public int Stars { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Helpful { get; set; }
        public int Unhelpful { get; set; }
    }
}