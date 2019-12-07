namespace Unigo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLongLatToDestinations : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Destinations SET Lat=57.032881, Long=9.909702 WHERE Id=1;");
            Sql("UPDATE Destinations SET Lat=57.021146, Long=9.8845332 WHERE Id=2;");
            Sql("UPDATE Destinations SET Lat=56.9683112, Long=8.6986318 WHERE Id=3;");
            Sql("UPDATE Destinations SET Lat=57.018556, Long=9.9474562 WHERE Id=4;");
            Sql("UPDATE Destinations SET Lat=57.0165082, Long=9.9927708 WHERE Id=5;");
            Sql("UPDATE Destinations SET Lat=57.4583602, Long=10.0026888 WHERE Id=6;");
        }
        
        public override void Down()
        {
        }
    }
}
