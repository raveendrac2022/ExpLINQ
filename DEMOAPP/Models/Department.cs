using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    [Keyless]
    public class Department
    {
        public int DEPT_ID { get; set; }
        public string DEPT_NAME { get; set; }
    }
}
