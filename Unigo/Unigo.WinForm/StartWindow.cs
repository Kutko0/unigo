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
using Newtonsoft.Json;
using Unigo.Data;

namespace Unigo.WinForm
{
    public partial class StartWindow : Form
    {
        private HttpClient client;
        string apiURL = "http://localhost:44304/api";

        public StartWindow(HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            PopulateDataGridPeople();
            PopulateDataGridCars();
        }

        #region PeopleTab things

        private async void PopulateDataGridPeople()
        {
            var response = await client.GetAsync(apiURL + "/people");
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Person> results = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonResults);
            
            gvPeople.DataSource = results;  

            gvPeople.Columns["Id"].Visible = false;
            gvPeople.Columns["UserId"].Visible = false;
        }

        private async void txtPeopleName_TextChanged(object sender, EventArgs e)
        {
            var response = await client.GetAsync(apiURL + "/people/ByName/" + txtPeopleSearchBar.Text.Trim());
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Person> results = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonResults);

            gvPeople.DataSource = results;
        }

        private async void gvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            try { 
                DataGridViewRow row = gvPeople.Rows[rowIndex];
                int personId = (int)row.Cells[0].Value;

                var response = await client.GetAsync(apiURL + "/people/ById/" + personId);
                var jsonResults = await response.Content.ReadAsStringAsync();

                Person person = JsonConvert.DeserializeObject<Person>(jsonResults);

                Form updatePersonWindow = new UpdatePersonWindow(person, client);
                updatePersonWindow.Show();
            } catch(ArgumentOutOfRangeException)
            {

            } 
        }

        private async void btnDeletePerson_Click(object sender, EventArgs e)
        {
            var rowsToDelete = gvPeople.SelectedRows;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + rowsToDelete.Count + " row(s) ", "Delete person", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    int personId = (int)row.Cells[0].Value;

                    var response = await client.DeleteAsync(apiURL + "/people/" + personId);
                    PopulateDataGridPeople();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        #endregion

        #region CarsTab things

        private async void PopulateDataGridCars()
        {
            var response = await client.GetAsync(apiURL + "/cars");
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Car> results = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResults);

            gvCars.DataSource = results;

            gvCars.Columns["Id"].Visible = false;
            gvCars.Columns["Rider"].Visible = false;
            gvCars.Columns["RiderId"].Visible = false;
            gvCars.Columns["Color"].Visible = false;
            gvCars.Columns["NumberOfSeats"].Visible = false;
        }

        private async void txtCarsSearchBar_TextChanged(object sender, EventArgs e)
        {
            var response = await client.GetAsync(apiURL + "/cars/ByLicensePlate/" + txtCarsSearchBar.Text.Trim());
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Car> results = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResults);

            gvCars.DataSource = results;
        }

        private async void gvCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            try
            {
                DataGridViewRow row = gvCars.Rows[rowIndex];
                int carId = (int)row.Cells[0].Value;

                var response = await client.GetAsync(apiURL + "/cars/ById/" + carId);
                var jsonResults = await response.Content.ReadAsStringAsync();

                Car car = JsonConvert.DeserializeObject<Car>(jsonResults);

                Form updateCarWindow = new UpdateCarWindow(car, client);
                updateCarWindow.Show();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private async void btnDeleteCar_Click(object sender, EventArgs e)
        {
            var rowsToDelete = gvCars.SelectedRows;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + rowsToDelete.Count + " row(s) ", "Delete car", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    int carId = (int)row.Cells[0].Value;

                    var response = await client.DeleteAsync(apiURL + "/cars/" + carId);
                    PopulateDataGridCars();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        #endregion


    }
}
