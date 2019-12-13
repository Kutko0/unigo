using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Unigo.Data;

namespace Unigo.WinForm
{
    public partial class UpdateDestinationWindow : Form
    {
        private readonly HttpClient client;
        readonly string apiURL = "http://localhost:44304/api";

        public UpdateDestinationWindow(HttpClient client)
        {
            this.client = client;
            InitializeComponent();

            txtId.ReadOnly = true;
        }

        public UpdateDestinationWindow(Destination destination, HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            txtId.Text = destination.Id.ToString();
            txtName.Text = destination.Name;

            txtId.ReadOnly = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Destination destination = new Destination();
            

            if (txtId.Text.Trim().Length != 0)
            {
                destination = new Destination
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text
                };

                var content = JsonConvert.SerializeObject(destination);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(apiURL + "/destinations/" + destination.Id, byteContent);
            

            } else
            {
                destination = new Destination
                {
                    Name = txtName.Text
                };

                var content = JsonConvert.SerializeObject(destination);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(apiURL + "/destinations", byteContent);
            }
            
            this.Dispose();
        }
    }
}
