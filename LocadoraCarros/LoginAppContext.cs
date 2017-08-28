using AppLocadora.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLocadora
{
    public class LoginAppContext : ApplicationContext
    {
        private Form mainForm;

        public LoginAppContext(Form mainForm, Form loginForm) : base(loginForm)
        {
            this.mainForm = mainForm;

            

        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is Login)
            {
                Login login = sender as Login;
                if (login.logged == true)
                {
                    base.MainForm = this.mainForm;
                    base.MainForm.Show();
                }
                else
                {
                    base.OnMainFormClosed(sender, e);
                }
            }
            else if (sender is Central)
            {
                base.OnMainFormClosed(sender, e);
            }
        }

    }
}
