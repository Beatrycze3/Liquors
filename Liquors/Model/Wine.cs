﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Liquors.Model.WineModel;

namespace Liquors.Model
{
    public class Wine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Winery { get; set; }

        [ForeignKey("Id")]
        public Alcohol Alcohol { get; set; }
    }
   
}

