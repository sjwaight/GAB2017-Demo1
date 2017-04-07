using SiliconValve.Gab2017.DemoWeb.Models;
using SiliconValve.Gab2017.DemoWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SiliconValve.Gab2017.DemoWeb.Controllers
{
    public class PostcodeController : ApiController
    {
        [HttpGet]
        [Route("api/postcode/{postcode}")]
        public IHttpActionResult Get(string postcode)
        {
            if (string.IsNullOrEmpty(postcode))
            {
                return BadRequest();
            }

            var result =  PostCodeDataStore.Instance.Where(pc => pc.PostCode == postcode);

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/postcode/state/{state}")]
        public IHttpActionResult GetByState(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                return BadRequest();
            }

            var result = PostCodeDataStore.Instance.Where(pc => pc.State.Equals(state, StringComparison.InvariantCultureIgnoreCase));

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/postcode/suburb/{suburb}")]
        public IHttpActionResult GetBySuburb(string suburb)
        {
            if (string.IsNullOrEmpty(suburb))
            {
                return BadRequest();
            }

            var result = PostCodeDataStore.Instance.Where(pc => pc.Suburb.Contains(suburb.ToUpper()));

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}