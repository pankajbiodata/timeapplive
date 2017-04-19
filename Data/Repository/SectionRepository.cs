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
    public class SectionRepository:ISectionRepository,IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public SectionRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<Section> GetSections()
        {
            return context.Section.Where(s => s.SchoolID.Equals(SchoolID)).ToList();
        }

        public Section GetSectionByID(int sectionId)
        {
            return context.Section.Find(sectionId);
        }

        public void InsertSection(Section section)
        {
            context.Section.Add(section);
        }

        public void DeleteSection(int sectionId)
        {
           Section section = context.Section.Find(sectionId);
            context.Section.Remove(section);
        }

        public void UpdateSection(Section section)
        {
            context.Entry(section).State = System.Data.Entity.EntityState.Modified;
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