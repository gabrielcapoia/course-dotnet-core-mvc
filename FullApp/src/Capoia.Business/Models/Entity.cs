using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
