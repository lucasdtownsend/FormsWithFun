using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithForms.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2019)]
        public int Year { get; set; }
    }
}
