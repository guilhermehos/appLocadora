using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ConexaoMysql;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppLocadora
{
    public partial class CarroEditor : Form
    {
        public CarroEditor()
        {
            InitializeComponent();

            OperacaoBanco operacao = new OperacaoBanco();
            MySqlDataReader dados = operacao.Select("Select Distinct Marca from tb_marcas");
            while (dados.Read())
            {

                string rowz = string.Format("{0}", dados["Marca"]);
                cboFab.Items.Add(rowz);
            }
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            if (dlgPicture.ShowDialog() == DialogResult.OK)
            {
                lblPictureName.Text = dlgPicture.FileName;
                pbxCar.Image = Image.FromFile(lblPictureName.Text);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ClienteEditor editor = new ClienteEditor();
            string Opcionais = "";
            if (chkDVDPlayer.Checked)
            {
                Opcionais = chkCDPlayer.Text;
            }
            if (chkCDPlayer.Checked)
            {
                Opcionais += "/" + chkDVDPlayer.Text;
            }
            if (txtTagNumber.Text.Length == 0)
            {
                MessageBox.Show("Informe o número de registro");
                return;
            }

            if (cboFab.Text.Length == 0)
            {
                MessageBox.Show("Informe o fabricante.");
                return;
            }

            if (cboModel.Text.Length == 0)
            {
                MessageBox.Show("Informe o Ano de fabricação");
                return;
            }

            if (txtYear.Text.Length == 0)
            {
                MessageBox.Show("Informe o ano");
                return;
            }

            // Cria um carro
            Carro veiculo = new Carro();
            veiculo.Fabricante = cboFab.Text;
            veiculo.Modelo = cboModel.Text;
            veiculo.Ano = int.Parse(txtYear.Text);
            veiculo.Categoria = cbxCategories.Text;
            veiculo.TemCDPlayer = chkCDPlayer.Checked;
            veiculo.TemDVDPlayer = chkDVDPlayer.Checked;
            veiculo.EstaDisponivel = chkAvailable.Checked;
            veiculo.Placa = txtPlaca.Text;
            OperacaoBanco operacao = new OperacaoBanco();
            bool inserir = operacao.Insert("insert into tb_veiculos (Fabricante,Modelo,Ano,Categoria,Placa,Opcionais,Disponivel) Values ('" + veiculo.Fabricante + "','" + veiculo.Modelo + "','" + veiculo.Ano + "','" + veiculo.Categoria + "','" + veiculo.Placa + "','" + Opcionais + "', '" + veiculo.EstaDisponivel + "')");
            if (inserir)
            {
                MessageBox.Show("Sucesso!");
            }
            Close();
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMake_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTagNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPlaca_Click(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = cboFab.SelectedItem.ToString();
            OperacaoBanco operacao = new OperacaoBanco();
            MySqlDataReader dados = operacao.Select("Select distinct Modelo from tb_marcas where Marca = '" + marca + "'");
            while (dados.Read())
            {
                string rowz = string.Format("{0}", dados["Modelo"]);
                cboModel.Items.Add(rowz);
            }
        }
    }
}