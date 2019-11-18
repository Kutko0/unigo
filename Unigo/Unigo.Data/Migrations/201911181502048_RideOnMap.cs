namespace Unigo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RideOnMap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RideDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.RideOnMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RideDescriptionId = c.Int(nullable: false),
                        Start_Long = c.Double(nullable: false),
                        Start_Lat = c.Double(nullable: false),
                        Dest_Long = c.Double(nullable: false),
                        Dest_Lat = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RideDescriptions", t => t.RideDescriptionId, cascadeDelete: true)
                .Index(t => t.RideDescriptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RideOnMaps", "RideDescriptionId", "dbo.RideDescriptions");
            DropForeignKey("dbo.RideDescriptions", "DriverId", "dbo.People");
            
            DropIndex("dbo.RideOnMaps", new[] { "RideDescriptionId" });
            DropIndex("dbo.RideDescriptions", new[] { "DriverId" });
            
            DropTable("dbo.RideOnMaps");
            DropTable("dbo.RideDescriptions");
            
        }
    }
}
