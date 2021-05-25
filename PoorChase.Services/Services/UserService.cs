using PoorChase.Data;
using PoorChase.Entities;
using System;
using System.Linq;

namespace PoorChase.Services
{
    /// <summary>
    /// Service implementation for <see cref="User"/>s by <see cref="IUserService"/>
    /// </summary>
    public class UserService : IUserService
    {
        IDataRepository<User> _repo;

        public UserService() => _repo = new UserRepository();

        /// <summary>
        /// Add new User to system
        /// </summary>
        /// <param name="user">the new user</param>
        /// <exception cref="UserNameExistsException"></exception>
        public void AddUser(User user)
        {
            if (GetByUserName(user.UserName) != null)
                throw new UserNameExistsException($"User with UserName: {user.UserName} already exists");
            _repo.Add(user);
        }

        /// <summary>
        /// Edit existed user details
        /// </summary>
        /// <param name="user">user after details changed/edited</param>
        public void EditDetails(User user)
        {
            _repo.Update(user);
        }

        /// <summary>
        /// Get a User by his ID
        /// </summary>
        /// <param name="id">ID of the required user</param>
        /// <returns><see cref="User"/> with the entered id.
        /// NULL if user with entered id not found.</returns>
        public User GetById(int id) => _repo.GetById(id);

        /// <summary>
        /// Login a user to system using user name & password
        /// </summary>
        /// <param name="userName">User's user name</param>
        /// <param name="password">User's password</param>
        /// <returns><see cref="User"/> instace of the user, in case login went successfully.</returns>
        /// <exception cref="UserNotFoundException"></exception>
        public User Login(string userName, string password)
        {
            var user = GetByUserName(userName);
            if (user == null || user.Password != password)
                throw new UserNotFoundException("User name or password are incorrect.");
            return user;
        }

        /// <summary>
        /// Get user by his user name
        /// </summary>
        /// <param name="userName">the user name of the required user</param>
        /// <returns><see cref="User"/> instance of the user with the entered user name.
        /// NULL if User with entered username not found.</returns>
        public User GetByUserName(string userName) => _repo.GetAll().FirstOrDefault(u => u.UserName == userName);

        /// <summary>
        /// Get current day state
        /// </summary>
        /// <returns><see cref="DayState"/> representation of current day state</returns>
        public DayState GetCurrentDayState()
        {
            var hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12)
                return DayState.Morning;
            else if (hour >= 12 && hour < 18)
                return DayState.Afternoon;
            else if (hour >= 18 && hour < 22)
                return DayState.Evening;
            else
                return DayState.Night;
        }
    }
}
