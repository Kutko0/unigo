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
        }

       
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
            var response = await client.GetAsync(apiURL + "/people/ByName/" + txtPeopleName.Text.Trim());
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
    }
}
