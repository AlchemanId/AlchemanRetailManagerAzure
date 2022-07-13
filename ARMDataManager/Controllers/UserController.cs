using ARMDataManager.Library.DataAccess;
using ARMDataManager.Library.Models;
using ARMDataManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ARMDataManager.Controllers
{
    [Authorize]
    //[RoutePrefix("api/User")]
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

        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [HttpGet]
        [Route("api/User/Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUser()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();

                var roles = context.Roles.ToList();

                foreach (var user in users)
                {
                    ApplicationUserModel u = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Email = user.Email
                    };

                    foreach (var r in user.Roles)
                    {
                        u.Roles.Add(r.RoleId, roles.Where(x => x.Id == r.RoleId).First().Name);

                    }
                    output.Add(u);
                }
            }
            return output;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/User/Admin/GetAllRoles")]
        public Dictionary<string,string> GetAllRoles()
        {
            using (var context = new ApplicationDbContext())
            {
                var roles = context.Roles.ToDictionary(x => x.Id, x => x.Name);

                return roles;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/User/Admin/AddRole")]
        public void AddRole(UserRolePairModel pairing)
        {
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.AddToRole(pairing.UserId, pairing.RoleName);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/User/Admin/RemoveRole")]
        public void RemoveRole(UserRolePairModel pairing)
        {
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.RemoveFromRole(pairing.UserId, pairing.RoleName);
            }
        }
    }
}