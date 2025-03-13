
namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServerBD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserBD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassBD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerLic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreBD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserSAP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassSAP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoServer = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerBD
            // 
            this.txtServerBD.Location = new System.Drawing.Point(112, 20);
            this.txtServerBD.Name = "txtServerBD";
            this.txtServerBD.Size = new System.Drawing.Size(222, 22);
            this.txtServerBD.TabIndex = 0;
            this.txtServerBD.Text = "NDB@192.168.1.9:30013";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor BD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "User BD";
            // 
            // txtUserBD
            // 
            this.txtUserBD.Location = new System.Drawing.Point(112, 48);
            this.txtUserBD.Name = "txtUserBD";
            this.txtUserBD.Size = new System.Drawing.Size(222, 22);
            this.txtUserBD.TabIndex = 2;
            this.txtUserBD.Text = "SYSTEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pass BD";
            // 
            // txtPassBD
            // 
            this.txtPassBD.Location = new System.Drawing.Point(112, 76);
            this.txtPassBD.Name = "txtPassBD";
            this.txtPassBD.Size = new System.Drawing.Size(222, 22);
            this.txtPassBD.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Servidor Lic";
            // 
            // txtServerLic
            // 
            this.txtServerLic.Location = new System.Drawing.Point(112, 104);
            this.txtServerLic.Name = "txtServerLic";
            this.txtServerLic.Size = new System.Drawing.Size(222, 22);
            this.txtServerLic.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre BD";
            // 
            // txtNombreBD
            // 
            this.txtNombreBD.Location = new System.Drawing.Point(112, 132);
            this.txtNombreBD.Name = "txtNombreBD";
            this.txtNombreBD.Size = new System.Drawing.Size(222, 22);
            this.txtNombreBD.TabIndex = 8;
            this.txtNombreBD.Text = "DC_0215";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "User SAP";
            // 
            // txtUserSAP
            // 
            this.txtUserSAP.Location = new System.Drawing.Point(112, 160);
            this.txtUserSAP.Name = "txtUserSAP";
            this.txtUserSAP.Size = new System.Drawing.Size(222, 22);
            this.txtUserSAP.TabIndex = 10;
            this.txtUserSAP.Text = "manager2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pass SAP";
            // 
            // txtPassSAP
            // 
            this.txtPassSAP.Location = new System.Drawing.Point(112, 188);
            this.txtPassSAP.Name = "txtPassSAP";
            this.txtPassSAP.Size = new System.Drawing.Size(222, 22);
            this.txtPassSAP.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tipo Server";
            // 
            // cmbTipoServer
            // 
            this.cmbTipoServer.FormattingEnabled = true;
            this.cmbTipoServer.Items.AddRange(new object[] {
            "HANA",
            "MSSQL2016"});
            this.cmbTipoServer.Location = new System.Drawing.Point(112, 216);
            this.cmbTipoServer.Name = "cmbTipoServer";
            this.cmbTipoServer.Size = new System.Drawing.Size(222, 24);
            this.cmbTipoServer.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Desconectar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 317);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbTipoServer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPassSAP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserSAP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreBD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServerLic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassBD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserBD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerBD);
            this.Name = "Form1";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassBD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerLic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreBD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserSAP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassSAP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

