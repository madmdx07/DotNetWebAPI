using DotNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace DotNetWebAPI.Controllers.ApiControllers
{
    public class StudentApiController : ApiController
    {
        public StudentApiController() { }

        private Entities  db = new Entities();
        public IHttpActionResult GetStudent()
        {
            var students = (from st in db.tblStudents
                            select new StudentViewModel
                            {
                                Id = st.Id,
                                Name = st.Name,
                                Address = st.Address,
                                Phone = st.Phone,
                            }).ToList();

            if (students.Count() == 0) 
                return NotFound();

            return Ok(students);
        }

        //[Route("api/StudentApi/Create")]
        //[HttpPost]
        public HttpResponseMessage PostCreate(StudentViewModel student)
        {
                //to concat hobbies
            //    StringBuilder hobbies = new StringBuilder();
            //    foreach (var hobby in student.hobbyModel)
            //    {
            //        if (hobby.IsActive)
            //        {
            //            hobbies.Append(hobby.HobbyName + ", ");
            //        }
            //    }
            //    hobbies.Remove(hobbies.ToString().LastIndexOf(","), 1);
            //student.Hobbies = hobbies.ToString();

            db.tblStudents.Add(new tblStudent()
            {
            //    Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Phone = student.Phone,
                GenderId = student.GenderId,
                ClassId = student.ClassId,
                //ImageId = student.ImageId,
                //Hobbies = student.Hobbies,
                RegisteredDate = student.RegisteredDate,
            });

            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, student);
        }
    }
}
