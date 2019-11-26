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

            gvPeople.Columns["ID"].Visible = false;
            gvPeople.Columns["UserId"].Visible = false;

        }

        private void btnSearchPeople_Click(object sender, EventArgs e)
        {
            PopulateDataGridPeople();
        }
    }
}
