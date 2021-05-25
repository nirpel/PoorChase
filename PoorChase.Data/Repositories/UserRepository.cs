using PoorChase.Entities;
using System.Collections.Generic;

namespace PoorChase.Data
{
    /// <summary>
    /// Manage data for <see cref="User"/> entities
    /// </summary>
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// Add new <see cref="User"/> to saved data
        /// </summary>
        /// <param name="entity">The new user</param>
        public override void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all Users from saved data
        /// </summary>
        /// <returns>Collection of all users from data</returns>
        public override IEnumerable<User> GetAll() => _context.Users;

        /// <summary>
        /// Get a specific <see cref="User"/> by it's ID
        /// </summary>
        /// <param name="id">Required user's ID</param>
        /// <returns><see cref="User"/> Instance of the user with the entered ID.
        /// NULL if no such user found.</returns>
        public override User GetById(int id) => _context.Users.Find(id);

        /// <summary>
        /// Remove a <see cref="User"/> from saved data
        /// </summary>
        /// <param name="entity">User to remove</param>
        public override void Remove(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a <see cref="User"/> from existed data
        /// </summary>
        /// <param name="entity">the user after being changed/edited</param>
        public override void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
