using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpOperation
    {
       

        public bool DeleteEmployeeDetails(int id)
        {
            try
            {
                MyContext1 context = new MyContext1();

                List<EmpProfile> s = context.EmpTable.ToList();
                EmpProfile r = s.Find(pr => pr.EmpCode == id);

                context.EmpTable.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public BLClass1 search(int id)
        {
            MyContext1 context = new MyContext1();
            List<EmpProfile> customers = context.EmpTable.ToList();
            EmpProfile obj = customers.Find(cust => cust.EmpCode == id);

            // List<BLClass1> cblist = new List<BLClass1>();
            BLClass1 b = new BLClass1();
            b.EmpName = obj.EmpName;
            b.EmpCode = obj.EmpCode;
            b.Email=obj.Email;
            b.DeptCode=obj.DeptCode;
            b.DOB = obj.DateOfBirth;


            return b;

            //context.SaveChanges();
        }

        public bool Insert(BLClass1 bal)
        {
            try
            {
                MyContext1 context = new MyContext1();

                EmpProfile b = new EmpProfile();
                b.EmpCode = bal.EmpCode;
                b.EmpName = bal.EmpName;
                b.Email = bal.Email;
                b.DeptCode = bal.DeptCode;
                b.DateOfBirth = bal.DOB;
                context.EmpTable.Add(b);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public bool Update(BLClass1 bal)
        {
            try
            {
                MyContext1 context = new MyContext1();
                List<EmpProfile> customers = context.EmpTable.ToList();
                EmpProfile obj = customers.Find(cust => cust.EmpCode == bal.EmpCode);
                obj.EmpName = bal.EmpName;
                obj.Email = bal.Email;
                obj.DeptCode = bal.DeptCode;
                obj.DateOfBirth = bal.DOB;

                // context.Updatebookdetails();
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

       
        public List<BLClass1> GetAll()
        {
            MyContext1 context = new MyContext1();

            List<EmpProfile> clist = context.EmpTable.ToList();
            List<BLClass1> cblist = new List<BLClass1>();
            foreach (var item in clist)
            {
                cblist.Add(new BLClass1 { EmpCode=item.EmpCode,EmpName=item.EmpName,Email=item.Email,DeptCode=item.DeptCode,DOB=item.DateOfBirth });



            }
            return cblist;




        }


    }
}
