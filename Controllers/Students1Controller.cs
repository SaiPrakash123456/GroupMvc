using GroupApiInMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GroupApiInMVC.Controllers
{
    public class Students1Controller : Controller
    {
        // GET: Students1
        public ActionResult Index()
        {
            IEnumerable<StudentDetails> stddata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<StudentDetails>>(json);
                stddata = list.ToList();
                return View(stddata);
            }
        }

        // GET: Students1/Details/5
        public ActionResult Details(int id)
        {
            StudentDetails stddata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";
                var json = webClient.DownloadString("Students/" + id);
                stddata = JsonConvert.DeserializeObject<StudentDetails>(json);
            }
            return View(stddata);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students1/Create
        [HttpPost]
        public ActionResult Create(StudentDetails model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44344/api/";
                    var url = "Students/POST";
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<StudentDetails>(response);

                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDetails stddata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Students/" + id);

                stddata = JsonConvert.DeserializeObject<StudentDetails>(json);
            }
            return View(stddata);
        }

        // POST: Students1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentDetails model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44344/api/Students/"+id;

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);

                    StudentDetails modeldata = JsonConvert.DeserializeObject<StudentDetails>(response);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(int id)
        {
            StudentDetails Stddata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                Stddata = JsonConvert.DeserializeObject<StudentDetails>(json);
            }
            return View(Stddata);
        }

        // POST: Students1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentDetails model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();

                    string url = "https://localhost:44344/api/Students/" + id;

                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
