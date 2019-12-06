namespace Unigo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Destinations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Brand", c => c.String());
            AddColumn("dbo.Cars", "Description", c => c.String());
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Hobrovej 85', 57.032881, 9.909702)");
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Sofiendalsvej 60', 57.021146, 9.8845332)");
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Lerpyttervej 43 (Thisted)', 56.9683112, 8.6986318)");
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Mylius Erichsens Vej 137', 57.018556, 9.9474562)");
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Selma Lagerløfs Vej 2', 57.0165082, 9.9927708)");
            Sql("INSERT INTO Destinations( Name, Lat, Long) VALUES('Skolevangen 45 (Hjørring)', 57.4583602, 10.0026888)");
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Description");
            DropColumn("dbo.Cars", "Brand");
        }
    }
}
