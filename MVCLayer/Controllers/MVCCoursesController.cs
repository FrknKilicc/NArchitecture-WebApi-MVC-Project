using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using MVCLayer.Models;
using System.Xml.Linq;

namespace MVCLayer.Controllers
{
    public class MVCCoursesController : Controller
    {
        // GET: MVCCourses
        public ActionResult Index()
        {
            IEnumerable<CoursesMVC> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Cours").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<CoursesMVC>>().Result;
            return View(responseList);

        }



        public ActionResult AdUp(int id = 0)
        {
            if (id == 0)
            {
                return View(new CoursesMVC());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Cours/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CoursesMVC>().Result);

            }
        }
        [HttpPost]
        public ActionResult AdUp(CoursesMVC save)
        {
            if (save.CourseID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Cours", save).Result;

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Cours" + save.CourseID, save).Result;
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete (int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Cours" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}