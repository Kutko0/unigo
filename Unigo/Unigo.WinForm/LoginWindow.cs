using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unigo.WinForm
{
    public partial class LoginWindow : Form
    {
        private readonly HttpClient client;
        readonly string username = "lentak";
        readonly string password = "123456";

        public LoginWindow(HttpClient client)
        {
            this.client = client;
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text != username || txtPassword.Text != password)
            {
                MessageBox.Show("Username and/or password was wrong, please try again.", "Carefull", MessageBoxButtons.OK);
            } else if(txtUserName.Text == username && txtPassword.Text == password)
            {
                Form menu = new StartWindow(client);
                menu.Show();
                this.Hide();
            }

        }
    }
}
