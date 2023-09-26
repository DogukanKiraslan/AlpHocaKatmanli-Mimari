using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommaranceWithLayeredArchDomain.Entities.Base
{
    public class Entity
    {
        public Entity()
        {
            //ID = Guid.NewGuid();
        }
       
        public Guid ID { get; set; }
    }
}
