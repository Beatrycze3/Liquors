using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liquors.Model
{
    public class AlcoholVintage
    {
        public int Id { get; set; }

        public int AlcoholId { get; set; }
        public int VintageId { get; set; }

        public Alcohol Alcohol { get; set; }
        public Vintage Vintage { get; set; }
    }
}
