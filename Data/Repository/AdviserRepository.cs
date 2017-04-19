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
  
    public class AdviserRepository:IAdviserRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public AdviserRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<tblAdviser> GetAdvisers()
        {
            return context.tblAdvisers.Where(a => a.SchoolID.Equals(SchoolID)).ToList();
        }

        public tblAdviser GetAdviserByID(int Adviserid)
        {
            return context.tblAdvisers.Find(Adviserid);
        }

        public void InsertAdviser(tblAdviser Adviser)
        {
            context.tblAdvisers.Add(Adviser);
        }

        public void DeleteAdviser(int AdviserId)
        {
            tblAdviser Adviser = context.tblAdvisers.Find(AdviserId);
            context.tblAdvisers.Remove(Adviser);
        }
      
        public void UpdateAdviser(tblAdviser Adviser)
        {
            context.Entry(Adviser).State = System.Data.Entity.EntityState.Modified;
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