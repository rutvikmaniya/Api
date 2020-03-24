using FirstApi.Domain;
using FirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FirstApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        UserDomain ud = new UserDomain();

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            ud.Post(user);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var user = ud.Get();
            return Ok(user);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ud.Delete(id);
              return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(User user,int id)
        {
            ud.Put(user,id);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetBy(int id)
        {
            var user = ud.GetBy(id);
            return Ok(user);
        }
        [HttpPatch]
        public IHttpActionResult Patch(int id)
        {
            ud.Patch(id);
            return Ok();
        }
    }
}
