using ExpLINQ.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpLINQ.Controller
{
    public class EmployeesController : ControllerBase
    {// GET: emp  

        string db ="";
        public ActionResult Index()
        {
            IList<EmployeModel> employelist = new List<EmployeModel>();
            var query ="" //from qrs in db.Employees select qrs;
            var listdata = query.ToList();

            foreach (var employedata in listdata)
            {
                employelist.Add(new EmployeModel()
                {
                    id = employedata.id,
                    employename = employedata.EmpName,
                    employeaddress = employedata.EmpAddress,
                    employeemailid = employedata.EmpEmailId,
                });
            }
            return view();
        }
 
    }
}