using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class CourseActivity:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
