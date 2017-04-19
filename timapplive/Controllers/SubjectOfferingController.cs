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
    public class SubjectOfferingController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var subjectOfferingList = from subjectOffering in unitOfWork.SubjectOfferingRepository.Get() select subjectOffering;
            var subjectOfferings = new List<DataEntities.Models.tblSubjectOffering>();
            if (subjectOfferingList.Any())
            {
                foreach (var subjectOffering in subjectOfferingList)
                {
                    subjectOfferings.Add(new DataEntities.Models.tblSubjectOffering() { SubjectCode = subjectOffering.SubjectCode, SubjectOfferingID = subjectOffering.SubjectOfferingID, SectionID = subjectOffering.SectionID, cTimeIn = subjectOffering.cTimeIn, cTimeOut = subjectOffering.cTimeOut, cRoom = subjectOffering.cRoom, cDay = subjectOffering.cDay, FacultyID = subjectOffering.FacultyID, SchoolID = subjectOffering.SchoolID });
                }
            }
            return Request.CreateResponse<List<tblSubjectOffering>>(HttpStatusCode.OK, subjectOfferings);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var subjectOfferingDetails = unitOfWork.SubjectOfferingRepository.GetByID(id);
            var subjectOffering = new DataEntities.Models.tblSubjectOffering();
            if (subjectOfferingDetails != null)
            {
                subjectOffering.cDay = subjectOfferingDetails.cDay;
                subjectOffering.cRoom = subjectOfferingDetails.cRoom;
                subjectOffering.cTimeIn = subjectOfferingDetails.cTimeIn;
                subjectOffering.cTimeOut = subjectOfferingDetails.cTimeOut;
                subjectOffering.FacultyID = subjectOfferingDetails.FacultyID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
            }
            return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.OK, subjectOffering);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var subjectOfferingDetails = unitOfWork.SubjectOfferingRepository.GetByID(id);
            var subjectOffering = new DataEntities.Models.tblSubjectOffering();
            if (subjectOfferingDetails != null)
            {
                subjectOffering.cDay = subjectOfferingDetails.cDay;
                subjectOffering.cRoom = subjectOfferingDetails.cRoom;
                subjectOffering.cTimeIn = subjectOfferingDetails.cTimeIn;
                subjectOffering.cTimeOut = subjectOfferingDetails.cTimeOut;
                subjectOffering.FacultyID = subjectOfferingDetails.FacultyID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
            }
            return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.OK, subjectOffering);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblSubjectOffering subjectOfferingDetails)
        {
            try
            {
                var subjectOffering = unitOfWork.SubjectOfferingRepository.GetByID(id);
                subjectOffering.cDay = subjectOfferingDetails.cDay;
                subjectOffering.cRoom = subjectOfferingDetails.cRoom;
                subjectOffering.cTimeIn = subjectOfferingDetails.cTimeIn;
                subjectOffering.cTimeOut = subjectOfferingDetails.cTimeOut;
                subjectOffering.FacultyID = subjectOfferingDetails.FacultyID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
                subjectOffering.SchoolID = subjectOfferingDetails.SchoolID;
                subjectOffering.SectionID = subjectOfferingDetails.SectionID;
                unitOfWork.SubjectOfferingRepository.Update(subjectOffering);
                unitOfWork.Save();
                return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.OK, subjectOffering);
            }
            catch
            {
                return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var subjectOffering = unitOfWork.SubjectOfferingRepository.GetByID(id);

                if (subjectOffering != null)
                {
                    unitOfWork.SubjectOfferingRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.OK, subjectOffering);
            }
            catch
            {
                return Request.CreateResponse<tblSubjectOffering>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
