using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csOCRD
    {
        public int Series { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public string LicTradNum { get; set; }
        public string Currency { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Cellular { get; set; }
        public string Fax { get; set; }
        public string E_Mail { get; set; }
        public string U_CAI { get; set; }
        public string U_Fecha_Vence_Cai { get; set; }

        List<csCRD1> ListDirec = new List<csCRD1>();
        List<csOCPR> ListCont = new List<csOCPR>();
    }
}