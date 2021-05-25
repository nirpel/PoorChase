using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoorChase.Services
{
    /// <summary>
    /// General service interface for <see cref="User"/> handling
    /// </summary>
    public interface IUserService
    {
        void AddUser(User user);

        User Login(string userName, string password);

        User GetById(int id);

        void EditDetails(User user);

        User GetByUserName(string userName);

        DayState GetCurrentDayState();
    }
}