using System;
using System.Collections.Generic;

namespace FindRooMate.Entities;

public partial class Announcement
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Application> Applications { get; } = new List<Application>();
}
