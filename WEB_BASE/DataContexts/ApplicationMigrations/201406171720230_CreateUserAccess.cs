namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserAccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuleUserAccess",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModuleUserAccess");
        }
    }
}
