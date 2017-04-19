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
    public class SubjectOfferingRepository:ItblSubjectOfferingRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public SubjectOfferingRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<tblSubjectOffering> GetSubjectOfferings()
        {
            return context.tblSubjectOffering.Where(tc => tc.SchoolID.Equals(SchoolID)).ToList();
        }

        public tblSubjectOffering GetSubjectOfferingByID(int tblSubjectOfferingId)
        {
            return context.tblSubjectOffering.Find(tblSubjectOfferingId);
        }

        public void InsertSubjectOffering(tblSubjectOffering subjectoffering)
        {
            context.tblSubjectOffering.Add(subjectoffering);
        }

        public void DeleteSubjectOffering(int tblSubjectOfferingid)
        {
            tblSubjectOffering tblSubjectOffering = context.tblSubjectOffering.Find(tblSubjectOfferingid);
            context.tblSubjectOffering.Remove(tblSubjectOffering);
        }

        public void UpdateSubjectOffering(tblSubjectOffering tblSubjectOffering)
        {
            context.Entry(tblSubjectOffering).State = System.Data.Entity.EntityState.Modified;
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