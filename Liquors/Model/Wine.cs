using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquors.Model
{
    public class Wine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Winery { get; set; }

        [ForeignKey("Id")]
        public Alcohol Alcohol { get; set; }

    }
}