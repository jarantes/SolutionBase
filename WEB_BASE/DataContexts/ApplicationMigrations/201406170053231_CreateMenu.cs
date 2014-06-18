namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false),
                        Controller = c.String(nullable: false),
                        Action = c.String(nullable: false),
                        Icon = c.String(),
                        ParentModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Module", t => t.ParentModuleId)
                .Index(t => t.ParentModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "ParentModuleId", "dbo.Module");
            DropIndex("dbo.Modules", new[] { "ParentModuleId" });
            DropTable("dbo.Modules");
        }
    }
}
