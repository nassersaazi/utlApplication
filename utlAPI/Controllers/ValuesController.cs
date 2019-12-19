using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using utlAPI.DataAccess;
using utlAPI.Models;

namespace utlAPI.Controllers
{
    public class ValuesController : ApiController
    {
        UTLdb dblayer = new UTLdb();
        
        [HttpPost]
        [Route("api/AddAgent")]
        public IHttpActionResult AddAgent([FromBody]Agents ag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.AddAgent(ag);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something went wrong"); ;
            }
        }


        [HttpPost]
        [Route("api/AddAdmin")]
        public IHttpActionResult AddAdmin([FromBody]Admins adm)
        {
            try
          {
               if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.AddAdmin(adm);
                return Ok("Success");
           }
            catch (Exception)
            {

                return Ok("Something went wrong"); ;
            }
        }

        [HttpPost]
        [Route("api/RequestFloat")]
        public IHttpActionResult RequestFloat([FromBody]FloatRequests fr)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //dblayer.RequestFloat(fr);
                dblayer.RequestFloatsToQueue(fr);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something went wrong"); ;
            }
        }


        [HttpGet]
        [Route("api/GetPendingFloatRequests")]
        public IHttpActionResult Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var fr = dblayer.GetFloatRequests();
                return Ok(fr);
            }
            catch (Exception)
            {

                return Ok("Something went wrong"); ;
            }
        }

        [HttpGet]
        [Route("api/GetAgentDetails")]
        public IHttpActionResult GetAgentDetails(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var fr = dblayer.GetAgentDetails(id);
                return Ok(fr);
            }
            catch (Exception)
            {

                return Ok("Something went wrong"); ;
            }
        }


    }
}
