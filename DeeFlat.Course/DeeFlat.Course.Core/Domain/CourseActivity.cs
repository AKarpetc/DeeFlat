using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Course.Core.Domain
{
    public class CourseActivity : BaseMDB
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
