 
using Microsoft.EntityFrameworkCore;
using Tourismandtravel.Data;
using Tourismandtravel.Models;


namespace Tourismandtravel.Repository
{
    public class Roomrepository : IRoomrepository
    {
        private readonly TourismdbContext con;
        private Room room;

        public Hotel RoomName { get; private set; }

        public Roomrepository(TourismdbContext con)
        {
            this.con = con;
        }
        public IEnumerable<Room> GetRoom()
        {
            return con.Rooms.ToList();
        }




        public Room GetRoomById(int RoomId)
        {
            return con.Rooms.FirstOrDefault(x => x.RoomId == RoomId);
        }

        public Room PostRoom(Room room)
        {
            con.Rooms.Add(room);
            con.SaveChanges();
            return room;
        }

        public Room PutRoom(int RoomId, Room room)
        {
            con.Rooms.Add(room);
            con.SaveChanges();
            return room;
        }


        public Room DeleteRoom(int RoomId)
        {
            Room roo = con.Rooms.FirstOrDefault(x => x.RoomId == RoomId);
            con.Rooms.Remove(roo);
            con.SaveChanges();
        }
        public async Task<int> countbyid()
        {
            if (con.Rooms == null)
            {
                return 0;
            }

            return await con.Rooms.CountAsync();
        }



    }
}

