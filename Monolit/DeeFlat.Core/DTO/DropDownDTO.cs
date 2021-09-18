using System;

namespace DeeFlat.Core.DTO
{
    public class DropDownDTO : BaseDTO
    {
        public string Name { get; set; }
    }

    public class DropDownDTO<TKey> : BaseDTO<TKey>
    {
        public string Name { get; set; }
    }

    public class EnumDropDownDTO : BaseDTO<int>
    {
        public string Name { get; set; }
    }
}
