 
using Tourismandtravel.Models;

namespace Tourismandtravel.Repository
{
    public interface IHotelrepository
    {
        public IEnumerable<Hotel> GetHotels();
        public Hotel GetHotelbyid(int HotelId);
        public Hotel postHotel(Hotel hot);
        public Hotel PutHotel(int HotelId, Hotel Hotel);
        public void deleteHotel(int id);




    }
}
