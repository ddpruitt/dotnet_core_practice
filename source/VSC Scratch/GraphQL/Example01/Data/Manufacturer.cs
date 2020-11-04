using System;
using System.ComponentModel.DataAnnotations;

namespace Example01.Data
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}