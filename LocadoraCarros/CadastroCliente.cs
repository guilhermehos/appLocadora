using ConexaoMysql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLocadora
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();


            OperacaoBanco operacao = new OperacaoBanco();
            MySqlDataReader dados = operacao.Select("Select Distinct paisNome from tb_pais");
            while (dados.Read())
            {
                string rows = string.Format("{0}", dados["paisNome"]);
                cboPais.Items.Add(rows);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastroCliente cadastroCliente = new CadastroCliente();
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informar o nome.");
                return;
            }
            if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informar um telefone para contato.");
                return;
            }
            if (txtCEP.Text == "")
            {
                MessageBox.Show("Informar o CEP para obter o endereço.");
                return;
            }
            if (cboPais.SelectedIndex == -1)
            {
                MessageBox.Show("Informar o país.");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            txtEstado.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            cboPais.Text = "";
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            WebServiceCEP webServiceCEP = new WebServiceCEP(txtCEP.Text);
            txtCidade.Text = webServiceCEP.Cidade;
            txtEndereco.Text = webServiceCEP.Lagradouro;
            txtEstado.Text = webServiceCEP.UF;
        }
    }
}
