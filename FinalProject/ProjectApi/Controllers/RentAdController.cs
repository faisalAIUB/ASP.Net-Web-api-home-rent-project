using ProjectEntity;
using ProjectInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectApi.Controllers
{
    [RoutePrefix("api/rentads")]
    public class RentAdController : ApiController
    {
        private IRentAdRepository repo;
        private IUserRepository UserRepo;

        public RentAdController(IRentAdRepository repo, IUserRepository userRepo)
        {
            this.repo = repo;
            UserRepo = userRepo;
        }
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }
        [Route("{id}", Name = "GetRentAdById")]
        public IHttpActionResult Get(int id)
        {
            RentAd rentAd = repo.Get(id);
            if (rentAd == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(rentAd);
        }
        [Route("{id}")]
        public IHttpActionResult post([FromUri]int id)
        {
            List<RentAd> r = repo.GetByUserId(id);
            if (r == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(r);
        }
        [Route("")]
        public IHttpActionResult Post(RentAd rentAd)
        {
            repo.Insert(rentAd);
            string uri = Url.Link("GetRentAdById", new { id = rentAd.Id });
            return Created(uri, rentAd);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromBody]RentAd rentAd,[FromUri]int id)
        {
            rentAd.Id = id;
            repo.Update(rentAd);
            return Ok(rentAd);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(this.repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
