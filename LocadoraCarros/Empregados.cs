using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ConexaoMysql;
using MySql.Data.MySqlClient;

namespace AppLocadora
{
    public partial class Empregados : Form
    {
        //SortedDictionary<string, Empregado> listaEmpregados;
        Dictionary<int, Empregado> listaEmpregados = new Dictionary<int, Empregado>();

        public Empregados()
        {
            InitializeComponent();
        }

        internal void ExibeEmpregados()
        {
            if (listaEmpregados.Count == 0)
                return;

            // Antes de exibir limpa o list view
            lvwEmpregados.Items.Clear();
            // Esta variavel permite identificar os indices impares e pares
            int i = 1;

            // Usamos a classe KeyValuePair para visitar cara item key/value
            foreach (KeyValuePair<int, Empregado> kvp in listaEmpregados)
            {
                ListViewItem lviEmpregado = new ListViewItem(kvp.Key.ToString());

                Empregado empl = kvp.Value;

                lviEmpregado.SubItems.Add(empl.PrimeiroNome);
                lviEmpregado.SubItems.Add(empl.SobreNome);
                lviEmpregado.SubItems.Add(empl.Nome);
                lviEmpregado.SubItems.Add(empl.Titulo);
                lviEmpregado.SubItems.Add(empl.SalarioPorHora.ToString("F"));

                if (i % 2 == 0)
                {
                    lviEmpregado.BackColor = Color.FromArgb(255, 128, 0);
                    lviEmpregado.ForeColor = Color.White;
                }
                else
                {
                    lviEmpregado.BackColor = Color.FromArgb(128, 64, 64);
                    lviEmpregado.ForeColor = Color.White;
                }

                lvwEmpregados.Items.Add(lviEmpregado);

                i++;
            }
        }

        private void Empregados_Load(object sender, EventArgs e)
        {
            OperacaoBanco operacao = new OperacaoBanco();
            Empregado empregado = new Empregado();
            MySqlDataReader dados = operacao.Select("select Id,Codigo,Nome,Sobrenome,Nome_Completo,Titulo,Salario_Hora from tb_empregados");
            while (dados.Read())
            {
                if (dados.HasRows)
                {
                    empregado = new Empregado();
                    empregado.Id = Convert.ToInt16(dados["Id"]);
                    empregado.Codigo = Convert.ToString(dados["Nome"].ToString());
                    empregado.PrimeiroNome = dados["Nome"].ToString();
                    empregado.SobreNome = dados["Sobrenome"].ToString();
                    empregado.Titulo = dados["Titulo"].ToString();
                    empregado.SalarioPorHora = Convert.ToDouble(dados["Salario_Hora"]);

                }
                // Retorna a lista de clientes
                listaEmpregados.Add(empregado.Id, empregado);
            }

            ExibeEmpregados();
            //listaEmpregados = new SortedDictionary<string, Empregado>();
            //BinaryFormatter bfmEmpregados = new BinaryFormatter();

            ////armazena a lista de empregados
            //string strNomeArquivo = @"C:\NovaLoc_Carros\Empregados.cre";

            //if (File.Exists(strNomeArquivo))
            //{
            //    FileStream stmEmpregados = new FileStream(strNomeArquivo,
            //                                             FileMode.Open,
            //                                             FileAccess.Read,
            //                                             FileShare.Read);

            //    try
            //    {
            //        // retorna lista de empregados
            //        listaEmpregados =(SortedDictionary<string,Empregado>)
            //        bfmEmpregados.Deserialize(stmEmpregados);
            //    }
            //    finally
            //    {
            //        stmEmpregados.Close();
            //    }
            //}

            //ExibeEmpregados();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            EmpregadoEditor editor = new EmpregadoEditor();
            Empregados empregados = new Empregados();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (editor.txtEmployeeNumber.Text == "")
                {
                    MessageBox.Show("Você deve fornecer o numero de registro do " +
                                    "funcionario.");
                    return;
                }

                if (editor.txtFirstName.Text == "")
                {
                    MessageBox.Show("Informe o primeiro nome.");
                    return;
                }

                Empregado empregado = new Empregado();

                empregado.Codigo = editor.txtEmployeeNumber.Text;
                empregado.PrimeiroNome = editor.txtFirstName.Text;
                empregado.SobreNome = editor.txtLastName.Text;
                empregado.Titulo = editor.txtTitle.Text;
                empregado.SalarioPorHora = Convert.ToDouble(editor.txtHourlySalary.Text);
                OperacaoBanco operacao = new OperacaoBanco();
                bool inserir = operacao.Insert("insert into tb_empregados (Codigo,Nome,Sobrenome,Nome_Completo,Titulo,Salario_Hora) Values ('" + empregado.Codigo + "','" + empregado.PrimeiroNome + "','" + empregado.SobreNome + "','" + empregado.PrimeiroNome + empregado.SobreNome + "','" + empregado.Titulo + "','" + empregado.SalarioPorHora + "')");
                if (inserir)
                {
                    MessageBox.Show("Sucesso!");
                    empregados.ShowDialog();
                }
                Close();
                //Directory.CreateDirectory(@"C:\NovaLoc_Carros");

                //if (editor.ShowDialog() == DialogResult.OK)
                //{
                //    if (editor.txtEmployeeNumber.Text == "")
                //    {
                //        MessageBox.Show("Informe o número do empregado");
                //        return;
                //    }

                //    if (editor.txtLastName.Text == "")
                //    {
                //        MessageBox.Show("Informe o sobrenome do empregado");
                //        return;
                //    }

                //    string strNomeArquivo = @"C:\NovaLoc_Carros\Empregados.cre";

                //    Empregado empl = new Empregado();

                //    empl.PrimeiroNome = editor.txtFirstName.Text;
                //    empl.SobreNome = editor.txtLastName.Text;
                //    empl.Titulo = editor.txtTitle.Text;
                //    empl.SalarioPorHora = double.Parse(editor.txtHourlySalary.Text);
                //    listaEmpregados.Add(editor.txtEmployeeNumber.Text, empl);

                //    FileStream bcrStream = new FileStream(strNomeArquivo,
                //                                          FileMode.Create,
                //                                          FileAccess.Write,
                //                                          FileShare.Write);
                //    BinaryFormatter bcrBinary = new BinaryFormatter();
                //    bcrBinary.Serialize(bcrStream, listaEmpregados);
                //    bcrStream.Close();

                ExibeEmpregados();
            }
        }
    }
}