using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.DataAccess.DBSettings
{
    public class DeeFlatCourseDBSettings : IDeeFlatCourseDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDeeFlatCourseDBSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
