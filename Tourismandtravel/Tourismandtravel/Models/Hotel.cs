using System.ComponentModel.DataAnnotations;
using Tourismandtravel.Models;

namespace Tourismandtravel.Models
{
    public class Hotel

    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Hoteltype { get; set; }
        public string? HotelLocation { get; set; }
        public ICollection<Room>? Rooms { get; set; }

    }
}
