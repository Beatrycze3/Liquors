using System;
using System.ComponentModel.DataAnnotations;

namespace Liquors.Model
{
    public class Alcohol
    {
        public int Id { get; set; }

        public Wine Wine { get; set; }
    }
}
