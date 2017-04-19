using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface IFacultyRepository:IDisposable
    {
        IEnumerable<Faculty> GetFaculty();
        Faculty GetFacultyByID(int FacultyId);
        void InsertFaculty(Faculty Faculty);
        void DeleteFaculty(int FacultyId);
        void UpdateFaculty(Faculty Faculty);
        void Save();
    }
}
