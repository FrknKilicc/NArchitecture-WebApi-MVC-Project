using MVCLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class MVCEnrollmentController : Controller
    {
        // GET: MVCEnrollment
        public ActionResult Index()
        {
            IEnumerable<EnrollmentMVC> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Enrollments").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<EnrollmentMVC>>().Result;
            return View(responseList);
        }
        public ActionResult AdUp(int id = 0)
        {
            if (id == 0)
            {
                return View(new EnrollmentMVC());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Enrollments/" + id.ToString()).Result;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AdUp(EnrollmentMVC save)
        {
            if (save.EnrollmentID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Enrollments", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Enrollments" + save.CourseID, save).Result;
            }
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Enrollments" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}