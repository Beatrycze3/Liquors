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
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        [Required]
        [StringLength(100)]
        public string Region { get; set; }
        [Required]
        [StringLength(100)]
        public string Winery { get; set; }

        public double Rating { get; set; }
    }
}
