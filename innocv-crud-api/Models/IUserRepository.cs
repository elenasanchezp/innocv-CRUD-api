using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innocv_crud_api.Models
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User with the Id</returns>
        User Get(int id);

        /// <summary>
        /// Adds a new user to the list of users
        /// </summary>
        /// <param name="item">User to add</param>
        /// <returns>User added</returns>
        User Create(User item);

        /// <summary>
        /// Updates a user on the list of users
        /// </summary>
        /// <param name="item">User to update</param>
        /// <returns>True if successfully, false if user doesn´t exist</returns>
        bool Update(User item);

        /// <summary>
        /// Removes user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>True if successfully, false if user doesn´t exist</returns>
        bool Delete(int id);
    }
}