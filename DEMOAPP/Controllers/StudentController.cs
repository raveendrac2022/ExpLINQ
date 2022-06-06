using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private DemoContext _context;

        public StudentController(ILogger<StudentController> logger, DemoContext _context)
        {
            _logger = logger;
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveStudent(EmployeeModel model)
        {
            try
            {

                using (DemoContext dbcontext = new DemoContext())
                {
                    var e = new Student
                    {
                        Id = model.id,
                        EmpName = model.EmpName,
                        EmpAddress = model.EmpAddress,
                        EmpEmailId = model.EmpEmailId
                    };
                    dbcontext.Add(e);
                    dbcontext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
