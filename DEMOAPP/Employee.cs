using System;
using System.Collections.Generic;

#nullable disable

namespace DEMOAPP
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmailId { get; set; }
        public string DeptId { get; set; }
        public int? LocId { get; set; }
    }
}
