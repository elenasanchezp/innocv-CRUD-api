using innocv_crud_api.Models;
using innocv_crud_api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innocv_crud_api.Test
{
    [TestClass]
    public class UserUnitTest
    {
        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            //Setup
            var users = GetMoqUsers();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.GetAll()).Returns(users);

            // Act
            IEnumerable<User> usersResult = mockUserRepository.Object.GetAll();

            // Assert
            Assert.AreEqual(users.Count, usersResult.Count());
        }

        private List<User> GetMoqUsers()
        {
            var moqUsers = new List<User>();
            moqUsers.Add(new User { Id = 1, Name = "George W", Birthdate = new DateTime(2021,03,24) });
            moqUsers.Add(new User { Id = 2, Name = "Fred", Birthdate = new DateTime(1972,07,11)});
            moqUsers.Add(new User { Id = 3, Name = "William W", Birthdate = new DateTime(1956,12,11)});
            moqUsers.Add(new User { Id = 4, Name = "Marge", Birthdate = new DateTime(2012,01,12) });

            return moqUsers;
        }
    }
}
