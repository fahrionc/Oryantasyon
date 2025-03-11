namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_car : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCars",
                c => new
                    {
                        UserCarID = c.Int(nullable: false, identity: true),
                        ActiveWorkTime = c.Double(nullable: false),
                        MaintenanceTime = c.Double(nullable: false),
                        IdleTime = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserCarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCars");
        }
    }
}
