using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ItblSubjectOfferingRepository : IDisposable
    {
        IEnumerable<tblSubjectOffering> GetSubjectOfferings();
        tblSubjectOffering GetSubjectOfferingByID(int tblSubjectOfferingId);
        void InsertSubjectOffering(tblSubjectOffering user);
        void DeleteSubjectOffering(int tblSubjectOfferingId);
        void UpdateSubjectOffering(tblSubjectOffering user);
        void Save();
    }
}
