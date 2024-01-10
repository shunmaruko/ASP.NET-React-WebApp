using Moq;
using Backend.Infrastructure.Repository;
using Backend.Models;
using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NuGet.ContentModel;

namespace Backend.Tests.UnitTests.Controller
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUsers()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<UserDTO>>();
            mockRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestUsers());
            var controller = new UserController(mockRepo.Object);
            // Act
            ActionResult<IEnumerable<UserDTO>> result = await controller.GetUsers();
            var actual = result.Value as List<UserDTO>;
            if (actual != null)
            {
                List<UserDTO> expected = GetTestUsers();
                // Assert 
                Assert.Equivalent(actual.ToList(), expected.ToList());
            }
        }
        [Fact]
        public async Task PostUser()
        {
            // Arrange
            var testUserDTO = GetTestUsers().First();
            var mockRepo = new Mock<IRepository<UserDTO>>();
            mockRepo.Setup(repo => repo.AddAsync(testUserDTO)).Returns(Task.CompletedTask);
            var controller = new UserController(mockRepo.Object);
            // Act
            var result = await controller.PostUser(testUserDTO);
            var actual = result.Value;
            // Assert 
            if (actual != null)
            {
                var expected = GetTestUsers().First();
                Assert.Equivalent(actual, expected);

            }
        }
        private List<UserDTO> GetTestUsers()
        {
            var users = new List<UserDTO>();
            users.Add(new UserDTO {
                Id = 1,
                Name = "foo",
                MailAdress = "foo@gmail.com"
            });
            users.Add(new UserDTO
            {
                Id = 2,
                Name = "bar",
                MailAdress = "bar@yahoo.com"
            });
            return users;
        }
    }
}
