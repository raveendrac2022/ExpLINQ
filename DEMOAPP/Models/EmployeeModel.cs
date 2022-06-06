using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    public class EmployeeModel
    {

        public int id { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string EmpAddress { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string EmpEmailId { get; set; }
        [Required(ErrorMessage = "Enter Department")]
        [Display(Name = "Department")]
        public int Dept_Id { get; set; }
    }

    public class EmployeeList
    {

        public int id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmailId { get; set; }
    }

}
