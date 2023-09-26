using ecommaranceWithLayeredArchDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities
{
    public class User:Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
