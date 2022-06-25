using ARMDataManager.Library.DataAccess;
using ARMDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ARMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet] // this allow you to do 'get' method
        public UserModel GetById()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            UserData data =  new UserData();
            return data.GetUserById(userId).First();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserNameInfo")]
        public UsernameModel UserNameInfo()
        {
            string username = HttpContext.Current.User.Identity.GetUserName();
            UsernameData data = new UsernameData();
            return data.GetUserByName(username).First();
        }
    }
}