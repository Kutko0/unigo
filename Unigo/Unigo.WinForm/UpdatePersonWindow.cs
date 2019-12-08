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
    public partial class UpdatePersonWindow : Form
    {
        private readonly HttpClient client;
        readonly string apiURL = "http://localhost:44304/api";
        

        public UpdatePersonWindow(Person person, HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            txtId.Text = person.Id.ToString();
            txtUserId.Text = person.UserId;
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtDateOfBirth.Text = person.DateOfBirth.ToString();
            txtPhoneNumber.Text = person.PhoneNumber;
            txtEmail.Text = person.Email;
            txtCity.Text = person.City;
            txtNationality.Text = person.Nationality;
            txtCampus.Text = person.Campus.ToString();
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Person person = new Person()
            {
                Id = int.Parse(txtId.Text),
                UserId = txtUserId.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = DateTime.Parse(txtDateOfBirth.Text),
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
                City = txtCity.Text,
                Nationality = txtNationality.Text,
                Campus = int.Parse(txtCampus.Text)
               
            };


            var content = JsonConvert.SerializeObject(person);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(apiURL + "/people/" + person.Id, byteContent);

            this.Dispose();
        }
    }
}
