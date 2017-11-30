using System;
using System.Collections.Generic;

namespace Liquors.Model
{
    public class Vintage
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public ICollection<AlcoholVintage> AlcoholVintage { get; set; }
    }
}
