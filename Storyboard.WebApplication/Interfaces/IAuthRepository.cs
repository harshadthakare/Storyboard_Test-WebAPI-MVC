using Storyboard.WebApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.WebApplication.Interfaces
{
    public interface IAuthRepository
    {
        bool RegisterUser(UserRegisterDTO register);
        UserLoginDTO LoginUser(UserLoginDTO login);
        
    }
}
