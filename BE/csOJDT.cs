using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csOJDT
    {
        public int? JdtNum { get; set; }
        public string RefDate { get; set; }
        public string DueDate { get; set; }
        public string TaxDate { get; set; }
        public string Memo { get; set; }
        public string Indicator { get; set; }
        public string Project { get; set; }
        public string Transcode { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }

        public List<csJDT1> ListDet = new List<csJDT1>();
    }
}
