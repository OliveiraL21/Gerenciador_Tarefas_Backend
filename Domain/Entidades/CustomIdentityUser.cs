﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public CustomIdentityUser() : base()
        {
            AccessFailedCount = 0;
        }

        public string? ProfileImageUrl { get; set; }

    }
}