using innocv_crud_api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innocv_crud_api.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private int _nextId = 1;

        // Creates instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();

        public UserRepository()
        {            
            foreach (var user in db.Users) {
                Create(new User { Name = user.Name, Birthdate = user.Birthdate});
            }
            /*
            Create(new User { Name = "Test 1", Birthdate = "01/01/1981 0:00:00"});
            Create(new User { Name = "Test 2", Birthdate = "01/01/1982 0:00:00"});
            Create(new User { Name = "Test 3", Birthdate = "01/01/1983 0:00:00"});
            Create(new User { Name = "Test 4", Birthdate = "01/01/1984 0:00:00"});
            Create(new User { Name = "Test 5", Birthdate = "01/01/1985 0:00:00"});
            Create(new User { Name = "Test 6", Birthdate = "01/01/1986 0:00:00"});
            */
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        public IEnumerable<User> GetAll()
        {
            return users;
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User with the Id</returns>
        public User Get(int id)
        {
            return users.Find(p => p.Id == id);           
        }

        /// <summary>
        /// Adds a new user to the list of users
        /// </summary>
        /// <param name="item">User to add</param>
        /// <returns>User added</returns>
        public User Create(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            users.Add(item);

            //db.Users.Add(item);
            //db.SaveChanges();

            return item;
        }

        /// <summary>
        /// Updates a user on the list of users
        /// </summary>
        /// <param name="item">User to update</param>
        /// <returns>True if successfully, false if user doesn´t exist</returns>
        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = users.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }

            users.RemoveAt(index);
            users.Add(item);

            return true;
        }

        /// <summary>
        /// Removes user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>True if successfully, false if user doesn´t exist</returns>
        public bool Delete(int id)
        {
            int index = users.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                return false;
            }

            users.RemoveAll(p => p.Id == id);

            return true;
        }       
    }
}