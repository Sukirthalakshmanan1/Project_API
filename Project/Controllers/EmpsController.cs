using BLL;
using DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace Project.Controllers
{
    public class EmpsController : ApiController
    {
        // GET api/<controller>

        EmpOperation obj = null;
        public EmpsController()
        {
            obj = new EmpOperation();
        }

        // [Route("GetAllMarks")]
        [HttpGet]
        public List<Emp> GetMarkList()
        {
            //sub_mark --model
            //BLclass1
            List<BLClass1> empbal = new List<BLClass1>();
            empbal = obj.GetAll();
            List<Emp> emps = new List<Emp>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new Emp { EmpCode = item.EmpCode, EmpName = item.EmpName, Email = item.Email, DeptCode = item.DeptCode, DOB = item.DOB });
            }
            return emps;

        }






        // GET api/<controller>/5
        // [Route("~/FindE/{id}")]
        //  [Route("FindById/{id:int:min(1)}")]

        [Route("FindById/{id:int?}")]
        public Emp GetMarkByID(int id)
        {
            BLClass1 empbal = new BLClass1();
            empbal = obj.search(id);
            Emp emp = new Emp();
            //emp.Id = empbal.Id;
            emp.EmpCode= id;
            emp.EmpName = empbal.EmpName;
            emp.Email = empbal.Email;
            emp.DeptCode = empbal.DeptCode;
            emp.DOB = empbal.DOB;

            return emp;

        }

        // POST api/<controller>
        public HttpResponseMessage PostMarks([FromBody] Emp empdata)
        {
            BLClass1 empbal = new BLClass1();
            empbal.EmpCode = empdata.EmpCode;
            empbal.EmpName = empdata.EmpName;
            empbal.Email = empdata.Email;
            empbal.DeptCode = empdata.DeptCode;
            empbal.DOB = empdata.DOB;


            bool ans = obj.Insert(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        // PUT api/<controller>/5
        public HttpResponseMessage PutMarks([FromBody] Emp empdata)
        {

           BLClass1 empbal = new BLClass1();
            empbal.EmpCode= empdata.EmpCode;
            empbal.EmpName = empdata.EmpName;
            empbal.Email = empdata.Email;
            empbal.DeptCode= empdata.DeptCode;
            empbal.DOB=empdata.DOB;


            bool ans = obj.Update(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            bool ans = obj.DeleteEmployeeDetails(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }
    }
}