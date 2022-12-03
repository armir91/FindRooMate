using System;
using System.Collections.Generic;

namespace FindRooMate.Entities;

public partial class Dormitory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int MaxCapacity { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
