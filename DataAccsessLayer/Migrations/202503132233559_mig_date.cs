namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Date");
        }
    }
}
