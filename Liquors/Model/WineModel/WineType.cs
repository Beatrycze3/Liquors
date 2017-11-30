using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liquors.Model.WineModel
{
    public class WineType
    {
        public int Id { get; set; }
        public Type Type { get; set; }
    }

    public enum Type
    {
        Red,
        White,
        Rose,
        Sparkling,
        Dessert,
        Port
    }


}
