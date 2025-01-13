using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using UTB.Restaurace.Domain.Validations;

namespace UTB.Restaurace.Domain.Entities
{
    [Table(nameof(Meal))]
    public class Meal : Entity<int>
    {
        [Required]
        [StringLength(70)]
        [FirstLetterCapitalizedCZ]
        public string? Name { get; set; }

        [FirstLetterCapitalizedCZ]
        public string? Description { get; set; }

        [PriceValidation]
        public double Price { get; set; }

        public string? ImageSrc { get; set; }

        [NotMapped]
        [FileContent("image")]
        public IFormFile? Image { get; set; }

        public string? Category { get; set; }

        public bool Available { get; set; }
    }
}
