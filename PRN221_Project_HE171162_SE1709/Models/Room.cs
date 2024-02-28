using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class Room
    {
        public Room()
        {
            TeachingSessions = new HashSet<TeachingSession>();
        }

        public int RoomId { get; set; }
        public int? Building { get; set; }
        public string? Number { get; set; }

        public virtual Building? BuildingNavigation { get; set; }
        public virtual ICollection<TeachingSession> TeachingSessions { get; set; }
    }
}
