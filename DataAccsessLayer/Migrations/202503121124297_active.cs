﻿namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class active : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "IsActive");
        }
    }
}
