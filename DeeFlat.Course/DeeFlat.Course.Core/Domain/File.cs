using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Course.Core.Domain
{
    public class File : BaseMDB
    {
        public byte[] Attachment { get; set; }

        public string MimeType { get; set; }

        public Guid FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        public string Name { get; set; }

    }
}
