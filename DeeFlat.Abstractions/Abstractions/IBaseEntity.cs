using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Abstractions.Abstractions
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
