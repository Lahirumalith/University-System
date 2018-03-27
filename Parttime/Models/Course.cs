﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parttime.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}