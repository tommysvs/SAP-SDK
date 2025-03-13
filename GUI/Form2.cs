using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using LN;

namespace GUI
{
    public partial class Form2 : Form
    {
        csSAP oSAP = new csSAP();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                csOITM objOITM = new csOITM();
                objOITM.Series = Int32.Parse(this.cmbSerieItem.Text);
                objOITM.ItemCode = this.txtCodItem.Text;
                objOITM.ItemName = this.txtDescItem.Text;
                objOITM.ItemGroupCode = Int32.Parse(this.cmbGrpItem.Text);
                objOITM.InventoryItem = this.chbInventario.Checked ? "Y" : "N";
                objOITM.PurchaseItem = this.chbCompra.Checked ? "Y" : "N";
                objOITM.SalesItem = this.chbVenta.Checked ? "Y" : "N";

                if(oSAP.AddItems(ref objOITM))
                {
                    MessageBox.Show("Articulo ingresado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                csOITM objOITM = new csOITM();
                objOITM.ItemCode = this.txtCodItem.Text;

                if(oSAP.GetItems(ref objOITM))
                {
                    this.cmbSerieItem.SelectedValue = objOITM.Series.ToString();
                    this.txtDescItem.Text = objOITM.ItemName;
                    this.cmbGrpItem.SelectedValue = objOITM.ItemGroupCode.ToString();
                    this.chbInventario.Checked = objOITM.InventoryItem == "Y" ? true : false;
                    this.chbCompra.Checked = objOITM.PurchaseItem == "Y" ? true : false;
                    this.chbVenta.Checked = objOITM.SalesItem == "Y" ? true : false;

                    MessageBox.Show("Articulo cargado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtCodItem.Text == "")
                {
                    throw new Exception("El código de artículo es obligatorio");
                }

                if(oSAP.DeleteItems(this.txtCodItem.Text))
                {
                    MessageBox.Show("Articulo eliminado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbTipoBP.SelectedIndex = 0;
                CargarCombos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarCombos()
        {
            try
            {
                CargarComboSerieArticulo();
                CargarComboGrupoArticulo();
                CargarComboSerieBP();
                CargarComboGrupoBP();
                CargarComboMonedaBP();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboSerieArticulo()
        {
            try
            {
                Globals.sQuery = "SELECT \"Series\", \"SeriesName\" FROM NNM1 WHERE \"ObjectCode\" = 4 AND \"Locked\" = 'N'";

                if (Globals.isHANA)
                {
                    Globals.dtResult = csConexion.EjecutarHANA(Globals.sQuery);
                }
                else
                {
                    Globals.dtResult = csConexion.EjecutarSQL(Globals.sQuery);
                }

                Globals.LoadCombo(Globals.dtResult, ref cmbSerieItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboGrupoArticulo()
        {
            try
            {
                Globals.sQuery = "SELECT \"ItmsGrpCod\", \"ItmsGrpNam\" FROM OITB";
                
                if(Globals.isHANA)
                {
                    Globals.dtResult = csConexion.EjecutarHANA(Globals.sQuery);
                }else
                {
                    Globals.dtResult = csConexion.EjecutarSQL(Globals.sQuery);
                }

                Globals.LoadCombo(Globals.dtResult, ref cmbGrpItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboSerieBP()
        {
            try
            {
                Globals.sQuery = "SELECT \"Series\", \"SeriesName\" FROM NNM1 WHERE \"ObjectCode\" = 2 AND \"Locked\" = 'N'";

                if (Globals.isHANA)
                {
                    Globals.dtResult = csConexion.EjecutarHANA(Globals.sQuery);
                }
                else
                {
                    Globals.dtResult = csConexion.EjecutarSQL(Globals.sQuery);
                }

                Globals.LoadCombo(Globals.dtResult, ref cbSerieBP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboGrupoBP()
        {
            try
            {
                string Tipo = this.cbTipoBP.SelectedIndex == 1 ? "S" : "C";

                Globals.sQuery = "SELECT \"GroupCode\", \"GroupName\" FROM OCRG WHERE \"GroupType\" = '" + Tipo + "'";

                if (Globals.isHANA)
                {
                    Globals.dtResult = csConexion.EjecutarHANA(Globals.sQuery);
                }
                else
                {
                    Globals.dtResult = csConexion.EjecutarSQL(Globals.sQuery);
                }

                Globals.LoadCombo(Globals.dtResult, ref cbGrupoBP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboMonedaBP()
        {
            try
            {
                Globals.sQuery = "SELECT '##' \"CurrCode\", 'TODAS' \"CurrName\" FROM DUMMY \n";
                Globals.sQuery += "UNION \n";
                Globals.sQuery += "SELECT \"CurrCode\", \"CurrName\" FROM OCRN \n";

                if (Globals.isHANA)
                {
                    Globals.dtResult = csConexion.EjecutarHANA(Globals.sQuery);
                }
                else
                {
                    Globals.dtResult = csConexion.EjecutarSQL(Globals.sQuery);
                }

                Globals.LoadCombo(Globals.dtResult, ref cbMonedaBP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbTipoBP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarComboGrupoBP();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                csOCPR objCont;
                csCRD1 objDirecc;
                csOCRD objBP = new csOCRD();

                objBP.Series = Int32.Parse(this.cbSerieBP.SelectedValue.ToString());
                objBP.CardType = this.cbTipoBP.SelectedIndex == 0 ? "C" : 
                                 this.cbTipoBP.SelectedIndex == 1 ? "S" : "L";
                objBP.CardName = this.txtNombreBP.Text;
                objBP.LicTradNum = this.txtRTNBP.Text;
                objBP.GroupCode = Int32.Parse(this.cbGrupoBP.SelectedValue.ToString());
                objBP.Currency = this.cbMonedaBP.SelectedValue.ToString();
                objBP.U_CAI = "abc";
                objBP.U_Fecha_Vence_Cai = "20251303";

                objCont = new csOCPR();
                objCont.Name = "Cont1";
                objCont.FirstName = "Tom1";
                objBP.ListCont.Add(objCont);

                objCont = new csOCPR();
                objCont.Name = "Cont2";
                objCont.FirstName = "Tom2";
                objBP.ListCont.Add(objCont);

                objDirecc = new csCRD1();
                objDirecc.Address = "FISCAL";
                objDirecc.Address2 = "Avenida Vega 355";
                objDirecc.Country = "HN";
                objDirecc.AdresType = "B";
                objBP.ListDirec.Add(objDirecc);

                objDirecc = new csCRD1();
                objDirecc.Address = "ALMACEN";
                objDirecc.Address2 = "Avenida Alonzo 877";
                objDirecc.Country = "HN";
                objDirecc.AdresType = "S";
                objBP.ListDirec.Add(objDirecc);

                if(oSAP.AddBusinessPartners(ref objBP))
                {
                    this.txtCodigoBP.Text = objBP.CardCode;
                    MessageBox.Show("Socio de negocios creado con éxito");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
