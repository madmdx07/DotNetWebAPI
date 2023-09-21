using DotNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetWebAPI.Controllers
{
    public class StudentController : ApiController
    {
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
    }
}
