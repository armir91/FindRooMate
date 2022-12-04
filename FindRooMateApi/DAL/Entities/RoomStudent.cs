using System;
using System.Collections.Generic;

namespace FindRooMateApi.DAL.Entities
{
    public partial class RoomStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
