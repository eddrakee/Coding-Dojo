using System;
using System.ComponentModel.DataAnnotations;

namespace quoting.Models
{
    public class Quote
    {
        // Data validation for Author Name
        [Required]
        [MinLengthAttribute(3)]
        public string author { get; set; }

        // Data validation for Quote content
        [Required]
        [MinLengthAttribute(5)]
        public string content {get; set; }

        // DateTime
        public DateTime created_at { get; set; }

        public Quote(){
            created_at = DateTime.Now;
        }

    }
}