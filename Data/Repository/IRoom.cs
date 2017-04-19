using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface IRoomRepository:IDisposable
    {
        IEnumerable<Room> GetRooms();
        Room GetRoomByID(int Roomid);
        void InsertRoom(Room Room);
        void DeleteRoom(int Roomid);
        void UpdateRoom(Room Room);
        void Save();
    }
}
