using ecommaranceWithLayeredArchDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities
{
    public class SKU:Entity
    {
        public SKU() { 
            IsActive = true;
            IsDeleted = false;
        }
        public string Name { get; set; }
        public Guid Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<VariantSKU> VariantSKUs { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
