﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UTB.Restaurace.Domain.Entities
{
    public class Meal : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageSrc { get; set; }
    }
}
