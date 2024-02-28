using System;
using System.Collections.Generic;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class Building
    {
        public Building()
        {
            Rooms = new HashSet<Room>();
        }

        public int BuildingId { get; set; }
        public string? Alias { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
