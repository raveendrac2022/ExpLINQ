using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;
        private DemoContext _context;

        public MyController(ILogger<MyController> logger, DemoContext _context)
        {
            _logger = logger;
            this._context = _context;
        }

        public IActionResult Index()
        {
            using (DemoContext dbcontext = new DemoContext())
            {
                IEnumerable<EmployeeDetails>
                    model = (from e in dbcontext.Employees
                             join d in dbcontext.Departments on e.DeptId equals d.DeptId.ToString()
                             join l in dbcontext.Locations on e.LocId equals l.LocId
                             select new EmployeeDetails
                             {
                                 id = e.Id,
                                 EmpName = e.EmpName,
                                 EmpEmailId = e.EmpEmailId,
                                 EmpAddress = e.EmpAddress,
                                 DEPT_NAME = d.DeptName,
                                 LOC_NAME = l.LocName
                             }).OrderBy(x => x.EmpName).ToList();
                return View(model);
            };
        }
        public IActionResult AddEditCustomer(int id)
        {
            Employee e = new Employee();
            if (id > 0)
            {
                using (DemoContext dbcontext = new DemoContext())
                {

                    ViewBag.DeptList = dbcontext.Set<Department>().ToList().Select(s => new Department
                    {
                        DeptId = s.DeptId,
                        DeptName = s.DeptName
                    });
                    e = dbcontext.Employees.Where(val => val.Id == id).Select(val => new Employee()
                    {
                        Id = val.Id,
                        EmpName = val.EmpName,
                        EmpAddress = val.EmpAddress,
                        EmpEmailId = val.EmpEmailId,
                        DeptId = val.DeptId
                    }).SingleOrDefault();
                }
            }
            return View(e);
        }
        public IActionResult AddCustomer()
        {
            EmployeeModel emps = new EmployeeModel();
            using (var dbcontext = new DemoContext())
            {
                ViewBag.DeptList = dbcontext.Set<Department>().ToList().Select(s => new Department
                {
                    DeptId = s.DeptId,
                    DeptName = s.DeptName
                });
            }
            return View(emps);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {

                using (DemoContext dbcontext = new DemoContext())
                {

                    if (model.id > 0)
                    {
                        var e = dbcontext.Employees.Where(val => val.Id == model.id).Single<Employee>();
                        e.Id = model.id;
                        e.EmpName = model.EmpName;
                        e.EmpAddress = model.EmpAddress;
                        e.EmpEmailId = model.EmpEmailId;
                        e.DeptId = Convert.ToString(model.Dept_Id);
                        dbcontext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var e = new Employee
                        {
                            Id = model.id,
                            EmpName = model.EmpName,
                            EmpAddress = model.EmpAddress,
                            EmpEmailId = model.EmpEmailId,
                            DeptId = Convert.ToString(model.Dept_Id),
                            LocId = 1
                        };
                        dbcontext.Add(e);
                        dbcontext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public ActionResult RecordDelete(Employee model)
        {
            try
            {
                using (var dbcontext = new DemoContext())
                {
                    var emp = dbcontext.Employees.Where(val => val.Id == model.Id).Single<Employee>();
                    dbcontext.Employees.Remove(emp);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }
    }
}
