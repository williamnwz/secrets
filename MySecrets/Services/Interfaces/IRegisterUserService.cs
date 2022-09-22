using MySecrets.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecrets.Domain.Services.Interfaces
{
    public interface IRegisterUserService
    {
        Task Register(User user);
    }
}
