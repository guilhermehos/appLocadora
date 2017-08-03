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
    public partial class Carros : Form
    {
        Dictionary<int, Carro> listaCarros = new Dictionary<int, Carro>();

        public Carros()
        {
            InitializeComponent();
        }
        internal void ExibeCarros()
        {
            //if (listaClientes.Count == 0)
            //    return;

            lvCarros.Items.Clear();
            int i = 1;

            foreach (KeyValuePair<int, Carro> kvp in listaCarros)
            {
                ListViewItem lviCarros = new ListViewItem(kvp.Key.ToString());

                Carro car = kvp.Value;
                string opcionais = car.TemCDPlayer.ToString();
                opcionais += "/" + car.TemDVDPlayer.ToString();

                lviCarros.SubItems.Add(car.Fabricante);
                lviCarros.SubItems.Add(car.Modelo);
                lviCarros.SubItems.Add(car.Ano.ToString());
                lviCarros.SubItems.Add(opcionais.ToString());
                lviCarros.SubItems.Add(car.EstaDisponivel.ToString());
                lviCarros.SubItems.Add(car.Placa);
                lviCarros.SubItems.Add(car.Categoria);
                
                if (i % 2 == 0)
                {
                    lviCarros.BackColor = Color.Navy;
                    lviCarros.ForeColor = Color.White;
                }
                else
                {
                    lviCarros.BackColor = Color.Blue;
                    lviCarros.ForeColor = Color.White;
                }

                lvCarros.Items.Add(lviCarros);

                i++;
            }
        }
        private void CarroEditor_Load(object sender, EventArgs e)
        {
            OperacaoBanco operacao = new OperacaoBanco();
            Carro veiculo = new Carro();
            MySqlDataReader dados = operacao.Select("select Id,Fabricante,Modelo,Ano,Categoria,Placa,Opcionais,Disponivel from tb_veiculos");
            while (dados.Read())
            {
                if (dados.HasRows)
                {
                    veiculo = new Carro();
                    veiculo.Id = Convert.ToInt16(dados["Id"]);
                    veiculo.Fabricante = Convert.ToString(dados["Fabricante"].ToString());
                    veiculo.Modelo = dados["Modelo"].ToString();
                    veiculo.Ano = Convert.ToInt16(dados["Ano"]);
                    veiculo.Categoria = dados["Categoria"].ToString();
                    veiculo.Placa = dados["Placa"].ToString();
                    veiculo.EstaDisponivel = (dados["Disponivel"].ToString() == "S" ? true : false);
                }
                // Retorna a lista de clientes
                listaCarros.Add(veiculo.Id, veiculo);
            }
            ExibeCarros();
        }

        private void btnNewCar_Click(object sender, EventArgs e)
        {
            CarroEditor carroEditor = new CarroEditor();
            carroEditor.ShowDialog();
        }
    }
}
