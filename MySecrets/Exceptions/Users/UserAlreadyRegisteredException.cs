using MySecrets.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecrets.Domain.Exceptions.Users
{
    public class UserAlreadyRegisteredException : DomainException
    {
        public UserAlreadyRegisteredException(User user) : base()
        {
        }
    }
}
