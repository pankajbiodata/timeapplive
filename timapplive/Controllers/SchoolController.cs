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
    public class SchoolController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var schoolList = from school in unitOfWork.SchoolRepository.Get() select school;
            var schools = new List<DataEntities.Models.tblSchools>();
            if (schoolList.Any())
            {
                foreach (var school in schoolList)
                {
                    schools.Add(new DataEntities.Models.tblSchools() { SchoolName = school.SchoolName, SchoolAddress = school.SchoolAddress, SchoolID = school.SchoolID, City = school.City, Country = school.Country });
                }
            }
            return Request.CreateResponse<List<tblSchools>>(HttpStatusCode.OK, schools);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var schoolDetails = unitOfWork.SchoolRepository.GetByID(id);
            var school = new DataEntities.Models.tblSchools();
            if (schoolDetails != null)
            {
                school.SchoolID = schoolDetails.SchoolID;
                school.SchoolName = schoolDetails.SchoolName;
                school.SchoolAddress = schoolDetails.SchoolAddress;
                school.City = schoolDetails.City;
                school.Country = schoolDetails.Country;
            }
            return Request.CreateResponse<tblSchools>(HttpStatusCode.OK, school);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var schoolDetails = unitOfWork.SchoolRepository.GetByID(id);
            var school = new DataEntities.Models.tblSchools();
            if (schoolDetails != null)
            {
                school.SchoolID = schoolDetails.SchoolID;
                school.SchoolName = schoolDetails.SchoolName;
                school.SchoolAddress = schoolDetails.SchoolAddress;
                school.City = schoolDetails.City;
                school.Country = schoolDetails.Country;
            }
            return Request.CreateResponse<tblSchools>(HttpStatusCode.OK, school);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblSchools schoolDetails)
        {
            try
            {
                var school = unitOfWork.SchoolRepository.GetByID(id);
                school.SchoolID = schoolDetails.SchoolID;
                school.SchoolName = schoolDetails.SchoolName;
                school.SchoolAddress = schoolDetails.SchoolAddress;
                school.City = schoolDetails.City;
                school.Country = schoolDetails.Country;
                unitOfWork.SchoolRepository.Update(school);
                unitOfWork.Save();
                return Request.CreateResponse<tblSchools>(HttpStatusCode.OK, school);
            }
            catch
            {
                return Request.CreateResponse<tblSchools>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var school = unitOfWork.SchoolRepository.GetByID(id);

                if (school != null)
                {
                    unitOfWork.SchoolRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblSchools>(HttpStatusCode.OK, school);
            }
            catch
            {
                return Request.CreateResponse<tblSchools>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
