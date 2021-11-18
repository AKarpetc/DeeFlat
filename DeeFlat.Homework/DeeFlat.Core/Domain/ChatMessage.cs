using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Homework.Core.Domain
{
    public class ChatMessage : BaseEntity
    {
        public Guid FromUserId { get; set; }
        public Guid ToChatId { get; set; }
        public string Content { get; set; }
    }
}
