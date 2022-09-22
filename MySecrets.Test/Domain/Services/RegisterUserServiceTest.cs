using MySecrets.CrossCutting.Emails.Interfaces;
using MySecrets.Domain.Entities.Users;
using MySecrets.Domain.Entities.ValueObjects;
using MySecrets.Domain.Exceptions;
using MySecrets.Domain.Exceptions.Users;
using MySecrets.Domain.Repositories;
using MySecrets.Domain.Services.Interfaces;
using MySecrets.Domain.Services.Users;
using NSubstitute;

namespace MySecrets.Test.Domain.Services
{
    [TestFixture]
    public class RegisterUserServiceTest
    {

        [Test]
        public async Task RegisterUser_InvalidUser()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            IUserRegisterEmailBuilder userRegisterEmailBuilder = Substitute.For<IUserRegisterEmailBuilder>();
            IEmailService emailService = Substitute.For<IEmailService>();

            var registerUserService = new RegisterUserService(
                userRepository,
                userRegisterEmailBuilder,
                emailService);

            var ex = Assert.ThrowsAsync<InvalidUserException>(async () => await registerUserService.Register(null));

            Assert.That(typeof(InvalidUserException), Is.EqualTo(ex.GetType()));
        }

        [Test]
        public async Task RegisterUser_AlreadyRegistered()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            IUserRegisterEmailBuilder userRegisterEmailBuilder = Substitute.For<IUserRegisterEmailBuilder>();
            IEmailService emailService = Substitute.For<IEmailService>();

            User user = new User()
            {
                Email = new Email("williamnwz@gmail.com"),
                Id = Guid.NewGuid().ToString(),
                IsActive = false,
                Login = "williamnwz",
                Password = "#abc123",
                Friends = new List<FriendRelationship>()
            };

            userRepository.GetByEmailAsync(user.Email.Value).Returns(user);

            var registerUserService = new RegisterUserService(
                userRepository,
                userRegisterEmailBuilder,
                emailService);

            var ex = Assert.ThrowsAsync<UserAlreadyRegisteredException>(async () => await registerUserService.Register(user));

            Assert.That(typeof(UserAlreadyRegisteredException), Is.EqualTo(ex.GetType()));
        }

        [Test]
        public async Task RegusterUser_EmptyEmail()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            IUserRegisterEmailBuilder userRegisterEmailBuilder = Substitute.For<IUserRegisterEmailBuilder>();
            IEmailService emailService = Substitute.For<IEmailService>();

            User user = new User()
            {
                Email = null,
                Id = Guid.NewGuid().ToString(),
                IsActive = false,
                Login = "williamnwz",
                Password = "#abc123",
                Friends = new List<FriendRelationship>()
            };

            var registerUserService = new RegisterUserService(
                userRepository,
                userRegisterEmailBuilder,
                emailService);

            var ex = Assert.ThrowsAsync<InvalidEmailException>(async () => await registerUserService.Register(user));

            Assert.That(typeof(InvalidEmailException), Is.EqualTo(ex.GetType()));
        }

        [Test]
        public async Task RegusterUser_InvalidFormatEmail()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            IUserRegisterEmailBuilder userRegisterEmailBuilder = Substitute.For<IUserRegisterEmailBuilder>();
            IEmailService emailService = Substitute.For<IEmailService>();

            User user = new User()
            {
                Email = new Email("williamnwz"),
                Id = Guid.NewGuid().ToString(),
                IsActive = false,
                Login = "williamnwz",
                Password = "#abc123",
                Friends = new List<FriendRelationship>()
            };

            var registerUserService = new RegisterUserService(
                userRepository,
                userRegisterEmailBuilder,
                emailService);

            var ex = Assert.ThrowsAsync<InvalidEmailException>(async () => await registerUserService.Register(user));

            Assert.That(typeof(InvalidEmailException), Is.EqualTo(ex.GetType()));
        }

        [Test]
        public async Task RegusterUser_Success()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            IUserRegisterEmailBuilder userRegisterEmailBuilder = Substitute.For<IUserRegisterEmailBuilder>();
            IEmailService emailService = Substitute.For<IEmailService>();

            User user = new User()
            {
                Email = new Email("williamnwz@gmail.com"),
                Id = Guid.NewGuid().ToString(),
                IsActive = false,
                Login = "williamnwz",
                Password = "#abc123",
                Friends = new List<FriendRelationship>()
            };

            RegisterUserMessage registerUserMessage = new RegisterUserMessage(user, "test@test.com");

            userRegisterEmailBuilder
                .Build(user)
                .Returns(registerUserMessage);

            userRepository.GetByEmailAsync(user.Email.Value).Returns(Task.FromResult<User>(null));

            var registerUserService = new RegisterUserService(
                userRepository,
                userRegisterEmailBuilder,
                emailService);

            await registerUserService.Register(user);

            await userRegisterEmailBuilder.Received(1).Build(user);

            await emailService.Received(1).SendEmail(registerUserMessage);

        }
    }
}
