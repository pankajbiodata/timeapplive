using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface ISectionRepository:IDisposable
    {
        IEnumerable<Section> GetSections();
        Section GetSectionByID(int Sectionid);
        void InsertSection(Section Section);
        void DeleteSection(int Sectionid);
        void UpdateSection(Section Section);
        void Save();
    }
}
