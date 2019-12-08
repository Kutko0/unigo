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
        private readonly HttpClient client;
        string apiURL = "http://localhost:44304/api";

        public StartWindow(HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            checkedListBox1.Visible = true;
            PopulateDataGridPeople();
            PopulateDataGridCars();
            PopulateDataGridDestinations();
            PopulateDataGridRides();
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
            gvCars.Columns["Status"].Visible = false;
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

        #region Destinations things

        private async void PopulateDataGridDestinations()
        {
            var response = await client.GetAsync(apiURL + "/destinations");
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Destination> results = JsonConvert.DeserializeObject<IEnumerable<Destination>>(jsonResults);

            gvDestinations.DataSource = results;
            gvDestinations.Columns[1].Width = 200;
        }

        private async void txtDestinationsSearchBar_TextChanged(object sender, EventArgs e)
        {
            var response = await client.GetAsync(apiURL + "/destinations/ByName/" + txtDestinationsSearchBar.Text.Trim());
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Destination> results = JsonConvert.DeserializeObject<IEnumerable<Destination>>(jsonResults);

            gvDestinations.DataSource = results;
        }

        private async void gvDestinations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            try
            {
                DataGridViewRow row = gvDestinations.Rows[rowIndex];
                int personId = (int)row.Cells[0].Value;

                var response = await client.GetAsync(apiURL + "/destinations/ById/" + personId);
                var jsonResults = await response.Content.ReadAsStringAsync();

                Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResults);

                Form updateDestinationWindow = new UpdateDestinationWindow(destination, client);
                updateDestinationWindow.Show();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form updateDestinationWindow = new UpdateDestinationWindow(client);
            updateDestinationWindow.Show();
        }

        private async void btnDeleteDestination_Click(object sender, EventArgs e)
        {
            var rowsToDelete = gvDestinations.SelectedRows;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + rowsToDelete.Count + " row(s) ", "Delete destination", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    int destinationId = (int)row.Cells[0].Value;

                    var response = await client.DeleteAsync(apiURL + "/destinations/" + destinationId);
                    PopulateDataGridDestinations();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        #endregion

        // Destination Column in Rides needs to be fixed
        
        #region Rides things

        private async void PopulateDataGridRides()
        {
            var response = await client.GetAsync(apiURL + "/rides");
            var jsonResults = await response.Content.ReadAsStringAsync();

            IEnumerable<Ride> results = JsonConvert.DeserializeObject<IEnumerable<Ride>>(jsonResults);

            gvRides.DataSource = results;

            //gvRides.Columns[3].ValueType = typeof(string);

            //for (int i = 0; i < results.Count(); i++)
            //{
            //    DataGridViewRow currentRow = gvRides.Rows[i];
            //    gvRides.Rows[i].Cells[3].Value = "ideto";
            //}



            gvRides.Columns["Id"].Visible = false;
            gvRides.Columns["Rider"].Visible = false;
            gvRides.Columns["RiderId"].Visible = false;
            gvRides.Columns["DestinationId"].Visible = false;
            gvRides.Columns["Status"].Visible = false ;
            gvRides.Columns["StartLat"].Visible = false;
            gvRides.Columns["StartLong"].Visible = false;
            gvRides.Columns["CarId"].Visible = false;


        }

        private async void txtRidesSearchBar_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<Ride> results = null;

            if (checkedListBox1.CheckedItems.Count == 2 || checkedListBox1.CheckedItems.Count == 0)
            {
                var response = await client.GetAsync(apiURL + "/rides/ByDestination/" + txtRidesSearchBar.Text.Trim());
                var jsonResults = await response.Content.ReadAsStringAsync();

                results = JsonConvert.DeserializeObject<IEnumerable<Ride>>(jsonResults);
            } // Active rides
            else if(checkedListBox1.SelectedIndex == 0)
            {

                var response = await client.GetAsync(apiURL + "/rides/GetActiveRides/" + txtRidesSearchBar.Text.Trim());
                var jsonResults = await response.Content.ReadAsStringAsync();

                results = JsonConvert.DeserializeObject<IEnumerable<Ride>>(jsonResults);
            }   //Inactive rides 
            else if(checkedListBox1.SelectedIndex == 1)
            {
                var response = await client.GetAsync(apiURL + "/rides/GetInactiveRides/" + txtRidesSearchBar.Text.Trim());
                var jsonResults = await response.Content.ReadAsStringAsync();

                results = JsonConvert.DeserializeObject<IEnumerable<Ride>>(jsonResults);
            }
            

            gvRides.DataSource = results;
        }

        private async void gvRides_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            try
            {
                DataGridViewRow row = gvRides.Rows[rowIndex];
                int personId = (int)row.Cells[0].Value;

                var response = await client.GetAsync(apiURL + "/rides/ById/" + personId);
                var jsonResults = await response.Content.ReadAsStringAsync();

                Ride ride = JsonConvert.DeserializeObject<Ride>(jsonResults);

                Form updateRideWindow = new UpdateRideWindow(ride, client);
                updateRideWindow.Show();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private async void btnDeleteRide_Click(object sender, EventArgs e)
        {
            var rowsToDelete = gvPeople.SelectedRows;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + rowsToDelete.Count + " row(s) ", "Delete ride", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    int rideId = (int)row.Cells[0].Value;

                    var response = await client.DeleteAsync(apiURL + "/rides/" + rideId);
                    PopulateDataGridRides();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRidesSearchBar_TextChanged(sender, e);
        }

        #endregion

    }
}
