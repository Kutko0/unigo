namespace Unigo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCars : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cars(RiderId, LicensePlate, Color, Type, NumberOfSeats, Brand, Description) " +
                "VALUES(4, 'KE46982', 'Blue', 'Lightning', 3, 'McQueen', 'Description')");
            Sql("INSERT INTO Cars(RiderId, LicensePlate, Color, Type, NumberOfSeats, Brand, Description) " +
                "VALUES(4, 'BA46982', 'Red', 'Chungus', 6, 'McQueen', 'Description')");
        }
        
        public override void Down()
        {
        }
    }
}
