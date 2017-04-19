#region Using Namespaces
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.UnitOfWork;
using DataEntities.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion
namespace timewebserverapp.Controllers
{
    [System.Web.Http.Authorize]
    public class SubjectController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var SubjectList = from Subject in unitOfWork.SubjectRepository.Get() select Subject;
            var Subjects = new List<DataEntities.Models.tblSubject>();
            if (SubjectList.Any())
            {
                foreach (var subject in SubjectList)
                {
                    Subjects.Add(new DataEntities.Models.tblSubject() { SubjectCode = subject.SubjectCode, DescriptiveTitle = subject.DescriptiveTitle, YearLevel = subject.YearLevel, Units = subject.Units, HrsWk = subject.HrsWk, CurriculumID = subject.CurriculumID, SchoolID = subject.SchoolID });
                }
            }
            return Request.CreateResponse<List<tblSubject>>(HttpStatusCode.OK, Subjects);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var subjectDetails = unitOfWork.SubjectRepository.GetByID(id);
            var subject = new DataEntities.Models.tblSubject();
            if (subjectDetails != null)
            {
                subject.SubjectCode = subjectDetails.SubjectCode;
                subject.CurriculumID = subjectDetails.CurriculumID;
                subject.DescriptiveTitle = subjectDetails.DescriptiveTitle;
                subject.HrsWk = subjectDetails.HrsWk;
                subject.SchoolID = subjectDetails.SchoolID;
                subject.Units = subjectDetails.Units;
                subject.YearLevel = subjectDetails.YearLevel;
            }
            return Request.CreateResponse<tblSubject>(HttpStatusCode.OK, subject);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var subjectDetails = unitOfWork.SubjectRepository.GetByID(id);
            var subject = new DataEntities.Models.tblSubject();
            if (subjectDetails != null)
            {
                subject.SubjectCode = subjectDetails.SubjectCode;
                subject.CurriculumID = subjectDetails.CurriculumID;
                subject.DescriptiveTitle = subjectDetails.DescriptiveTitle;
                subject.HrsWk = subjectDetails.HrsWk;
                subject.SchoolID = subjectDetails.SchoolID;
                subject.Units = subjectDetails.Units;
                subject.YearLevel = subjectDetails.YearLevel;
            }
            return Request.CreateResponse<tblSubject>(HttpStatusCode.OK, subject);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblSubject subjectDetails)
        {
            try
            {
                var subject = unitOfWork.SubjectRepository.GetByID(id);
                subject.SubjectCode = subjectDetails.SubjectCode;
                subject.CurriculumID = subjectDetails.CurriculumID;
                subject.DescriptiveTitle = subjectDetails.DescriptiveTitle;
                subject.HrsWk = subjectDetails.HrsWk;
                subject.SchoolID = subjectDetails.SchoolID;
                subject.Units = subjectDetails.Units;
                subject.YearLevel = subjectDetails.YearLevel;
                unitOfWork.SubjectRepository.Update(subject);
                unitOfWork.Save();
                return Request.CreateResponse<tblSubject>(HttpStatusCode.OK, subject);
            }
            catch
            {
                return Request.CreateResponse<tblSubject>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Subject = unitOfWork.SubjectRepository.GetByID(id);

                if (Subject != null)
                {
                    unitOfWork.SubjectRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblSubject>(HttpStatusCode.OK, Subject);
            }
            catch
            {
                return Request.CreateResponse<tblSubject>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
