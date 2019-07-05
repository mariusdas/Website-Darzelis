using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using Darzelis.Web.Constants;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Darzelis.Web.Controllers
{
    [Authorize(Roles = UserConstants.AdminRoleName)]
    public class UsersController : ApiBaseController
    {
       
       
        public UsersController(IRequestUow uow)
        {
            Uow = uow;
        }
        // GET api/users
        public IQueryable Get()
        {
            var model = Uow.Users.GetAll().Where(x=>x.UserType!=2);
            return model;

        }

        // GET api/users/5
        public User Get(int id)
        {
            var user = Uow.Users.GetById(id);
            if (user != null) return user;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Update an existing users
        // PUT /api/users/
        public HttpResponseMessage Put([FromBody]User usr)
        {
            Uow.Users.Update(usr);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // Create a new users
        // POST /api/users
        public HttpResponseMessage Post(User usr)
        {
            
            Uow.Users.Add(usr);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, usr);
            return response;
        }

        // DELETE api/users/5
        public HttpResponseMessage Delete(int id)
        {

            Uow.Users.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
