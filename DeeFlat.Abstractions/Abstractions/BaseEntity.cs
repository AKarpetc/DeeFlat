using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Abstractions.Abstractions
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime Created { get; set; }
    }
}
