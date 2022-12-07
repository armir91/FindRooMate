using System;
using System.Collections.Generic;

namespace FindRooMateApi.DAL.Entities
{
    public partial class Room
    {
        public Room()
        {
            RoomStudents = new HashSet<RoomStudent>();
            Announcements = new HashSet<Announcement>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DormitoryId { get; set; }
        public int Capacity { get; set; }

        public virtual Dormitory Dormitory { get; set; } = null!;
        public virtual ICollection<RoomStudent> RoomStudents { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
