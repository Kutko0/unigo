﻿using System;
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
    public partial class UpdateRideWindow : Form
    {
        private readonly HttpClient client;
        readonly string apiURL = "http://localhost:44304/api";

        public UpdateRideWindow(Ride ride, HttpClient client)
        {
            this.client = client;
            InitializeComponent();
            txtId.Text = ride.Id.ToString();
            txtRiderId.Text = ride.RiderId.ToString();
            txtRiderName.Text = ride.Rider.FirstName + " " + ride.Rider.LastName;
            txtDestinationId.Text = ride.DestinationId.ToString();
            txtDestination.Text = ride.Destination.Name;
            txtStartPoint.Text = ride.StartPoint;
            txtLeavingTime.Text = ride.LeavingTime.ToString();
            txtPrice.Text = ride.Price.ToString();
            txtFreeSeats.Text = ride.NumberOfSeats.ToString();
            if(ride.Active == true)
            {
                txtStatus.Text = "Active";
            } else if (ride.Active == false)
            {
                txtStatus.Text = "Inactive";
            }
            

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool status = true;
            
            
            if(!txtStatus.Text.Trim().Equals("Active") && !txtStatus.Text.Trim().Equals("Inactive"))
            {
                DialogResult dialogResult = MessageBox.Show("Allowed values for Status are Active and Inactive ", "Carefull", MessageBoxButtons.OK);
            }
            else
            {
                if (txtStatus.Text.Trim().Equals("Active"))
                {
                    status = true;
                }
                else if (txtStatus.Text.Trim().Equals("Inactive"))
                {
                    status = false;
                }

                Ride ride = new Ride
                {
                    Id = int.Parse(txtId.Text),
                    RiderId = int.Parse(txtRiderId.Text),
                    DestinationId = int.Parse(txtDestinationId.Text),
                    StartPoint = txtStartPoint.Text,
                    LeavingTime = DateTime.Parse(txtLeavingTime.Text),
                    Price = int.Parse(txtPrice.Text),
                    NumberOfSeats = int.Parse(txtFreeSeats.Text),
                    Active = status
                };


                var content = JsonConvert.SerializeObject(ride);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(apiURL + "/rides/" + ride.Id, byteContent);

                this.Dispose();
            }

           
        }
    }
}
