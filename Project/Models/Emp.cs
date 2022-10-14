using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Emp
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }

        public string Email { get; set; }
        public int DeptCode { get; set; }

        public DateTime DOB { get; set; }
    }
}