﻿using System;

namespace Tourismandtravel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
