﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Liquors.ViewModels
{
    public class LogInModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}
