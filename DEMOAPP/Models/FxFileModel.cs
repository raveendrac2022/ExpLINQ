using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    public class FxFileModel
    {
        public int ID { get; set; }
        public string X_FILE_NAME { get; set; }
        public string X_FILE_PATH { get; set; }
        public string X_CREATE_ON { get; set; }
    }
}
