using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.Core.Domain
{
    public class BaseMDB : BaseEntity
    {
        public override Guid Id { get; set; }
    }
}
