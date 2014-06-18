namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMenu4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Modules", new[] { "ParentModuleId" });
            AlterColumn("dbo.Modules", "ParentModuleId", c => c.Int());
            CreateIndex("dbo.Modules", "ParentModuleId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Modules", new[] { "ParentModuleId" });
            AlterColumn("dbo.Modules", "ParentModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Modules", "ParentModuleId");
        }
    }
}
