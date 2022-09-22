using MySecrets.CrossCutting.Emails;
using MySecrets.CrossCutting.Emails.Interfaces;
using MySecrets.Domain.Entities.Users;
using MySecrets.Domain.Exceptions;
using MySecrets.Domain.Exceptions.Users;
using MySecrets.Domain.Repositories;
using MySecrets.Domain.Services.Interfaces;

namespace MySecrets.Domain.Services.Users
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRegisterEmailBuilder userRegisterEmailBuilder;
        private readonly IEmailService emailService;

        public RegisterUserService(
            IUserRepository userRepository,
            IUserRegisterEmailBuilder userRegisterEmailBuilder,
            IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.userRegisterEmailBuilder = userRegisterEmailBuilder;
            this.emailService = emailService;
        }

        public async Task Register(User user)
        {
            if (user == null) throw new InvalidUserException();

            if (user.Email == null) throw new InvalidEmailException();

            if (user.Email.IsValid() == false) throw new InvalidEmailException();

            User userAlreadyRegistered = await userRepository.GetByEmailAsync(email: user.Email.Value);

            if (userAlreadyRegistered != null) throw new UserAlreadyRegisteredException(userAlreadyRegistered);

            IEmailMessage emailMessage = await userRegisterEmailBuilder.Build(user);

            await emailService.SendEmail(emailMessage);
        }
    }
}
