using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domain.Interfaces;
using Domain.Models;
using System.Runtime.ExceptionServices;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest() 
        {
            var repositoryWrapperMoq= new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new User() { IdUser = 0, Login = "", Password = "", RoleId = 0, Address = "", IsDeleted = false} },
                new object[] {new User() { IdUser = 1, Login = "Le test", Password = "", RoleId = 0, Address = "", IsDeleted = false} },
                new object[] {new User() { IdUser = 10, Login = "Le test", Password = "Le Test", RoleId = 1, Address = "lmao", IsDeleted = false } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            var newUser = user;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUser()
        {
            var newUser = new User()
            {
                IdUser = 10,
                Login = "Le test",
                Password = "Le Test",
                RoleId = 1,
                Address = "lmao",
                IsDeleted = false
            };

            await service.Create(newUser);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        }
    }
}
