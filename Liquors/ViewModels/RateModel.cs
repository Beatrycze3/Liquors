using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Liquors.ViewModels
{
    public class RateModel
    {
        public int AlcoholId { get; set; }
        public string Name { get; set; }

        [Required]
        [Range(1990,2017)]
        public int Year { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }
    }
}
