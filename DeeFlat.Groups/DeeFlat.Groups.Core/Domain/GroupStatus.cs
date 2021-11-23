using DeeFlat.Abstractions.Abstractions;

namespace DeeFlat.Groups.Core.Domain
{
    public class GroupStatus : BaseEntity
    {
        public new GroupStatuses Id { get; set; }

        public string Name { get; set; }
    }

    public enum GroupStatuses
    {
        /// <summary>
        /// Набор студентов
        /// </summary>
        Complectation,

        /// <summary>
        /// Набор студентов завершен
        /// </summary>
        Complectated,

        /// <summary>
        /// В процессе
        /// </summary>
        Teaching,

        /// <summary>
        /// Завершено
        /// </summary>
        Closed
    }
}
