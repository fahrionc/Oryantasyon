namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_admin_car : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminCars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        CarName = c.String(maxLength: 50),
                        CarPlate = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminCars");
        }
    }
}
