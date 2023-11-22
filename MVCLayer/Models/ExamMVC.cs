using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLayer.Models
{
    public class ExamMVC
    {
        public int ExamID { get; set; }
        public int CourseID { get; set; }
        public DateTime DateTime { get; set; }
        public int MaxCourse { get; set; }

    }
}