using System;
using System.Collections.Generic;

namespace FindRooMate.Entities;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DormitoryId { get; set; }

    public int Capacity { get; set; }

    public virtual Dormitory Dormitory { get; set; } = null!;

    public virtual ICollection<RoomStudent> RoomStudents { get; } = new List<RoomStudent>();
}
