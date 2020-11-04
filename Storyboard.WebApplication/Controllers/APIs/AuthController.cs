using Storyboard.WebApplication.DTOs;
using Storyboard.WebApplication.Interfaces;
using Storyboard.WebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storyboard.WebApplication.Controllers.APIs
{
    [RoutePrefix("Api/Auth")]
    public class AuthController : ApiController
    {
        private IAuthRepository authRepository;
        public AuthController()
        {
            authRepository = new AuthRepository();
        }
        [HttpPost]
        [Route("Register")]
        public HttpResponseMessage RegisterUser(UserRegisterDTO register)
        {
            try
            {
                bool result;
                result =  authRepository.RegisterUser(register);
                if (result == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
           
        }
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage LoginUser(UserLoginDTO login)
        {
            try
            {
                UserLoginDTO result = new UserLoginDTO();
                result = authRepository.LoginUser(login);
                if (result!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }          
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
