using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class CourseActivityType : BaseAudit
    {
        public CourseActivityTypes Id { get; set; }

        public string Name { get; set; }

    }

    public enum CourseActivityTypes : short
    {
        /// <summary>
        /// Лекция
        /// </summary>
        Lection,

        /// <summary>
        /// Практика
        /// </summary>
        Practice,

        /// <summary>
        /// Домашнее задание
        /// </summary>
        HomeTask
    }
}
