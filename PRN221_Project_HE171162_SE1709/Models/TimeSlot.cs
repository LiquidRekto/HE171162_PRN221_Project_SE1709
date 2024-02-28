using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            TeachingSessions = new HashSet<TeachingSession>();
        }

        public int TimeSlotId { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<TeachingSession> TeachingSessions { get; set; }
    }
}
