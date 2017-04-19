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
    public class SchoolYearRepository:ItblSchoolYearRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public SchoolYearRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<tblSchoolYear> GetSchoolYears()
        {
            return context.tblSchoolYear.Where(sy => sy.SchoolID == SchoolID).ToList();
        }

        public tblSchoolYear GetSchoolYearByID(int schoolyearId)
        {
            return context.tblSchoolYear.Find(schoolyearId);
        }

        public void InsertSchoolYear(tblSchoolYear schoolyearId)
        {
            context.tblSchoolYear.Add(schoolyearId);
        }

        public void DeleteSchoolYear(int tblSchoolYearid)
        {
            tblSchoolYear schoolyear = context.tblSchoolYear.Find(tblSchoolYearid);
            context.tblSchoolYear.Remove(schoolyear);
        }

        public void UpdateSchoolYear(tblSchoolYear schoolyear)
        {
            context.Entry(schoolyear).State = System.Data.Entity.EntityState.Modified;
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