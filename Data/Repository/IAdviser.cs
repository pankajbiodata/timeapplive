using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface IAdviserRepository:IDisposable
    {

        IEnumerable<tblAdviser> GetAdvisers();
        tblAdviser GetAdviserByID(int AdviserId);
        void InsertAdviser(tblAdviser Adviser);
        void DeleteAdviser(int Adviserid);
        void UpdateAdviser(tblAdviser Adviser);
        void Save();
    }
}
