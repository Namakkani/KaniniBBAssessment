 
using Tourismandtravel.Data;
using Tourismandtravel.Models;
using Tourismandtravel.Repository;

namespace Tourismandtravel.Repository
{
    public class Hotelrepository : IHotelrepository
    {
        private readonly TourismdbContext con;
        public Hotelrepository(TourismdbContext con)
        {
            this.con = con;
        }
        public IEnumerable<Hotel> GetHotels()
        {
            return con.Hotels.ToList();
        }
        public Hotel GetHotelbyid(int HotelId)
        {
            return con.Hotels.FirstOrDefault(x => x.HotelId == HotelId);
        }
        public Hotel postHotel(Hotel hot)
        {
            con.Hotels.Add(hot);
            con.SaveChanges();
            return hot;
        }

        public void deleteHotel(int id)
        {
            Hotel ht = con.Hotels.FirstOrDefault(x => x.HotelId == id);
            con.Hotels.Remove(ht);
            con.SaveChanges();
        }

        public Hotel PutHotel(int HotelId, Hotel Hotel)
        {
            con.Hotels.Add(Hotel);
            con.SaveChanges();
            return Hotel;
        }
    }
}
