namespace Unigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberOfSeatsToRide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rides", "NumberOfSeats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rides", "NumberOfSeats");
        }
    }
}
