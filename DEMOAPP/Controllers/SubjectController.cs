using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ILogger<SubjectController> _logger;
        private DemoContext _context;

        public SubjectController(ILogger<SubjectController> logger, DemoContext _context)
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

        public IActionResult SaveSubject(SubjectModel model)
        {
            try
            {
                using (DemoContext dbcontext = new DemoContext())
                {
                    var e = new Subject
                    {
                        SubId = model.Id,
                        SubName = model.Sub_Name,
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
