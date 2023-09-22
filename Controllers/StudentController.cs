using DotNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DotNetWebAPI.Controllers
{
    public class StudentController : Controller
    {
        Entities db = new Entities();

        // GET: Student/Index
        public ActionResult Index()
        {
            var student = (from st in db.tblStudents
                           select new StudentViewModel
                           {
                               Id = st.Id,
                               Name = st.Name,
                               GenderId = st.GenderId,
                               Phone = st.Phone,
                               Address = st.Address,
                               RegisteredDate = st.RegisteredDate,
                               ClassId = st.ClassId,
                               ImageId = st.ImageId,
                               Hobbies = st.Hobbies,
                           }).ToList();

            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentViewModel imodel = new StudentViewModel();
            imodel.ClassList = db.tblClasses.Select(x => new Dropdown
            {
                Id = x.ClassId,
                Value = x.Grade.ToString(),
            }).ToList();

            imodel.GenderList = db.tblGenders.Select(x => new Dropdown
            {
                Id = x.GenderId,
                Value = x.GenderName,
            }).ToList();

            imodel.hobbyModel = (from h in db.tblHobbies
                                 select new HobbyViewModel
                                 {
                                     HobbyId = h.HobbyId,
                                     HobbyName = h.HobbyName,
                                     IsActive = h.IsActive,
                                 }).ToList();
            imodel.RegisteredDate = DateTime.Now;
            return View(imodel);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel imodel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/StudentApi");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentViewModel>("StudentApi", imodel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(imodel);
        }
    }
}