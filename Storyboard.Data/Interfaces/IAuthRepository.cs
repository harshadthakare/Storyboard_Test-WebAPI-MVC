using Storyboard.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.Interfaces
{
    public interface IAuthRepository
    {
        bool RegisterUser(UserRegisterDTO register);
        UserLoginDTO LoginUser(UserLoginDTO login);
        
    }
}
