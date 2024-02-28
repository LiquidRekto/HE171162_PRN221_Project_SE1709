using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class TeachingSession
    {
        public int TeachingSessionId { get; set; }
        public int? Room { get; set; }
        public int? TimeSlot { get; set; }
        public int? Class { get; set; }
        public int? Course { get; set; }
        public int? Instructor { get; set; }

        public virtual Class? ClassNavigation { get; set; }
        public virtual Course? CourseNavigation { get; set; }
        public virtual Instructor? InstructorNavigation { get; set; }
        public virtual Room? RoomNavigation { get; set; }
        public virtual TimeSlot? TimeSlotNavigation { get; set; }
    }
}
