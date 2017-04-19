using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DataEntities.Models;
using Data.Repository;
using System.Web;

namespace TimeTable.Data.Repository
{
    public class RoomRepository:IRoomRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public RoomRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID= context.tblUsers.Where(u=>u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;
            this.context = context;
        }

        public IEnumerable<Room> GetRooms()
        {
            return context.Room.Where(room=>room.SchoolID==SchoolID).ToList()  ;
        }

        public Room GetRoomByID(int roomId)
        {
            return context.Room.Find(roomId);
        }

        public void InsertRoom(Room room)
        {
            context.Room.Add(room);
        }

        public void DeleteRoom(int roomId)
        {
            Room room = context.Room.Find(roomId);
            context.Room.Remove(room);
        }

        public void UpdateRoom(Room room)
        {
            context.Entry(room).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}