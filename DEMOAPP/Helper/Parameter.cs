using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Helper
{
    
    public struct Parameter
    {
        public string ParameterName { get; set; }
        public ParameterDirection Direction { get; set; }
        public DbType DbType { get; set; }
        public object Value { get; set; }
        public string SourceColumn { get; set; }
        public int Size { get; set; }
    }
}
