using Storyboard.WebApplication.DTOs;
using Storyboard.WebApplication.EntityModel;
using Storyboard.WebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.WebApplication.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public UserLoginDTO LoginUser(UserLoginDTO login)
        {
            UserLoginDTO userData = new UserLoginDTO();
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    User user = context.Users.Where(x => x.Email == login.Email && x.Password == login.Password && x.IsDeleted == false).FirstOrDefault();
                    if (user!=null)
                    {
                        userData.Email = user.Email;
                        return userData;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool RegisterUser(UserRegisterDTO register)
        {
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    context.Users.Add(new User()
                    {
                        FirstName = register.FirstName,
                        MiddleName = register.MiddleName,
                        LastName = register.LastName,
                        Email = register.Email,
                        Password = register.Password,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now
                    });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
