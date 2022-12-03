using System;
using System.Collections.Generic;

namespace FindRooMate.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual ICollection<RoomStudent> RoomStudents { get; } = new List<RoomStudent>();
}
