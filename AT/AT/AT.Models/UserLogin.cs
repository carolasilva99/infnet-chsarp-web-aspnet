﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AT.Models
{
    public class UserLogin
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
