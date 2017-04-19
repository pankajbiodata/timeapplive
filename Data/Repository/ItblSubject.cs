using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ItblSubjectRepository : IDisposable
    {
        IEnumerable<tblSubject> GetSubjects();
        tblSubject GetSubjectByID(int subjectId);
        void InsertSubject(tblSubject subject);
        void DeleteSubject(int subjectId);
        void UpdateSubject(tblSubject subject);
        void Save();
    }
}
