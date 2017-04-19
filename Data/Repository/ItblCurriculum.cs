using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ItblCurriculumRepository:IDisposable
    {
        IEnumerable<tblCurriculum> GettblCurriculums();
        tblCurriculum GettblCurriculumByID(int tblCurriculumid);
        void InserttblCurriculum(tblCurriculum tblCurriculum);
        void DeletetblCurriculum(int tblCurriculumid);
        void UpdatetblCurriculum(tblCurriculum tblCurriculum);
        void Save();
    }
}
