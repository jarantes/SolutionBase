namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMenu3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modules", "Controller", c => c.String());
            AlterColumn("dbo.Modules", "Action", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "Action", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "Controller", c => c.String(nullable: false));
        }
    }
}
