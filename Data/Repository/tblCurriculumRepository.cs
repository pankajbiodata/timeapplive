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
    public class tblCurriculumRepository: ItblCurriculumRepository, IDisposable
    {
        private DataEntities.Models.TimeTable context;
        private string SchoolID;
        public tblCurriculumRepository(DataEntities.Models.TimeTable context)
        {
            SchoolID = context.tblUsers.Where(u => u.Email.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault().SchoolID;

            this.context = context;
        }

        public IEnumerable<tblCurriculum> GettblCurriculums()
        {
            return context.tblCurriculum.Where(tc=>tc.SchoolID.Equals(SchoolID)).ToList();
        }

        public tblCurriculum GettblCurriculumByID(int tblCurriculumId)
        {
            return context.tblCurriculum.Find(tblCurriculumId);
        }

        public void InserttblCurriculum(tblCurriculum tblCurriculum)
        {
            context.tblCurriculum.Add(tblCurriculum);
        }

        public void DeletetblCurriculum(int tblCurriculumid)
        {
            tblCurriculum tblCurriculum = context.tblCurriculum.Find(tblCurriculumid);
            context.tblCurriculum.Remove(tblCurriculum);
        }

        public void UpdatetblCurriculum(tblCurriculum tblCurriculum)
        {
            context.Entry(tblCurriculum).State = System.Data.Entity.EntityState.Modified;
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