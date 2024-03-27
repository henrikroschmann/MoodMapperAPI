﻿using MoodMapperAPI.Domain.Enums;

namespace MoodMapperAPI.Domain.Models;

public class Entry
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CreationInfo Creation { get; set; }
    public MoodLevel Mood { get; set; }
    public int JournalId { get; set; }
    public Journal Journal { get; set; }
}