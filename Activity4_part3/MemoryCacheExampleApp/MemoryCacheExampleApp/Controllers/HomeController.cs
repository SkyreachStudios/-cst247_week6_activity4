using MemoryCacheExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MemoryCacheExampleApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult getUsers()
        {
            var cache = MemoryCache.Default;
            List<UserModel> users = new List<UserModel>();
            users = (List<UserModel>)cache.Get("users");
            if(users == null)
            {
                users = new List<UserModel>();
                users.Add(new UserModel("Crystal", "pass1"));
                users.Add(new UserModel("Michael", "pass2"));
                users.Add(new UserModel("Lily", "pass3"));
                users.Add(new UserModel("Rogan", "pass4"));
                System.Diagnostics.Debug.WriteLine("There were no users in the cache. The data was populated from a data set. (Slowly) create at " + DateTime.Now + ".");
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(1);
                cache.Set("users", users, policy);

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("The users were in the cache. No data was create at runtime on " + DateTime.Now + ".");
                //the users were in the cache
            }
        

            return Content(new JavaScriptSerializer().Serialize(users));
        }
    }
}