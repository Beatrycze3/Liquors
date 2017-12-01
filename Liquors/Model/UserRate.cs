using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Liquors.Model
{
    public class UserRate
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

        public int AlcoholVintageId { get; set; }
        public AlcoholVintage AlcoholVintage { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }
    }
}
