namespace Unigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingDestination : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Destinations( Name) VALUES('Hobrovej 85')");
            Sql("INSERT INTO Destinations( Name) VALUES('Sofiendalsvej 60')");
            Sql("INSERT INTO Destinations( Name) VALUES('Lerpyttervej 43 (Thisted)')");
            Sql("INSERT INTO Destinations( Name) VALUES('Mylius Erichsens Vej 137')");
            Sql("INSERT INTO Destinations( Name) VALUES('Selma Lagerløfs Vej 2')");
            Sql("INSERT INTO Destinations( Name) VALUES('Skolevangen 45 (Hjørring)')");
        }
        
        public override void Down()
        {
        }
    }
}
