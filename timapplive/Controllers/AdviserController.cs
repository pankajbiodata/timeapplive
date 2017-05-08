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
using System.Text;
#endregion
namespace timewebserverapp.Controllers
{
    [System.Web.Http.Authorize]
    public class AdviserController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var adviserList = from adviser in unitOfWork.AdviserRepository.Get() select adviser;
            var advisers = new List<DataEntities.Models.tblAdviser>();
            if (adviserList.Any())
            {
                foreach (var adviser in adviserList)
                {
                    advisers.Add(new DataEntities.Models.tblAdviser() { AdviserID = adviser.AdviserID, FacultyID = adviser.FacultyID, SectionID = adviser.SectionID, SchoolID = adviser.SchoolID });
                }
            }
            string JsonList = JsonConvert.SerializeObject(advisers);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonList, Encoding.UTF8, "application/json");
            return response;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var adviserDetails = unitOfWork.AdviserRepository.GetByID(id);
            var adviser = new DataEntities.Models.tblAdviser();
            if (adviserDetails != null)
            {
                adviser.AdviserID = adviserDetails.AdviserID;
                adviser.FacultyID = adviserDetails.FacultyID;
                adviser.SectionID = adviserDetails.SectionID;
                adviser.SchoolID = adviserDetails.SchoolID;
            }
            return Request.CreateResponse<tblAdviser>(HttpStatusCode.OK, adviser);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var adviserDetails = unitOfWork.AdviserRepository.GetByID(id);
            var adviser = new DataEntities.Models.tblAdviser();
            if (adviserDetails != null)
            {
                adviser.AdviserID = adviserDetails.AdviserID;
                adviser.FacultyID = adviserDetails.FacultyID;
                adviser.SectionID = adviserDetails.SectionID;
                adviser.SchoolID = adviserDetails.SchoolID;
            }
            return Request.CreateResponse<tblAdviser>(HttpStatusCode.OK, adviser);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblAdviser adviserDetails)
        {
            try
            {
                var adviser = unitOfWork.AdviserRepository.GetByID(id);
                adviser.AdviserID = adviserDetails.AdviserID;
                adviser.FacultyID = adviserDetails.FacultyID;
                adviser.SectionID = adviserDetails.SectionID;
                adviser.SchoolID = adviserDetails.SchoolID;
                unitOfWork.AdviserRepository.Update(adviser);
                unitOfWork.Save();
                return Request.CreateResponse<tblAdviser>(HttpStatusCode.OK, adviser);
            }
            catch
            {
                return Request.CreateResponse<tblAdviser>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var adviser = unitOfWork.AdviserRepository.GetByID(id);

                if (adviser != null)
                {
                    unitOfWork.AdviserRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblAdviser>(HttpStatusCode.OK, adviser);
            }
            catch
            {
                return Request.CreateResponse<tblAdviser>(HttpStatusCode.NotFound, null);
            }
        }
       
    }
}
