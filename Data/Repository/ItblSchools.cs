using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ItblSchoolRepository:IDisposable
    {
        IEnumerable<tblSchools> GetSchools();
        tblSchools GetSchoolByID(int Schoolid);
        void InsertSchool(tblSchools School);
        void DeleteSchool(int Schoolid);
        void UpdateSchool(tblSchools School);
        void Save();
    }
}
