using DEMOAPP.Helper;
using DEMOAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class UseProcedureController : Controller
    {
        public IActionResult Index()
        {
            var ds = new DataSet();
            StudentInfo model = new StudentInfo();
            using (DemoContext dbcontext = new DemoContext())
            {
                dbcontext.Database.OpenConnection();
                DbCommand cmd = dbcontext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "USP_STUDENT";
                cmd.CommandType = CommandType.StoredProcedure;
                DbParameter[] parametes = new DbParameter[] { };
                var parameters = new[]{
                    new SqlParameter(){ ParameterName="@FLAG", Value="S" }
                };
                cmd.Parameters.AddRange(parameters);
                using (DbDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    model.StundetList = CommonMethod.ConvertToList<StudentModel>(ds.Tables[0]);
                    model.ddlStundet= CommonMethod.ConvertToList<ddlStudentModel>(ds.Tables[1]);
                }
            }
            return View(model);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        public IActionResult Create(StudentModel model)
        {
            try
            {
                using (DemoContext dbcontext = new DemoContext())
                {
                    dbcontext.Database.OpenConnection();
                    DbCommand cmd = dbcontext.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = "USP_STUDENT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbDataReader sqlReader;

                    DbParameter[] parametes = new DbParameter[] { };
                    var parameters = new[]{
                    new SqlParameter(){ ParameterName="@FLAG", Value="I" },
                    new SqlParameter(){ ParameterName="@ID", Value=model.SID },
                    new SqlParameter(){ ParameterName="@NAME", Value=model.NAME },
                    new SqlParameter(){ ParameterName="@EMAIL", Value=model.EMAIL},
                    new SqlParameter(){ ParameterName="@CONTACT", Value=model.CONTACT}
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
    }

}
