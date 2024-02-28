using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class Class
    {
        public Class()
        {
            TeachingSessions = new HashSet<TeachingSession>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TeachingSession> TeachingSessions { get; set; }
    }
}
