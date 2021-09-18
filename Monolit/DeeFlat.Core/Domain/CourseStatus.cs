using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class CourseStatus : BaseAudit
    {
        public CourseStatuses Id { get; set; }
        
        public string Name { get; set; }
    }

    public enum CourseStatuses
    {
        /// <summary>
        /// Новый
        /// </summary>
        New,

        /// <summary>
        /// В разработке
        /// </summary>
        InWork,

        /// <summary>
        /// Опубликован
        /// </summary>
        Published,

        /// <summary>
        /// Закрыт
        /// </summary>
        Closed
    }
}
