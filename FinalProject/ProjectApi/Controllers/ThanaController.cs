using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectInterface;
using ProjectEntity;

namespace ProjectApi.Controllers
{
    [RoutePrefix("api/thanas")]
    public class ThanaController : ApiController
    {
        private IThanaRepository repo;

        public ThanaController(IThanaRepository repo)
        {
            this.repo = repo;
        }
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Thana thana = repo.Get(id);
            if (thana == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(thana);

        }
    }
}