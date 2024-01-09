using Moq;
using Backend.Infrastructure.Repository;
using Backend.Models;
using Backend.Controllers;

namespace Backend.Tests.UnitTests.Controller
{
    public class UserControllerTests
    {
        public async Task GetUsers()
        {
            // Arrange
            var mockRepo = new Mock<UserRepository>();
            mockRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestUsers());
            var controller = new UserController(mockRepo.Object);
            // Act
            var actual = await controller.GetUsers();
            var expected = GetTestUsers();
            // Assert 
            Assert.Equivalent(actual, expected);
        }
        public async Task PostUser()
        {
            // Arrange
            var testUserDTO = GetTestUsers().First();
            var mockRepo = new Mock<UserRepository>();
            mockRepo.Setup(repo => repo.AddAsync(testUserDTO)).Returns(Task.CompletedTask);
            var controller = new UserController(mockRepo.Object);
            // Act
            var actual = await controller.PostUser(testUserDTO);
            // Assert 
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
