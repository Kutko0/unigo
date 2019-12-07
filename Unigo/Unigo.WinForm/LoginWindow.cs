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
        private HttpClient client;

        readonly string adminName = "lentak";
        readonly string password = "123456";

        public LoginWindow(HttpClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtAdminName.Text == adminName && txtPassword.Text == password)
            {
                Form startWindow = new StartWindow(client);
                startWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin name or password was wrong, please try again", "Something went wrong", MessageBoxButtons.OK);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
