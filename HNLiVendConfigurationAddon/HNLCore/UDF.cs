using CXS.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNLCore
{
    public class UDF
    {
        public string nameUDT { get; set; }
        public string nameUDF { get; set; }
        public string desciptionUDF { get; set; }
        public UserDefinedFieldDataType UDFType { get; set; }
        public int lengthUDF { get; set; }

        public List<UDFValidValue> uDFValidValues { get; set; }
    }

    public class UDFValidValue
    {
        public string id { get; set; }
        public string description { get; set; }
    }
}
