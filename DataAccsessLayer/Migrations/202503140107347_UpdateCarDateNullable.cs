namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCarDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Date", c => c.DateTime(nullable: false));
        }
    }
}
