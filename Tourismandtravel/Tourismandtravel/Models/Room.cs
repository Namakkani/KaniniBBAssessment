using System.ComponentModel.DataAnnotations;
using Tourismandtravel.Models;

namespace Tourismandtravel.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string? Room_Number { get; set; }
        public string? Room_Type { get; set; }
        public string? Availability { get; set; }
        public Hotel? Hotel { get; set; }

        internal static bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
