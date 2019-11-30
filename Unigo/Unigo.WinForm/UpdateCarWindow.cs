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
    public partial class UpdateCarWindow : Form
    {
        private readonly HttpClient client;
        readonly string apiURL = "http://localhost:44304/api";

        public UpdateCarWindow(Car car, HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            txtId.Text = car.Id.ToString();
            txtLicensePlate.Text = car.LicensePlate;
            txtBrand.Text = car.Brand;
            txtType.Text = car.Type;
            txtColor.Text = car.Color;
            txtDescription.Text = car.Description;
            txtNumberOfSeats.Text = car.NumberOfSeats.ToString();
            txtRiderId.Text = car.RiderId.ToString();
            txtRiderName.Text = car.Rider.FirstName + " " + car.Rider.LastName;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Car car = new Car
            {
                Id = int.Parse(txtId.Text),
                LicensePlate = txtLicensePlate.Text,
                Brand = txtBrand.Text,
                Type = txtType.Text,
                Color = txtColor.Text,
                Description = txtDescription.Text,
                NumberOfSeats = int.Parse(txtNumberOfSeats.Text),
                RiderId = int.Parse(txtRiderId.Text),
                Rider = null
            };

            var content = JsonConvert.SerializeObject(car);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(apiURL + "/cars/" + car.Id, byteContent);

            this.Dispose();
        }
    }
}
