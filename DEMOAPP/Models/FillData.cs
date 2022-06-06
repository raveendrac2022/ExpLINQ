using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    public class FillData
    {
        public int ID { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public string ATTACHMENT { get; set; }
        public string CREATE_ON { get; set; }

        public FillData() {
            var fList = new List<FillData>();
        }
          

        //public IFormFile File { get; set; }
    }
}
