using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Liquors.Model;

namespace Liquors.ViewModels
{
    public class WineModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Winery { get; set; }

        public double Rating { get; set; }
    }
}
