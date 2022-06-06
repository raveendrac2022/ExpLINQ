using DEMOAPP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{
    public class FxUploadController : Controller
    {
        private readonly ILogger<FxUploadController> _logger;
        private DemoContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _env;

        [Obsolete]
        public FxUploadController(ILogger<FxUploadController> logger, DemoContext _context, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
            this._context = _context;
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult FxUploadFile()
        {
            return View();
        }

        [Obsolete]
        [HttpPost]
        public IActionResult FxUploadFileSave(FillData model, IFormFile ATTACHMENT)
        {
            try
            {
                using (var dbcontext = new DemoContext())
                {

                    if (ATTACHMENT != null)
                    {
                        var filename = Guid.NewGuid() + "_" + ATTACHMENT.FileName;
                        string path = string.Empty;
                        path = $"{this._env.WebRootPath}/MasterDocuments/GlobalFiles";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        var filePaths = new List<string>();
                        string docPath = $"{path}/{filename}";
                        var filePath = Path.GetFullPath(path);
                        filePaths.Add(filePath);
                        using (var stream = new FileStream(docPath, FileMode.Create))
                        {
                            var f = ATTACHMENT;
                            f.CopyToAsync(stream);
                            model.FILE_PATH = $"/MasterDocuments/GlobalFiles/{filename}";
                        }
                        var e = new FillData
                        {
                            FILE_NAME = model.FILE_NAME,
                            FILE_PATH = model.FILE_PATH,
                            ATTACHMENT = filename,
                            CREATE_ON = DateTime.UtcNow.ToString()
                        };
                        //dbcontext.FillData.Add(e);
                        dbcontext.SaveChanges();
                    }
                    else
                    {
                        return Content("File not selected");
                    }
                }
            }
            catch (Exception ex) { }
            return RedirectToAction("FxUploadFile");

        }
    }
}
