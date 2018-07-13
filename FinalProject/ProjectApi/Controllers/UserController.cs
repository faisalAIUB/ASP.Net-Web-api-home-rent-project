using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using ProjectInterface;
using ProjectEntity;
using ProjectApi.Attributes;
using System.Threading;

namespace ProjectApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserRepository repo;
        private IRentAdRepository RentRepo;

        public UserController(IUserRepository repo, IRentAdRepository rentRepo)
        {
            this.repo = repo;
            RentRepo = rentRepo;
        }

        [Route("")]
        [BasicAuthenticationAttributes]
        public IHttpActionResult Get()
        {
            int id = Int32.Parse(Thread.CurrentPrincipal.Identity.Name);
            return Ok(id);
        }
        [Route("{id}", Name = "GetUserById")]
        public IHttpActionResult Get(int id)
        {
            User  user = repo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(user);
        }
        [Route("")]
        public IHttpActionResult Post(User user)
        {
            repo.Insert(user);
            return Created("",user);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromBody]User user,[FromUri]int id)
        {
            user.Id = id;
            repo.Update(user);
            return Ok(user);
        }
       // [Route("")]
       //public IHttpActionResult Get()
       // {

       //     return Ok(repo.GetAll());
       // }
        
    }
}
