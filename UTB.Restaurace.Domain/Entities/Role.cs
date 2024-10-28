using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Restaurace.Domain.Entities
{
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
