using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private DemoContext _context;

        public DepartmentController(ILogger<DepartmentController> logger, DemoContext _context)
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
        public IActionResult SaveDepartment(DepartmentModel model)
        {
            try
            {
                using (DemoContext dbcontext = new DemoContext())
                {
                    var e = new Department
                    {
                        DeptId = model.DeptId,
                        DeptName = model.DeptName,
                        Remark = model.Remark
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
