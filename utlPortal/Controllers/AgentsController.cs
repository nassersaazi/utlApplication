using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using utlAPI.Models;

namespace utlPortal.Controllers
{
    public class AgentsController : Controller
    {
        // GET: Agents
        public ActionResult Index()
        {
            string url = "http://localhost:50416/api/GetPendingFloatRequests";
            var client = new WebClient();

            //object serialised as json string
            var content = client.DownloadString(url);

            //object deserialised as ModelClass
            var model = JsonConvert.DeserializeObject<List<FloatRequests>>(content);
       
            return View("Index", model);

        
        }

        // GET: Agents/Details/5
        
        public ActionResult Details(int id)
        {
            try
            {
                string url = "http://localhost:50416/api/GetAgentDetails?id=" + id;
                var client = new WebClient();

                //object serialised as json string
                var content = client.DownloadString(url);

                //object deserialised as ModelClass
                var model = JsonConvert.DeserializeObject<Agents>(content);

                return View("Details", model);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            
        }

        //// GET: Agents/Validate
        //public ActionResult Validate(int id)
        //{
        //    return View();
        //}

        

        // GET: Agents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agents/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
