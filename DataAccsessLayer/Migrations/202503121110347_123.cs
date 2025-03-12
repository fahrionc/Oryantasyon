namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "ActiveWorkTime", c => c.Double());
            AlterColumn("dbo.Cars", "MaintenanceTime", c => c.Double());
            AlterColumn("dbo.Cars", "IdleTime", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "IdleTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "MaintenanceTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "ActiveWorkTime", c => c.Double(nullable: false));
        }
    }
}
