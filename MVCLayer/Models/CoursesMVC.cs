using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLayer.Models
{
    public class CoursesMVC
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int Credits { get; set; }
    }
}