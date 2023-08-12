﻿using System;

namespace Tourismandtravel.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
