using innocv_crud.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace innocv_crud.Api.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository repository = new UserRepository();

        public UsersController() { }

           /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User with the Id</returns>
        [HttpGet]
        public User GetUser(int id)
        {
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// Reads user data by Item
        /// </summary>
        /// <param name="item">User object</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage PostUser([FromBody]User item)
        {
            item = repository.Create(item);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        /// <summary>
        /// Updates a user on the list of users
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="user">User object</param>
        /// <returns>User updated</returns>
        [HttpPut]
        public User PutUser(int id, [FromBody]User user)
        {
            user.Id = id;
            if (!repository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        /// <summary>
        /// Removes user by Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User deleted</returns>
        [HttpDelete]
        public User DeleteUser(int id)
        {
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Delete(id);

            return item;
        }
    }
}