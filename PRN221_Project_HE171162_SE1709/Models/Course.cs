using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class Course
    {
        public Course()
        {
            TeachingSessions = new HashSet<TeachingSession>();
        }

        public int CourseId { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<TeachingSession> TeachingSessions { get; set; }
    }
}
