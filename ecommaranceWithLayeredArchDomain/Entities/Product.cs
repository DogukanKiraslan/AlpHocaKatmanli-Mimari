using ecommaranceWithLayeredArchDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities
{
    public class Product:Entity
    {
        public Product() 
        {
            IsActive = true;
            IsDeleted = false;
        }
        public string Name { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<SKU> SKUs { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
