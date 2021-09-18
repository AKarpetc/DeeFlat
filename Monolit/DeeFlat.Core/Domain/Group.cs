using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public GroupStatuses GroupStatusId { get; set; }
       
        public virtual GroupStatus GroupStatus { get; set; }


    }
}
