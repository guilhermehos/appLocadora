using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppLocadora
{
    public partial class ClienteEditor : Form
    {
        public ClienteEditor()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtZIPCode_TextChanged(object sender, EventArgs e)
        {
            WebServiceCEP webServiceCEP = new WebServiceCEP(txtZIPCode.Text);
            txtCity.Text = webServiceCEP.Cidade;
            txtAddress.Text = webServiceCEP.Lagradouro;
            cbxStates.Text = webServiceCEP.UF;
        }
    }
}