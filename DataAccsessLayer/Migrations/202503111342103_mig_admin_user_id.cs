namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_user_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCars", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserCars", "CarID");
            AddForeignKey("dbo.UserCars", "CarID", "dbo.AdminCars", "CarID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCars", "CarID", "dbo.AdminCars");
            DropIndex("dbo.UserCars", new[] { "CarID" });
            DropColumn("dbo.UserCars", "CarID");
        }
    }
}
