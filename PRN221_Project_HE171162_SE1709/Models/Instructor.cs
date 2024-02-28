using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            TeachingSessions = new HashSet<TeachingSession>();
        }

        public int InstructorId { get; set; }
        public string Alias { get; set; } = null!;

        public virtual ICollection<TeachingSession> TeachingSessions { get; set; }
    }
}
