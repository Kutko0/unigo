namespace Unigo.WinForm
{
    partial class StartWindow
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
            this.tabDestinations = new System.Windows.Forms.TabPage();
            this.tabRides = new System.Windows.Forms.TabPage();
            this.tabPeople = new System.Windows.Forms.TabPage();
            this.gvPeople = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCars = new System.Windows.Forms.TabPage();
            this.btnSearchPeople = new System.Windows.Forms.Button();
            this.txtPeopleName = new System.Windows.Forms.TextBox();
            this.lablePeopleName = new System.Windows.Forms.Label();
            this.tabPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDestinations
            // 
            this.tabDestinations.Location = new System.Drawing.Point(4, 22);
            this.tabDestinations.Name = "tabDestinations";
            this.tabDestinations.Size = new System.Drawing.Size(792, 444);
            this.tabDestinations.TabIndex = 3;
            this.tabDestinations.Text = "Destinations";
            this.tabDestinations.UseVisualStyleBackColor = true;
            // 
            // tabRides
            // 
            this.tabRides.Location = new System.Drawing.Point(4, 22);
            this.tabRides.Name = "tabRides";
            this.tabRides.Size = new System.Drawing.Size(792, 444);
            this.tabRides.TabIndex = 2;
            this.tabRides.Text = "Rides";
            this.tabRides.UseVisualStyleBackColor = true;
            // 
            // tabPeople
            // 
            this.tabPeople.Controls.Add(this.lablePeopleName);
            this.tabPeople.Controls.Add(this.txtPeopleName);
            this.tabPeople.Controls.Add(this.btnSearchPeople);
            this.tabPeople.Controls.Add(this.gvPeople);
            this.tabPeople.Location = new System.Drawing.Point(4, 22);
            this.tabPeople.Name = "tabPeople";
            this.tabPeople.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeople.Size = new System.Drawing.Size(792, 444);
            this.tabPeople.TabIndex = 0;
            this.tabPeople.Text = "People";
            this.tabPeople.UseVisualStyleBackColor = true;
            // 
            // gvPeople
            // 
            this.gvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPeople.Location = new System.Drawing.Point(51, 59);
            this.gvPeople.Name = "gvPeople";
            this.gvPeople.Size = new System.Drawing.Size(532, 385);
            this.gvPeople.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPeople);
            this.tabControl1.Controls.Add(this.tabRides);
            this.tabControl1.Controls.Add(this.tabDestinations);
            this.tabControl1.Controls.Add(this.tabCars);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCars
            // 
            this.tabCars.Location = new System.Drawing.Point(4, 22);
            this.tabCars.Name = "tabCars";
            this.tabCars.Padding = new System.Windows.Forms.Padding(3);
            this.tabCars.Size = new System.Drawing.Size(792, 444);
            this.tabCars.TabIndex = 4;
            this.tabCars.Text = "Cars";
            this.tabCars.UseVisualStyleBackColor = true;
            // 
            // btnSearchPeople
            // 
            this.btnSearchPeople.Location = new System.Drawing.Point(647, 18);
            this.btnSearchPeople.Name = "btnSearchPeople";
            this.btnSearchPeople.Size = new System.Drawing.Size(109, 32);
            this.btnSearchPeople.TabIndex = 1;
            this.btnSearchPeople.Text = "Search";
            this.btnSearchPeople.UseVisualStyleBackColor = true;
            this.btnSearchPeople.Click += new System.EventHandler(this.btnSearchPeople_Click);
            // 
            // txtPeopleName
            // 
            this.txtPeopleName.Location = new System.Drawing.Point(514, 22);
            this.txtPeopleName.Name = "txtPeopleName";
            this.txtPeopleName.Size = new System.Drawing.Size(116, 20);
            this.txtPeopleName.TabIndex = 2;
            // 
            // lablePeopleName
            // 
            this.lablePeopleName.AutoSize = true;
            this.lablePeopleName.Location = new System.Drawing.Point(448, 22);
            this.lablePeopleName.Name = "lablePeopleName";
            this.lablePeopleName.Size = new System.Drawing.Size(60, 13);
            this.lablePeopleName.TabIndex = 3;
            this.lablePeopleName.Text = "FirstName :";
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.tabControl1);
            this.Name = "StartWindow";
            this.Text = "StartWindow";
            this.tabPeople.ResumeLayout(false);
            this.tabPeople.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDestinations;
        private System.Windows.Forms.TabPage tabRides;
        private System.Windows.Forms.TabPage tabPeople;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCars;
        private System.Windows.Forms.DataGridView gvPeople;
        private System.Windows.Forms.Button btnSearchPeople;
        private System.Windows.Forms.Label lablePeopleName;
        private System.Windows.Forms.TextBox txtPeopleName;
    }
}