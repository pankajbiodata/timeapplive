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
    public class UserRepository:IUserRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public UserRepository(DataEntities.Models.TimeTable context1)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context1;
        }

        public IEnumerable<tblUsers> GetUsers()
        {
            return context.tblUsers.Where(u => u.SchoolID == SchoolID).ToList();
        }

        public tblUsers GetUserByID(int userId)
        {
            return context.tblUsers.Find(userId);
        }

        public void InsertUser(tblUsers user)
        {
            context.tblUsers.Add(user);
        }

        public void DeleteUser(int userId)
        {
            tblUsers user = context.tblUsers.Find(userId);
            context.tblUsers.Remove(user);
        }

        public void UpdateUser(tblUsers user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
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