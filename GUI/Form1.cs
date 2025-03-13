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
    public partial class Form1 : Form
    {
        public csSAP oSAP = new csSAP();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                csCompany objCompany = new csCompany();
                objCompany.ServerBD = this.txtServerBD.Text;
                objCompany.UserBD = this.txtUserBD.Text;
                objCompany.PwBD = this.txtPassBD.Text;
                objCompany.ServerLic = this.txtServerLic.Text;
                objCompany.NameBD = this.txtNombreBD.Text;
                objCompany.UserSAP = this.txtUserSAP.Text;
                objCompany.PwSAP = this.txtPassSAP.Text;
                objCompany.ServerType = this.cmbTipoServer.SelectedIndex;

                if(oSAP.ConectarSAP(objCompany))
                {
                    MessageBox.Show("Conexión exitosa");

                    if(this.cmbTipoServer.SelectedIndex == 0)
                    {
                        string Server = this.txtServerBD.Text.Replace("NDB@", "").Replace("30013", "30015");

                        //HANA
                        csConexion.IniciarConexionHANA(Server, this.txtUserBD.Text, this.txtPassBD.Text, this.txtNombreBD.Text);
                        Globals.isHANA = true;
                    }else
                    {
                        //SQL
                        csConexion.IniciarConexionSQL(this.txtServerBD.Text, this.txtUserBD.Text, this.txtPassBD.Text, this.txtNombreBD.Text);
                    }
                    
                    Form2 oForm2 = new Form2();
                    oForm2.Show();
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
                csCompany objCompany = new csCompany();

                if (oSAP.DesconectarSAP(objCompany))
                {
                    MessageBox.Show("Conexión exitosa");
                }else
                {
                    MessageBox.Show("Conexión cerrada");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
