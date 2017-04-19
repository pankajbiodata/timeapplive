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
    public class FacultyController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var facultyList = from faculty in unitOfWork.FacultyRepository.Get() select faculty;
            var facultys = new List<DataEntities.Models.Faculty>();
            if (facultyList.Any())
            {
                foreach (var faculty in facultyList)
                {
                    facultys.Add(new DataEntities.Models.Faculty() { FacultyID = faculty.FacultyID, LName = faculty.LName, FName = faculty.FName, MName = faculty.MName, Address = faculty.Address, Contact = faculty.Contact, Gender = faculty.Gender, OnService = faculty.OnService, SchoolID = faculty.SchoolID });
                }
            }
            return Request.CreateResponse<List<Faculty>>(HttpStatusCode.OK, facultys);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var facultyDetails = unitOfWork.FacultyRepository.GetByID(id);
            var faculty = new DataEntities.Models.Faculty();
            if (facultyDetails != null)
            {
                faculty.FacultyID = facultyDetails.FacultyID;
                faculty.FName = facultyDetails.FName;
                faculty.LName = facultyDetails.LName;
                faculty.MName = facultyDetails.MName;
                faculty.Gender = facultyDetails.Gender;
                faculty.Contact = facultyDetails.Contact;
                faculty.Address = facultyDetails.Address;
                faculty.OnService = facultyDetails.OnService;
                faculty.SchoolID = facultyDetails.SchoolID;
            }
            return Request.CreateResponse<Faculty>(HttpStatusCode.OK, faculty);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var facultyDetails = unitOfWork.FacultyRepository.GetByID(id);
            var faculty = new DataEntities.Models.Faculty();
            if (facultyDetails != null)
            {
                faculty.FacultyID = facultyDetails.FacultyID;
                faculty.FName = facultyDetails.FName;
                faculty.LName = facultyDetails.LName;
                faculty.MName = facultyDetails.MName;
                faculty.Gender = facultyDetails.Gender;
                faculty.Contact = facultyDetails.Contact;
                faculty.Address = facultyDetails.Address;
                faculty.OnService = facultyDetails.OnService;
                faculty.SchoolID = facultyDetails.SchoolID;
            }
            return Request.CreateResponse<Faculty>(HttpStatusCode.OK, faculty);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Faculty facultyDetails)
        {
            try
            {
                var faculty = unitOfWork.FacultyRepository.GetByID(id);
                faculty.FacultyID = facultyDetails.FacultyID;
                faculty.FName = facultyDetails.FName;
                faculty.LName = facultyDetails.LName;
                faculty.MName = facultyDetails.MName;
                faculty.Gender = facultyDetails.Gender;
                faculty.Contact = facultyDetails.Contact;
                faculty.Address = facultyDetails.Address;
                faculty.OnService = facultyDetails.OnService;
                faculty.SchoolID = facultyDetails.SchoolID;
                unitOfWork.FacultyRepository.Update(faculty);
                unitOfWork.Save();
                return Request.CreateResponse<Faculty>(HttpStatusCode.OK, faculty);
            }
            catch
            {
                return Request.CreateResponse<Faculty>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var faculty = unitOfWork.FacultyRepository.GetByID(id);

                if (faculty != null)
                {
                    unitOfWork.FacultyRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<Faculty>(HttpStatusCode.OK, faculty);
            }
            catch
            {
                return Request.CreateResponse<Faculty>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
