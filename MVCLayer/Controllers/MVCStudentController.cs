using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using MVCLayer.Models;


namespace MVCLayer.Controllers
{
    public class MVCStudentController : Controller
    {
        // GET: MVCStudent
        public ActionResult Index()
        {
            IEnumerable<MVCStudents> responseList;

            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Students").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<MVCStudents>>().Result;
            return View(responseList);

        }
        public ActionResult AdUp(int id = 0)
        {
            if (id == 0)
            {
                return View(new MVCStudents());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Students/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCStudents>().Result);
            }

        }
        [HttpPost]
        public ActionResult AdUp(MVCStudents save)
        {
            if (save.StudentID == 0)
            {

                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Students", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Students" + save.StudentID, save).Result;
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete (int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Students" + id.ToString()).Result;
            return RedirectToAction("index");
        }
    }
}