using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class File : BaseEntity
    {
        public byte[] Attachment { get; set; }

        public string MimeType { get; set; }

        public Guid FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        public string Name { get; set; }

    }
}
