using ConexaoMysql;
using System;
using System.Windows.Forms;

namespace AppLocadora
{
    public partial class Central : Form
    {
        public Central()
        {
            InitializeComponent();
        }

        private void btnRentalOrders_Click(object sender, EventArgs e)
        {
            ProcessamentoPedido dlgOrder = new ProcessamentoPedido();
            dlgOrder.ShowDialog();
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            CarroEditor dlgCars = new CarroEditor();
            dlgCars.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
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
            }
            
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Clientes dlgCustomers = new Clientes();
            dlgCustomers.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}