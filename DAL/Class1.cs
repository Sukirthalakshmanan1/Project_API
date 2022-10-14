using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpProfile
    {
        [Key]
        [Required]
        public int EmpCode { get; set; }
        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string EmpName { get; set; }

        public string Email{ get; set; }

        public int DeptCode{ get; set; }

        public DateTime DateOfBirth { get; set; }

        //1 Book---M Enrollments(members)
        public virtual ICollection<DeptMaster> I { get; set; }
        //  [DataType(DataType.DateTime,ErrorMessage ="not valid date")]


    }

    public class DeptMaster
    {
        [Key]
        [Required]
        public int DeptCode { get; set; }
        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string DeptName { get; set; }

      

        //1 Book---M Enrollments(members)
        public virtual ICollection<EmpProfile> e { get; set; }
        //  [DataType(DataType.DateTime,ErrorMessage ="not valid date")]


    }

    public class MyContext1 : DbContext
    {
        public MyContext1() : base("MyContext1")
        {
            //createdatabase if not exists
            //drop create always
            //drop create if model changes

            Database.SetInitializer<MyContext1>(new DropCreateDatabaseIfModelChanges<MyContext1>());
        }

        public virtual DbSet<EmpProfile> EmpTable { get; set; }

        public virtual DbSet<DeptMaster> DeptTable { get; set; }


    }
}

