using ecommaranceWithLayeredArchDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities
{
    public class VariantSKU:Entity
    {
        public Guid Variant_ID { get; set; }

        [ForeignKey("Variant_ID")]
        public virtual Variant Variant { get; set; }
        public Guid SKU_ID { get; set; }

        [ForeignKey("SKU_ID")]
        public virtual SKU SKU { get; set; }
    }
}
