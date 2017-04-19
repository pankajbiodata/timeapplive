using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DataEntities.Models;
using Data.Repository;

namespace TimeTable.Data.Repository
{
    public class SchoolRepository: ItblSchoolRepository, IDisposable
    {
        private DataEntities.Models.TimeTable context;

        public SchoolRepository(DataEntities.Models.TimeTable context)
        {
            this.context = context;
        }

        public IEnumerable<tblSchools> GetSchools()
        {
            return context.tblSchools.ToList();
        }

        public tblSchools GetSchoolByID(int schoolId)
        {
            return context.tblSchools.Find(schoolId);
        }

        public void InsertSchool(tblSchools school)
        {
            context.tblSchools.Add(school);
        }

        public void DeleteSchool(int tblSchoolsid)
        {
            tblSchools tblSchools = context.tblSchools.Find(tblSchoolsid);
            context.tblSchools.Remove(tblSchools);
        }

        public void UpdateSchool(tblSchools tblSchools)
        {
            context.Entry(tblSchools).State = System.Data.Entity.EntityState.Modified;
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