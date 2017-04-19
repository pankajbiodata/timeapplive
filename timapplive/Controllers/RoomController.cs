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
    public class RoomController : ApiController
    {
        #region Private member variables...
        private Data.UnitOfWork.UnitOfWork unitOfWork = new Data.UnitOfWork.UnitOfWork();
        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var roomList = from room in unitOfWork.RoomRepository.Get() select room;
            var rooms = new List<DataEntities.Models.Room>();
            if (roomList.Any())
            {
                foreach (var room in roomList)
                {
                    rooms.Add(new DataEntities.Models.Room() { RoomID = room.RoomID, RoomNo = room.RoomNo, SchoolID = room.SchoolID, Building = room.Building, Capacity = room.Capacity });
                }
            }
            return Request.CreateResponse<List<Room>>(HttpStatusCode.OK, rooms);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var roomDetails = unitOfWork.RoomRepository.GetByID(id);
            var room = new DataEntities.Models.Room();
            if (roomDetails != null)
            {
                room.RoomID = roomDetails.RoomID;
                room.Building = roomDetails.Building;
                room.Capacity = roomDetails.Capacity;
                room.RoomNo = roomDetails.RoomNo;
                room.SchoolID = roomDetails.SchoolID;
            }
            return Request.CreateResponse<Room>(HttpStatusCode.OK, room);
        }

        // POST api/values
        public HttpResponseMessage Post(int id)
        {
            var roomDetails = unitOfWork.RoomRepository.GetByID(id);
            var room = new DataEntities.Models.Room();
            if (roomDetails != null)
            {
                room.RoomID = roomDetails.RoomID;
                room.Building = roomDetails.Building;
                room.Capacity = roomDetails.Capacity;
                room.RoomNo = roomDetails.RoomNo;
                room.SchoolID = roomDetails.SchoolID;
            }
            return Request.CreateResponse<Room>(HttpStatusCode.OK, room);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Room roomDetails)
        {
            try
            {
                var room = unitOfWork.RoomRepository.GetByID(id);
                room.RoomID = roomDetails.RoomID;
                room.Building = roomDetails.Building;
                room.Capacity = roomDetails.Capacity;
                room.RoomNo = roomDetails.RoomNo;
                room.SchoolID = roomDetails.SchoolID;
                unitOfWork.RoomRepository.Update(room);
                unitOfWork.Save();
                return Request.CreateResponse<Room>(HttpStatusCode.OK, room);
            }
            catch
            {
                return Request.CreateResponse<Room>(HttpStatusCode.NotFound, null);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var room = unitOfWork.RoomRepository.GetByID(id);

                if (room != null)
                {
                    unitOfWork.RoomRepository.Delete(id);
                    unitOfWork.Save();
                }

                return Request.CreateResponse<Room>(HttpStatusCode.OK, room);
            }
            catch
            {
                return Request.CreateResponse<Room>(HttpStatusCode.NotFound, null);
            }
        }
    }
}
