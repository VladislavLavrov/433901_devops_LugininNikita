using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class Calculation
    {
        public int Id { get; set; }

        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Operation { get; set; } = string.Empty;

        public double Result { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}