namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdminRolr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRolr", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdminRole");
        }
    }
}
