﻿namespace MoodMapperAPI.Domain.Options;

public class Journal : IUserObject
{
    public Ulid Id { get; set; }
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Entry> Entries { get; set; }
}