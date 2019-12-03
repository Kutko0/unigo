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
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelDestinationSearch = new System.Windows.Forms.Label();
            this.txtDestinationsSearchBar = new System.Windows.Forms.TextBox();
            this.btnDeleteDestination = new System.Windows.Forms.Button();
            this.gvDestinations = new System.Windows.Forms.DataGridView();
            this.tabRides = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRidesSearchBar = new System.Windows.Forms.TextBox();
            this.btnDeleteRide = new System.Windows.Forms.Button();
            this.gvRides = new System.Windows.Forms.DataGridView();
            this.tabPeople = new System.Windows.Forms.TabPage();
            this.btnDeletePerson = new System.Windows.Forms.Button();
            this.lablePeopleSearch = new System.Windows.Forms.Label();
            this.txtPeopleSearchBar = new System.Windows.Forms.TextBox();
            this.gvPeople = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCars = new System.Windows.Forms.TabPage();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.txtCarsSearchBar = new System.Windows.Forms.TextBox();
            this.labelSearchCar = new System.Windows.Forms.Label();
            this.gvCars = new System.Windows.Forms.DataGridView();
            this.tabDestinations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestinations)).BeginInit();
            this.tabRides.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRides)).BeginInit();
            this.tabPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDestinations
            // 
            this.tabDestinations.Controls.Add(this.btnAdd);
            this.tabDestinations.Controls.Add(this.labelDestinationSearch);
            this.tabDestinations.Controls.Add(this.txtDestinationsSearchBar);
            this.tabDestinations.Controls.Add(this.btnDeleteDestination);
            this.tabDestinations.Controls.Add(this.gvDestinations);
            this.tabDestinations.Location = new System.Drawing.Point(4, 22);
            this.tabDestinations.Name = "tabDestinations";
            this.tabDestinations.Size = new System.Drawing.Size(792, 444);
            this.tabDestinations.TabIndex = 3;
            this.tabDestinations.Text = "Destinations";
            this.tabDestinations.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(606, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 27);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelDestinationSearch
            // 
            this.labelDestinationSearch.AutoSize = true;
            this.labelDestinationSearch.Location = new System.Drawing.Point(115, 29);
            this.labelDestinationSearch.Name = "labelDestinationSearch";
            this.labelDestinationSearch.Size = new System.Drawing.Size(109, 13);
            this.labelDestinationSearch.TabIndex = 9;
            this.labelDestinationSearch.Text = "Search by destination";
            // 
            // txtDestinationsSearchBar
            // 
            this.txtDestinationsSearchBar.Location = new System.Drawing.Point(241, 22);
            this.txtDestinationsSearchBar.Name = "txtDestinationsSearchBar";
            this.txtDestinationsSearchBar.Size = new System.Drawing.Size(144, 20);
            this.txtDestinationsSearchBar.TabIndex = 8;
            this.txtDestinationsSearchBar.TextChanged += new System.EventHandler(this.txtDestinationsSearchBar_TextChanged);
            // 
            // btnDeleteDestination
            // 
            this.btnDeleteDestination.Location = new System.Drawing.Point(606, 24);
            this.btnDeleteDestination.Name = "btnDeleteDestination";
            this.btnDeleteDestination.Size = new System.Drawing.Size(93, 28);
            this.btnDeleteDestination.TabIndex = 7;
            this.btnDeleteDestination.Text = "Delete";
            this.btnDeleteDestination.UseVisualStyleBackColor = true;
            this.btnDeleteDestination.Click += new System.EventHandler(this.btnDeleteDestination_Click);
            // 
            // gvDestinations
            // 
            this.gvDestinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDestinations.Location = new System.Drawing.Point(65, 59);
            this.gvDestinations.Name = "gvDestinations";
            this.gvDestinations.ReadOnly = true;
            this.gvDestinations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDestinations.Size = new System.Drawing.Size(532, 385);
            this.gvDestinations.TabIndex = 2;
            this.gvDestinations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDestinations_CellContentClick);
            // 
            // tabRides
            // 
            this.tabRides.Controls.Add(this.checkedListBox1);
            this.tabRides.Controls.Add(this.label1);
            this.tabRides.Controls.Add(this.txtRidesSearchBar);
            this.tabRides.Controls.Add(this.btnDeleteRide);
            this.tabRides.Controls.Add(this.gvRides);
            this.tabRides.Location = new System.Drawing.Point(4, 22);
            this.tabRides.Name = "tabRides";
            this.tabRides.Size = new System.Drawing.Size(792, 444);
            this.tabRides.TabIndex = 2;
            this.tabRides.Text = "Rides";
            this.tabRides.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.checkedListBox1.Location = new System.Drawing.Point(606, 85);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 34);
            this.checkedListBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search by destination:";
            // 
            // txtRidesSearchBar
            // 
            this.txtRidesSearchBar.Location = new System.Drawing.Point(268, 24);
            this.txtRidesSearchBar.Name = "txtRidesSearchBar";
            this.txtRidesSearchBar.Size = new System.Drawing.Size(144, 20);
            this.txtRidesSearchBar.TabIndex = 6;
            this.txtRidesSearchBar.TextChanged += new System.EventHandler(this.txtRidesSearchBar_TextChanged);
            // 
            // btnDeleteRide
            // 
            this.btnDeleteRide.Location = new System.Drawing.Point(606, 24);
            this.btnDeleteRide.Name = "btnDeleteRide";
            this.btnDeleteRide.Size = new System.Drawing.Size(93, 28);
            this.btnDeleteRide.TabIndex = 5;
            this.btnDeleteRide.Text = "Delete";
            this.btnDeleteRide.UseVisualStyleBackColor = true;
            this.btnDeleteRide.Click += new System.EventHandler(this.btnDeleteRide_Click);
            // 
            // gvRides
            // 
            this.gvRides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRides.Location = new System.Drawing.Point(65, 59);
            this.gvRides.Name = "gvRides";
            this.gvRides.ReadOnly = true;
            this.gvRides.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRides.Size = new System.Drawing.Size(532, 385);
            this.gvRides.TabIndex = 1;
            this.gvRides.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRides_CellContentClick);
            // 
            // tabPeople
            // 
            this.tabPeople.Controls.Add(this.btnDeletePerson);
            this.tabPeople.Controls.Add(this.lablePeopleSearch);
            this.tabPeople.Controls.Add(this.txtPeopleSearchBar);
            this.tabPeople.Controls.Add(this.gvPeople);
            this.tabPeople.Location = new System.Drawing.Point(4, 22);
            this.tabPeople.Name = "tabPeople";
            this.tabPeople.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeople.Size = new System.Drawing.Size(792, 444);
            this.tabPeople.TabIndex = 0;
            this.tabPeople.Text = "People";
            this.tabPeople.UseVisualStyleBackColor = true;
            // 
            // btnDeletePerson
            // 
            this.btnDeletePerson.Location = new System.Drawing.Point(606, 24);
            this.btnDeletePerson.Name = "btnDeletePerson";
            this.btnDeletePerson.Size = new System.Drawing.Size(93, 28);
            this.btnDeletePerson.TabIndex = 4;
            this.btnDeletePerson.Text = "Delete";
            this.btnDeletePerson.UseVisualStyleBackColor = true;
            this.btnDeletePerson.Click += new System.EventHandler(this.btnDeletePerson_Click);
            // 
            // lablePeopleSearch
            // 
            this.lablePeopleSearch.AutoSize = true;
            this.lablePeopleSearch.Location = new System.Drawing.Point(115, 29);
            this.lablePeopleSearch.Name = "lablePeopleSearch";
            this.lablePeopleSearch.Size = new System.Drawing.Size(137, 13);
            this.lablePeopleSearch.TabIndex = 3;
            this.lablePeopleSearch.Text = "Search by first or last name:";
            // 
            // txtPeopleSearchBar
            // 
            this.txtPeopleSearchBar.Location = new System.Drawing.Point(258, 22);
            this.txtPeopleSearchBar.Name = "txtPeopleSearchBar";
            this.txtPeopleSearchBar.Size = new System.Drawing.Size(144, 20);
            this.txtPeopleSearchBar.TabIndex = 2;
            this.txtPeopleSearchBar.TextChanged += new System.EventHandler(this.txtPeopleName_TextChanged);
            // 
            // gvPeople
            // 
            this.gvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPeople.Location = new System.Drawing.Point(65, 59);
            this.gvPeople.Name = "gvPeople";
            this.gvPeople.ReadOnly = true;
            this.gvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPeople.Size = new System.Drawing.Size(532, 385);
            this.gvPeople.TabIndex = 0;
            this.gvPeople.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPeople_CellContentClick);
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
            this.tabCars.Controls.Add(this.btnDeleteCar);
            this.tabCars.Controls.Add(this.txtCarsSearchBar);
            this.tabCars.Controls.Add(this.labelSearchCar);
            this.tabCars.Controls.Add(this.gvCars);
            this.tabCars.Location = new System.Drawing.Point(4, 22);
            this.tabCars.Name = "tabCars";
            this.tabCars.Padding = new System.Windows.Forms.Padding(3);
            this.tabCars.Size = new System.Drawing.Size(792, 444);
            this.tabCars.TabIndex = 4;
            this.tabCars.Text = "Cars";
            this.tabCars.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Location = new System.Drawing.Point(606, 24);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(93, 28);
            this.btnDeleteCar.TabIndex = 6;
            this.btnDeleteCar.Text = "Delete";
            this.btnDeleteCar.UseVisualStyleBackColor = true;
            this.btnDeleteCar.Click += new System.EventHandler(this.btnDeleteCar_Click);
            // 
            // txtCarsSearchBar
            // 
            this.txtCarsSearchBar.Location = new System.Drawing.Point(241, 22);
            this.txtCarsSearchBar.Name = "txtCarsSearchBar";
            this.txtCarsSearchBar.Size = new System.Drawing.Size(144, 20);
            this.txtCarsSearchBar.TabIndex = 5;
            this.txtCarsSearchBar.TextChanged += new System.EventHandler(this.txtCarsSearchBar_TextChanged);
            // 
            // labelSearchCar
            // 
            this.labelSearchCar.AutoSize = true;
            this.labelSearchCar.Location = new System.Drawing.Point(115, 29);
            this.labelSearchCar.Name = "labelSearchCar";
            this.labelSearchCar.Size = new System.Drawing.Size(120, 13);
            this.labelSearchCar.TabIndex = 4;
            this.labelSearchCar.Text = "Search by license plate:";
            // 
            // gvCars
            // 
            this.gvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCars.Location = new System.Drawing.Point(65, 59);
            this.gvCars.Name = "gvCars";
            this.gvCars.ReadOnly = true;
            this.gvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCars.Size = new System.Drawing.Size(532, 385);
            this.gvCars.TabIndex = 1;
            this.gvCars.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCars_CellContentClick);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.tabControl1);
            this.Name = "StartWindow";
            this.Text = "StartWindow";
            this.tabDestinations.ResumeLayout(false);
            this.tabDestinations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestinations)).EndInit();
            this.tabRides.ResumeLayout(false);
            this.tabRides.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRides)).EndInit();
            this.tabPeople.ResumeLayout(false);
            this.tabPeople.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabCars.ResumeLayout(false);
            this.tabCars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDestinations;
        private System.Windows.Forms.TabPage tabRides;
        private System.Windows.Forms.TabPage tabPeople;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView gvPeople;
        private System.Windows.Forms.Label lablePeopleSearch;
        private System.Windows.Forms.TextBox txtPeopleSearchBar;
        private System.Windows.Forms.Button btnDeletePerson;
        private System.Windows.Forms.TabPage tabCars;
        private System.Windows.Forms.TextBox txtCarsSearchBar;
        private System.Windows.Forms.Label labelSearchCar;
        private System.Windows.Forms.DataGridView gvCars;
        private System.Windows.Forms.Button btnDeleteCar;
        private System.Windows.Forms.DataGridView gvDestinations;
        private System.Windows.Forms.Button btnDeleteDestination;
        private System.Windows.Forms.TextBox txtDestinationsSearchBar;
        private System.Windows.Forms.Label labelDestinationSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvRides;
        private System.Windows.Forms.Button btnDeleteRide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRidesSearchBar;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}