using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using Darzelis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Darzelis.Web.Controllers
{
    public class RegisterController : ApiBaseController
    {
        public RegisterController(IRequestUow uow)
        {
            Uow = uow;
        }
        [HttpPost]
        public HttpResponseMessage Post(User register)
        {

            //User naujas = Uow.Users.GetAll().FirstOrDefault();

            //naujas.Username = "mariusdas";
            //naujas.Email = "mariusdas@gmail.com";
            //naujas.VaikoINDnr = 1;
            //naujas.Password = AlgorithmsAll.Sha256Algorithm.GetMD5Hash(register.Password);
            //naujas.ConfirmPassword = AlgorithmsAll.Sha256Algorithm.GetMD5Hash(register.Password);
            //naujas.UserType = 2;
            //Uow.Users.Add(naujas);
            //Uow.Commit();
            //var response1 = Request.CreateResponse(HttpStatusCode.Created, naujas);
            //return response1;

            if (ModelState.IsValid)
            {
                var allUsers = Uow.Users.GetAll().ToList();
                var vaikoIdValid = allUsers.FirstOrDefault(x => x.VaikoINDnr == register.VaikoINDnr);
                var emailValid = allUsers.FirstOrDefault(x => x.Email == register.Email);
                var usernameValid = allUsers.FirstOrDefault(x => x.Username == register.Username);
                register.Password = AlgorithmsAll.Sha256Algorithm.GetMD5Hash(register.Password);
                register.ConfirmPassword = AlgorithmsAll.Sha256Algorithm.GetMD5Hash(register.ConfirmPassword);
                if (vaikoIdValid != null)
                {
                    ModelState.AddModelError("vaikoIdValid", "Su tokiu vaikoId numeriu jau yra");
                    var message2 = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
                    var response3 = Request.CreateResponse(HttpStatusCode.BadRequest, message2);
                    return response3;
                }
                if (emailValid != null)
                {
                    ModelState.AddModelError("EmailValid", "Toks email jau egzistuoja");
                    var message2 = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
                    var response3 = Request.CreateResponse(HttpStatusCode.BadRequest, message2);
                    return response3;
                }
                if (usernameValid != null)
                {
                    ModelState.AddModelError("usernameValid", "Toks vartotojas jau egzistuoja");
                    var message2 = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
                    var response3 = Request.CreateResponse(HttpStatusCode.BadRequest, message2);
                    return response3;
                }
                if (register.Password != register.ConfirmPassword)
                {
                    ModelState.AddModelError("Password", "Slaptažodžiai nesutampa");
                    var message2 = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
                    var response3 = Request.CreateResponse(HttpStatusCode.BadRequest, message2);
                    return response3;
                }
                if (register.VaikoINDnr == 0)
                {
                    ModelState.AddModelError("VaikoId", "neteisingai ivestas VaikoId");
                    var message2 = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
                    var response3 = Request.CreateResponse(HttpStatusCode.BadRequest, message2);
                    return response3;
                }


                register.UserType = 1;

                Uow.Users.Add(register);
                Uow.Commit();
                var response1 = Request.CreateResponse(HttpStatusCode.Created, register);
                return response1;
            }


            if (register.Password != register.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "Slaptažodžiai nesutampa");
            }
            if (register.VaikoINDnr == 0)
            {
                ModelState.AddModelError("VaikoId", "neteisingai ivestas VaikoId");
            }

            var message = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Where(v => !string.IsNullOrWhiteSpace(v.ErrorMessage)).Select(e => e.ErrorMessage));
            var response2 = Request.CreateResponse(HttpStatusCode.BadRequest, message);
            return response2;
        }
    }
}
