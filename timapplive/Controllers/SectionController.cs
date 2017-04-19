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
    public class SectionController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var sectionList = from section in unitOfWork.SectionRepository.Get() select section;
            var sections = new List<DataEntities.Models.Section>();
            if (sectionList.Any())
            {
                foreach (var section in sectionList)
                {
                    sections.Add(new DataEntities.Models.Section() { SectionID = section.SectionID, YearLvl = section.YearLvl, SchoolID = section.SchoolID, SectionName = section.SectionName, CurriculumID = section.CurriculumID, MaxStudent = section.MaxStudent, MaxGrade = section.MaxGrade });
                }
            }
            return Request.CreateResponse<List<Section>>(HttpStatusCode.OK, sections);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var sectionDetails = unitOfWork.SectionRepository.GetByID(id);
            var section = new DataEntities.Models.Section();
            if (sectionDetails != null)
            {
                section.SectionID = sectionDetails.SectionID;
                section.YearLvl = sectionDetails.YearLvl;
                section.SectionName = sectionDetails.SectionName;
                section.CurriculumID = sectionDetails.CurriculumID;
                section.MaxGrade = sectionDetails.MaxGrade;
                section.MaxStudent = sectionDetails.MaxStudent;
                section.MinGrade = sectionDetails.MinGrade;
                section.SchoolID = sectionDetails.SchoolID;
            }
            return Request.CreateResponse<Section>(HttpStatusCode.OK, section);
        }

        // POST api/values
        public HttpResponseMessage Post(int id, DataEntities.Models.Section sectionDetails)
        {
            var section = unitOfWork.SectionRepository.GetByID(id);

            section.SectionID = sectionDetails.SectionID;
            section.YearLvl = sectionDetails.YearLvl;
            section.SectionName = sectionDetails.SectionName;
            section.CurriculumID = sectionDetails.CurriculumID;
            section.MaxGrade = sectionDetails.MaxGrade;
            section.MaxStudent = sectionDetails.MaxStudent;
            section.MinGrade = sectionDetails.MinGrade;
            section.SchoolID = sectionDetails.SchoolID;
            unitOfWork.SectionRepository.Update(section);
            unitOfWork.Save();
            return Request.CreateResponse<Section>(HttpStatusCode.OK, section);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Section sectionDetails)
        {
            try
            {
                var section = new DataEntities.Models.Section();
                if (sectionDetails != null)
                {

                    section.SectionID = sectionDetails.SectionID;
                    section.YearLvl = sectionDetails.YearLvl;
                    section.SectionName = sectionDetails.SectionName;
                    section.CurriculumID = sectionDetails.CurriculumID;
                    section.MaxGrade = sectionDetails.MaxGrade;
                    section.MaxStudent = sectionDetails.MaxStudent;
                    section.MinGrade = sectionDetails.MinGrade;
                    section.SchoolID = sectionDetails.SchoolID;
                }
                unitOfWork.SectionRepository.Insert(section);
                unitOfWork.Save();
                return Request.CreateResponse<Section>(HttpStatusCode.OK, section);
            }
            catch
            {
                return Request.CreateResponse<Section>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var section = unitOfWork.SectionRepository.GetByID(id);

                if (section != null)
                {
                    unitOfWork.SectionRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<Section>(HttpStatusCode.OK, section);
            }
            catch
            {
                return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
