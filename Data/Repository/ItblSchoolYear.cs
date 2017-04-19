using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ItblSchoolYearRepository:IDisposable
    {
        IEnumerable<tblSchoolYear> GetSchoolYears();
        tblSchoolYear GetSchoolYearByID(int userId);
        void InsertSchoolYear(tblSchoolYear tblSchoolYear);
        void DeleteSchoolYear(int tblSchoolYearId);
        void UpdateSchoolYear(tblSchoolYear tblSchoolYear);
        void Save();
    }
}
