using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


namespace DEMOAPP.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private DemoContext _context;

        public BookController(ILogger<BookController> logger, DemoContext _context)
        {
            _logger = logger;
            this._context = _context;
        }
        public IActionResult Index()
        {
            EmployeeList model = new EmployeeList();
            return View(model);
        }
        public IActionResult Create()
        {
            BookModel model = new BookModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BookModel model)
        {
            try
            {
                using (DemoContext dbcontext = new DemoContext())
                {
                    dbcontext.Database.OpenConnection();
                    DbCommand cmd = dbcontext.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = "sp_ManageBooks";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbDataReader sqlReader;

                    DbParameter[] parametes = new DbParameter[] { };
                    var parameters = new[]{
                    new SqlParameter(){ ParameterName="@BOOK_NAME", Value=model.BOOK_NAME },
                    new SqlParameter(){ ParameterName="@AUTHER", Value=model.AUTHER },
                    new SqlParameter(){ ParameterName="@PRICE", Value=model.PRICE }
                    };
                    cmd.Parameters.AddRange(parameters);
                    sqlReader = cmd.ExecuteReader();
                    if (sqlReader != null)
                    {
                        string a = "Record Save";
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveRecord(BookModel model)
        {
            try
            {
                using (DemoContext dbcontext = new DemoContext())
                {
                    DbDataReader sqlReader;
                    dbcontext.Database.OpenConnection();
                    DbCommand cmd = dbcontext.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = "sp_ManageBooks";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter param = cmd.CreateParameter();
                    param.ParameterName = "@BOOK_NAME";
                    param.Value = model.BOOK_NAME;
                    cmd.Parameters.Add(param);
                    DbParameter param1 = cmd.CreateParameter();
                    param1.ParameterName = "@AUTHER";
                    param1.Value = model.AUTHER;
                    cmd.Parameters.Add(param1);
                    DbParameter param2 = cmd.CreateParameter();
                    param2.ParameterName = "@PRICE";
                    param2.Value = model.AUTHER;
                    cmd.Parameters.Add(param2);
                    sqlReader = cmd.ExecuteReader();
                    if (sqlReader != null)
                    {
                        string a = "Record Save";
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public IActionResult bookList()
        {
            using (DemoContext dbcontext = new DemoContext())
            {
                IEnumerable<EmployeeList> model = (from e in dbcontext.Employees
                                                   select new EmployeeList
                                                   {
                                                       id = e.Id,
                                                       EmpName = e.EmpName,
                                                       EmpEmailId = e.EmpEmailId,
                                                       EmpAddress = e.EmpAddress
                                                   }).OrderBy(x => x.EmpName).ToList();
                return Json(new { data = model });
            }
        }
    }
}
