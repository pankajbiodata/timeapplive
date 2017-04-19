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
    public class FacultyRepository:IFacultyRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public FacultyRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<Faculty> GetFaculty()
        {
            return context.Faculty.Where(f => f.SchoolID.Equals(SchoolID)).ToList();
        }

        public Faculty GetFacultyByID(int Facultyid)
        {
            return context.Faculty.Find(Facultyid);
        }

        public void InsertFaculty(Faculty Faculty)
        {
            context.Faculty.Add(Faculty);
        }

        public void DeleteFaculty(int FacultyId)
        {
            Faculty Faculty = context.Faculty.Find(FacultyId);
            context.Faculty.Remove(Faculty);
        }

        public void UpdateFaculty(Faculty Faculty)
        {
            context.Entry(Faculty).State = System.Data.Entity.EntityState.Modified;
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