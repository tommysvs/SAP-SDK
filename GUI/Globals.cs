using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public class Globals
    {
        public static bool isHANA = false;
        public static string sQuery = "";
        public static DataTable dtResult;

        public static void LoadCombo(DataTable dt, ref ComboBox Combo)
        {
            Combo.DataSource = dt;
            Combo.DisplayMember = dt.Columns[1].Caption;
            Combo.ValueMember = dt.Columns[0].Caption;

            if(dt.Rows.Count > 0)
            {
                Combo.SelectedIndex = 0;
            }
        }

        public static DateTime ToDate(string sFecha)
        {
            try
            {
                //20250313
                //01234567

                DateTime dt = DateTime.Parse(sFecha.Substring(6, 2) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(0, 4));

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
