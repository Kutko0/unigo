namespace Unigo.WinForm
{
    partial class UpdateRideWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblRiderId = new System.Windows.Forms.Label();
            this.lblRiderName = new System.Windows.Forms.Label();
            this.lblDestinationId = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblStartPoint = new System.Windows.Forms.Label();
            this.lblLeavingTime = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblFreeSeats = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtRiderId = new System.Windows.Forms.TextBox();
            this.txtRiderName = new System.Windows.Forms.TextBox();
            this.txtDestinationId = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtStartPoint = new System.Windows.Forms.TextBox();
            this.txtLeavingTime = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtFreeSeats = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(49, 37);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblRiderId
            // 
            this.lblRiderId.AutoSize = true;
            this.lblRiderId.Location = new System.Drawing.Point(49, 61);
            this.lblRiderId.Name = "lblRiderId";
            this.lblRiderId.Size = new System.Drawing.Size(43, 13);
            this.lblRiderId.TabIndex = 1;
            this.lblRiderId.Text = "Rider id";
            // 
            // lblRiderName
            // 
            this.lblRiderName.AutoSize = true;
            this.lblRiderName.Location = new System.Drawing.Point(49, 83);
            this.lblRiderName.Name = "lblRiderName";
            this.lblRiderName.Size = new System.Drawing.Size(61, 13);
            this.lblRiderName.TabIndex = 2;
            this.lblRiderName.Text = "Rider name";
            // 
            // lblDestinationId
            // 
            this.lblDestinationId.AutoSize = true;
            this.lblDestinationId.Location = new System.Drawing.Point(49, 106);
            this.lblDestinationId.Name = "lblDestinationId";
            this.lblDestinationId.Size = new System.Drawing.Size(71, 13);
            this.lblDestinationId.TabIndex = 3;
            this.lblDestinationId.Text = "Destination id";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(49, 130);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(60, 13);
            this.lblDestination.TabIndex = 4;
            this.lblDestination.Text = "Destination";
            // 
            // lblStartPoint
            // 
            this.lblStartPoint.AutoSize = true;
            this.lblStartPoint.Location = new System.Drawing.Point(49, 152);
            this.lblStartPoint.Name = "lblStartPoint";
            this.lblStartPoint.Size = new System.Drawing.Size(69, 13);
            this.lblStartPoint.TabIndex = 5;
            this.lblStartPoint.Text = "Starting point";
            // 
            // lblLeavingTime
            // 
            this.lblLeavingTime.AutoSize = true;
            this.lblLeavingTime.Location = new System.Drawing.Point(49, 175);
            this.lblLeavingTime.Name = "lblLeavingTime";
            this.lblLeavingTime.Size = new System.Drawing.Size(67, 13);
            this.lblLeavingTime.TabIndex = 6;
            this.lblLeavingTime.Text = "Leaving time";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(49, 199);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // lblFreeSeats
            // 
            this.lblFreeSeats.AutoSize = true;
            this.lblFreeSeats.Location = new System.Drawing.Point(49, 223);
            this.lblFreeSeats.Name = "lblFreeSeats";
            this.lblFreeSeats.Size = new System.Drawing.Size(56, 13);
            this.lblFreeSeats.TabIndex = 8;
            this.lblFreeSeats.Text = "Free seats";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(49, 246);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 11;
            // 
            // txtRiderId
            // 
            this.txtRiderId.Location = new System.Drawing.Point(160, 58);
            this.txtRiderId.Name = "txtRiderId";
            this.txtRiderId.ReadOnly = true;
            this.txtRiderId.Size = new System.Drawing.Size(100, 20);
            this.txtRiderId.TabIndex = 12;
            // 
            // txtRiderName
            // 
            this.txtRiderName.Location = new System.Drawing.Point(160, 80);
            this.txtRiderName.Name = "txtRiderName";
            this.txtRiderName.ReadOnly = true;
            this.txtRiderName.Size = new System.Drawing.Size(100, 20);
            this.txtRiderName.TabIndex = 13;
            // 
            // txtDestinationId
            // 
            this.txtDestinationId.Location = new System.Drawing.Point(160, 103);
            this.txtDestinationId.Name = "txtDestinationId";
            this.txtDestinationId.ReadOnly = true;
            this.txtDestinationId.Size = new System.Drawing.Size(100, 20);
            this.txtDestinationId.TabIndex = 14;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(160, 127);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(100, 20);
            this.txtDestination.TabIndex = 15;
            // 
            // txtStartPoint
            // 
            this.txtStartPoint.Location = new System.Drawing.Point(160, 149);
            this.txtStartPoint.Name = "txtStartPoint";
            this.txtStartPoint.ReadOnly = true;
            this.txtStartPoint.Size = new System.Drawing.Size(100, 20);
            this.txtStartPoint.TabIndex = 16;
            // 
            // txtLeavingTime
            // 
            this.txtLeavingTime.Location = new System.Drawing.Point(160, 172);
            this.txtLeavingTime.Name = "txtLeavingTime";
            this.txtLeavingTime.Size = new System.Drawing.Size(100, 20);
            this.txtLeavingTime.TabIndex = 17;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(160, 196);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 18;
            // 
            // txtFreeSeats
            // 
            this.txtFreeSeats.Location = new System.Drawing.Point(160, 220);
            this.txtFreeSeats.Name = "txtFreeSeats";
            this.txtFreeSeats.Size = new System.Drawing.Size(100, 20);
            this.txtFreeSeats.TabIndex = 19;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(160, 243);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 20;
            // 
            // UpdateRideWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 355);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtFreeSeats);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtLeavingTime);
            this.Controls.Add(this.txtStartPoint);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtDestinationId);
            this.Controls.Add(this.txtRiderName);
            this.Controls.Add(this.txtRiderId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFreeSeats);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblLeavingTime);
            this.Controls.Add(this.lblStartPoint);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblDestinationId);
            this.Controls.Add(this.lblRiderName);
            this.Controls.Add(this.lblRiderId);
            this.Controls.Add(this.lblId);
            this.Name = "UpdateRideWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblRiderId;
        private System.Windows.Forms.Label lblRiderName;
        private System.Windows.Forms.Label lblDestinationId;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblStartPoint;
        private System.Windows.Forms.Label lblLeavingTime;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblFreeSeats;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtRiderId;
        private System.Windows.Forms.TextBox txtRiderName;
        private System.Windows.Forms.TextBox txtDestinationId;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtStartPoint;
        private System.Windows.Forms.TextBox txtLeavingTime;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtFreeSeats;
        private System.Windows.Forms.TextBox txtStatus;
    }
}