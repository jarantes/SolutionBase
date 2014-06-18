namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserAccess2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ModuleUserAccess", newName: "ModuleUserAccesses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ModuleUserAccesses", newName: "ModuleUserAccess");
        }
    }
}
