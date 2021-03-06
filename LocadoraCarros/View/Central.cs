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
            Carros carros = new Carros();
            carros.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Empregados dlgEmpregados = new Empregados();
            dlgEmpregados.ShowDialog();
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