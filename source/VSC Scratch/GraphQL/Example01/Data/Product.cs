using System;
using System.ComponentModel.DataAnnotations;

namespace Example01.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public Manufacturer PrimaryManufacturer { get; set; }
    }
}