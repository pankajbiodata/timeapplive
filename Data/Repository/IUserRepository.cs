using System;
using System.Collections.Generic;
using DataEntities.Models;
namespace Data.Repository
{
    public interface IUserRepository:IDisposable
    {
        IEnumerable<tblUsers> GetUsers();
        tblUsers GetUserByID(int userId);
        void InsertUser(tblUsers user);
        void DeleteUser(int userId);
        void UpdateUser(tblUsers user);
        void Save();
    }
}
