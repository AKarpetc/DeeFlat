using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class GroupStatus : BaseAudit
    {
        public GroupStatuses Id { get; set; }

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
