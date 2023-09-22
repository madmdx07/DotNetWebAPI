using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DotNetWebAPI.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public Nullable<int> GenderId { get; set; } 
        public string Address { get; set; } 
        public int ClassId { get; set; }
        public string Phone { get; set; } 
        [DisplayName("Photo")]
        public Nullable<int> ImageId { get; set; }
        public string Hobbies { get; set; }
        public Nullable<DateTime> RegisteredDate { get; set; }
        public List<Dropdown> ClassList { get; set; }
        public List<Dropdown> GenderList { get; set; }

        [DisplayName("Hobbies")]
        public List<HobbyViewModel> hobbyModel { get; set; }
    }

    public class HobbyViewModel
    {
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public bool IsActive { get; set; }
    }

    public class MappingViewModel
    {
        public int MapId { get; set; }
        public int StudentId { get; set; }
        public int HobbyId { get; set; }
    }

    public class Dropdown
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}