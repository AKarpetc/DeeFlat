using System;

namespace DeeFlat.Core.DTO
{
    public class BaseDTO<TKey>
    {
        public TKey Id { get; set; }
    }

    public class BaseDTO : BaseDTO<Guid>
    {
    }  
}
