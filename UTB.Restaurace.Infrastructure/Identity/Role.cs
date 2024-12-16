﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Restaurace.Infrastructure.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role(string role) : base(role)
        {
        }
        public Role() : base()
        {
        }
    }
}
