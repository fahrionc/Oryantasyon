namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_dateee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Date", c => c.DateTime());
        }
    }
}
