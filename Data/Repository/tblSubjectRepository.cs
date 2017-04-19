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
    public class tblSubjectRepository : ItblSubjectRepository, IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public tblSubjectRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<tblSubject> GetSubjects()
        {
            return context.tblSubject.Where(s => s.SchoolID == SchoolID).ToList();
        }

        public tblSubject GetSubjectByID(int tblSubjectId)
        {
            return context.tblSubject.Find(tblSubjectId);
        }

        public void InsertSubject(tblSubject tblSubject)
        {
            context.tblSubject.Add(tblSubject);
        }

        public void DeleteSubject(int tblSubjectId)
        {
            tblSubject tblSubject = context.tblSubject.Find(tblSubjectId);
            context.tblSubject.Remove(tblSubject);
        }

        public void UpdateSubject(tblSubject tblSubject)
        {
            context.Entry(tblSubject).State = System.Data.Entity.EntityState.Modified;
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