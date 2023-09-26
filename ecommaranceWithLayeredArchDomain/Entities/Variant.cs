using ecommaranceWithLayeredArchDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities
{
    public class Variant:Entity
    {
        public Guid Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
        public string value { get; set; }
        public virtual ICollection<VariantSKU> VariantSKUs { get; set; }
    }
}
