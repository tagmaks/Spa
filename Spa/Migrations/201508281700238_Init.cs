namespace Spa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CustomerGroupId", "dbo.CustomerGroups");
            AddForeignKey("dbo.AspNetUsers", "CustomerGroupId", "dbo.CustomerGroups", "CustomerGroupId");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "CustomerGroupId", "dbo.CustomerGroups");
            AddForeignKey("dbo.AspNetUsers", "CustomerGroupId", "dbo.CustomerGroups", "CustomerGroupId", cascadeDelete: true);
        }
    }
}
