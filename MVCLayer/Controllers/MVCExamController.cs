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
    public class MVCExamController : Controller
    {
        // GET: MVCExam
        public ActionResult Index()
        {
            IEnumerable<ExamMVC> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Exams").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<ExamMVC>>().Result;
            return View(responseList);

        }

        public ActionResult AdUp(int id = 0)
        {
            if (id == 0)
            {
                return View(new ExamMVC());

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Exams/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ExamMVC>().Result);
            }

        }
        [HttpPost]
        public ActionResult AdUp(ExamMVC save)
        {
            if (save.ExamID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Exams", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Exams" + save.ExamID, save).Result;

            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Exams" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}