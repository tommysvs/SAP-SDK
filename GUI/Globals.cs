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
    }
}
