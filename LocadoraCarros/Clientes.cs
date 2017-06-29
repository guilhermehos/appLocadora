using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ConexaoMysql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AppLocadora
{
    public partial class Clientes : Form
    {
        Dictionary<int, Cliente> listaClientes = new Dictionary<int, Cliente>();

        public Clientes()
        {
            InitializeComponent();
        }

        internal void ExibeClientes()
        {
            //if (listaClientes.Count == 0)
            //    return;

            lvClientes.Items.Clear();
            int i = 1;

            foreach (KeyValuePair<int, Cliente> kvp in listaClientes)
            {
                ListViewItem lviCliente = new ListViewItem(kvp.Key.ToString());

                Cliente cli = kvp.Value;

                lviCliente.SubItems.Add(cli.CNH);
                lviCliente.SubItems.Add(cli.Nome);
                lviCliente.SubItems.Add(cli.Endereco);
                lviCliente.SubItems.Add(cli.Cidade);
                lviCliente.SubItems.Add(cli.Estado);
                lviCliente.SubItems.Add(cli.CodigoPostal);

                if (i % 2 == 0)
                {
                    lviCliente.BackColor = Color.Navy;
                    lviCliente.ForeColor = Color.White;
                }
                else
                {
                    lviCliente.BackColor = Color.Blue;
                    lviCliente.ForeColor = Color.White;
                }

                lvClientes.Items.Add(lviCliente);

                i++;
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            OperacaoBanco operacao = new OperacaoBanco();
            Cliente cliente = new Cliente();
            MySqlDataReader dados = operacao.Select("select Id,Nome,Endereco,Cidade,Estado,CEP,CNH from tb_cliente");
            while (dados.Read())
            {
                if (dados.HasRows)
                {
                    cliente = new Cliente();
                    cliente.Id = Convert.ToInt16(dados["Id"]);
                    cliente.Nome = Convert.ToString(dados["Nome"].ToString());
                    cliente.Endereco = dados["Endereco"].ToString();
                    cliente.Cidade = dados["Cidade"].ToString();
                    cliente.Estado = dados["Estado"].ToString();
                    cliente.CodigoPostal = dados["CEP"].ToString();
                    cliente.CNH = dados["CNH"].ToString();

                }
                // Retorna a lista de clientes
                listaClientes.Add(cliente.Id, cliente);
            }
            // variavel nomeAlunoObtido está com o dado obtido da tabela.
            //listaClientes = new Dictionary<string, Cliente>();
            //BinaryFormatter bfmClientes = new BinaryFormatter();

            //// arquivo que trata a lista de clientes
            //string strNomeArquivo = @"C:\NovaLoc_Carros\Clientes.crc";

            //if (File.Exists(strNomeArquivo))
            //{
            //    FileStream stmClientes = new FileStream(strNomeArquivo,
            //                                             FileMode.Open,
            //                                             FileAccess.Read,
            //                                             FileShare.Read);
            //    try
            //    {
            //        // Retorna a lista de clientes
            //        listaClientes =
            //            (Dictionary<string, Cliente>)
            //                bfmClientes.Deserialize(stmClientes);
            //    }
            //    finally
            //    {
            //        stmClientes.Close();
            //    }
            //}

            ExibeClientes();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ClienteEditor editor = new ClienteEditor();
            //Directory.CreateDirectory(@"C:\NovaLoc_Carros");

            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (editor.txtDrvLicNbr.Text == "")
                {
                    MessageBox.Show("Você deve fornecer o numero de registro da " +
                                    "carteira de habilitação do cliente.");
                    return;
                }

                if (editor.txtFullName.Text == "")
                {
                    MessageBox.Show("Informe o nome completo.");
                    return;
                }


                Cliente cli = new Cliente();

                cli.CNH = editor.txtDrvLicNbr.Text;
                cli.Nome = editor.txtFullName.Text;
                cli.Endereco = editor.txtAddress.Text;
                cli.Cidade = editor.txtCity.Text;
                cli.Estado = editor.cbxStates.Text;
                cli.CodigoPostal = editor.txtZIPCode.Text;
                OperacaoBanco operacao = new OperacaoBanco();
                bool inserir = operacao.Insert("insert into tb_cliente (Nome,Endereco,Cidade,Estado,CEP,CNH) Values ('" + cli.Nome + "','" + cli.Endereco + "','" + cli.Cidade + "','" + cli.Estado + "','" + cli.CodigoPostal + "','" + cli.CNH + "')");
                if (inserir)
                {
                    MessageBox.Show("Sucesso!");
                }
                //string strNomeArquivo = @"C:\NovaLoc_Carros\Clientes.crc";

                ////listaClientes.Add(editor.txtDrvLicNbr.Text, cli);

                //FileStream bcrStream = new FileStream(strNomeArquivo,
                //                                      FileMode.Create,
                //                                      FileAccess.Write,
                //                                      FileShare.Write);
                //BinaryFormatter bcrBinary = new BinaryFormatter();
                //bcrBinary.Serialize(bcrStream, listaClientes);
                //bcrStream.Close();

                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void lvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void EditarToolStripMenuItem1_Click(object sender)
        {

        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ClienteEditor editor = new ClienteEditor();

            Cliente cli = new Cliente();

            cli.CNH = editor.txtDrvLicNbr.Text;
            cli.Nome = editor.txtFullName.Text;
            cli.Endereco = editor.txtAddress.Text;
            cli.Cidade = editor.txtCity.Text;
            cli.Estado = editor.cbxStates.Text;
            cli.CodigoPostal = editor.txtZIPCode.Text;

            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (editor.txtDrvLicNbr.Text == "")
                {
                    MessageBox.Show("Você deve fornecer o numero de registro da " +
                                    "carteira de habilitação do cliente.");
                    return;
                }

                if (editor.txtFullName.Text == "")
                {
                    MessageBox.Show("Informe o nome completo.");
                    return;
                }


                OperacaoBanco operacao = new OperacaoBanco();
                bool update = operacao.Update("update into tb_cliente (Nome,Endereco,Cidade,Estado,CEP,CNH) Values ('" + cli.Nome + "','" + cli.Endereco + "','" + cli.Cidade + "','" + cli.Estado + "','" + cli.CodigoPostal + "','" + cli.CNH + "')");
                if (update)
                {
                    MessageBox.Show("Sucesso!");
                }
            }
        }
    }
}