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
    public class SchoolYearController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var schoolYearList = from schoolYear in unitOfWork.SchoolyearRepository.Get() select schoolYear;
            var schoolYears = new List<DataEntities.Models.tblSchoolYear>();
            if (schoolYearList.Any())
            {
                foreach (var schoolYear in schoolYearList)
                {
                    schoolYears.Add(new DataEntities.Models.tblSchoolYear() { SchoolYear = schoolYear.SchoolYear, Status = schoolYear.Status, SchoolID = schoolYear.SchoolID });
                }
            }
            return Request.CreateResponse<List<tblSchoolYear>>(HttpStatusCode.OK, schoolYears);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var schoolYearDetails = unitOfWork.SchoolyearRepository.GetByID(id);
            var schoolYear = new DataEntities.Models.tblSchoolYear();
            if (schoolYearDetails != null)
            {
                schoolYear.SchoolYear = schoolYearDetails.SchoolYear;
                schoolYear.Status = schoolYearDetails.Status;
                schoolYear.SchoolID = schoolYearDetails.SchoolID;
            }
            return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.OK, schoolYear);
        }

        // POST api/values
        public HttpResponseMessage Post(int id, DataEntities.Models.tblSchoolYear schoolYearDetails)
        {
            var schoolYear = unitOfWork.SchoolyearRepository.GetByID(id);
            schoolYear.SchoolYear = schoolYearDetails.SchoolYear;
            schoolYear.Status = schoolYearDetails.Status;
            schoolYear.SchoolID = schoolYearDetails.SchoolID;
            unitOfWork.SchoolyearRepository.Update(schoolYear);
            unitOfWork.Save();
            return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.OK, schoolYear);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblSchoolYear schoolYearDetails)
        {
            try
            {
                var schoolYear = unitOfWork.SchoolyearRepository.GetByID(id);
                schoolYear.SchoolYear = schoolYearDetails.SchoolYear;
                schoolYear.Status = schoolYearDetails.Status;
                schoolYear.SchoolID = schoolYearDetails.SchoolID;
                unitOfWork.SchoolyearRepository.Update(schoolYear);
                unitOfWork.Save();
                return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.OK, schoolYear);
            }
            catch
            {
                return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var schoolYear = unitOfWork.SchoolyearRepository.GetByID(id);

                if (schoolYear != null)
                {
                    unitOfWork.SchoolyearRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.OK, schoolYear);
            }
            catch
            {
                return Request.CreateResponse<tblSchoolYear>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
