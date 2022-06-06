using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    //[Keyless]
    public class EmployeeDetails
    {
        public int id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmailId { get; set; }
        public string DEPT_NAME { get; set; }
        public string LOC_NAME { get; set; }

    }
}
