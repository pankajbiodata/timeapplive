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
    public class CurriculumController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var curriculumList = from curriculum in unitOfWork.CurriculumRepository.Get() select curriculum;
            var curriculums = new List<DataEntities.Models.tblCurriculum>();
            if (curriculumList.Any())
            {
                foreach (var curriculum in curriculumList)
                {
                    curriculums.Add(new DataEntities.Models.tblCurriculum() { CurriculumID = curriculum.CurriculumID, CurriculumTitle = curriculum.CurriculumTitle, SchoolID = curriculum.SchoolID });
                }
            }
            return Request.CreateResponse<List<tblCurriculum>>(HttpStatusCode.OK, curriculums);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var curriculumDetails = unitOfWork.CurriculumRepository.GetByID(id);
            var curriculum = new DataEntities.Models.tblCurriculum();
            if (curriculumDetails != null)
            {
                curriculum.CurriculumID = curriculumDetails.CurriculumID;
                curriculum.CurriculumTitle = curriculumDetails.CurriculumTitle;
                curriculum.SchoolID = curriculumDetails.SchoolID;
            }
            return Request.CreateResponse<tblCurriculum>(HttpStatusCode.OK, curriculum);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var curriculumDetails = unitOfWork.CurriculumRepository.GetByID(id);
            var curriculum = new DataEntities.Models.tblCurriculum();
            if (curriculumDetails != null)
            {
                curriculum.CurriculumID = curriculumDetails.CurriculumID;
                curriculum.CurriculumTitle = curriculumDetails.CurriculumTitle;
                curriculum.SchoolID = curriculumDetails.SchoolID;
            }
            return Request.CreateResponse<tblCurriculum>(HttpStatusCode.OK, curriculum);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, tblCurriculum curriculumDetails)
        {
            try
            {
                var curriculum = unitOfWork.CurriculumRepository.GetByID(id);
                curriculum.CurriculumID = curriculumDetails.CurriculumID;
                curriculum.CurriculumTitle = curriculumDetails.CurriculumTitle;
                curriculum.SchoolID = curriculumDetails.SchoolID;
                unitOfWork.CurriculumRepository.Update(curriculum);
                unitOfWork.Save();
                return Request.CreateResponse<tblCurriculum>(HttpStatusCode.OK, curriculum);
            }
            catch
            {
                return Request.CreateResponse<tblCurriculum>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var curriculum = unitOfWork.CurriculumRepository.GetByID(id);

                if (curriculum != null)
                {
                    unitOfWork.CurriculumRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<tblCurriculum>(HttpStatusCode.OK, curriculum);
            }
            catch
            {
                return Request.CreateResponse<tblCurriculum>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
