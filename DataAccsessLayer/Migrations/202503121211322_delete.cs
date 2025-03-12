namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCars", "CarID", "dbo.AdminCars");
            DropIndex("dbo.UserCars", new[] { "CarID" });
            DropTable("dbo.AdminCars");
            DropTable("dbo.UserCars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCars",
                c => new
                    {
                        UserCarID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        ActiveWorkTime = c.Double(nullable: false),
                        MaintenanceTime = c.Double(nullable: false),
                        IdleTime = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserCarID);
            
            CreateTable(
                "dbo.AdminCars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        CarName = c.String(maxLength: 50),
                        CarPlate = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateIndex("dbo.UserCars", "CarID");
            AddForeignKey("dbo.UserCars", "CarID", "dbo.AdminCars", "CarID", cascadeDelete: true);
        }
    }
}
