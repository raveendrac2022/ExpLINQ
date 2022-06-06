using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    public class StudentModel
    {
        public int SID { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string CONTACT { get; set; }

    }
    public class ddlStudentModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }

    }

    public class StudentInfo
    {
        public List<ddlStudentModel> ddlStundet { get; set; }
        public List<StudentModel> StundetList { get; set; }

        public StudentInfo()
        {
            ddlStundet = new List<ddlStudentModel>();
            StundetList = new List<StudentModel>();
        }
    }
}
