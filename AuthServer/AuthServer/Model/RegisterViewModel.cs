﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Model
{
    public class RegisterViewModel
    {   
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}