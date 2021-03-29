﻿using DevExpress.XtraEditors;
using SimiSoft.BML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimiSoft
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (new Usuario
                {
                    username = txtUsuario.Text,
                    password = txtPassword.Text
                }.Login()!= null)
                {
                    XtraMessageBox.Show("Acceso correcto");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Error en las credenciales");
                }
            }
        }
        private bool Validar()
        {
            var ban = false;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.ErrorText = "Ingresa un Usuario";
                txtUsuario.Focus();
                ban = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.ErrorText = "Ingresa una Contraseña";
                if (!ban)
                {
                    txtPassword.Focus();
                    ban = true;
                }
            }
            return !ban;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}