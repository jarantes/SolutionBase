namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterNameTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ModuleUserAccesses", newName: "ModuleUserAccess");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ModuleUserAccess", newName: "ModuleUserAccesses");
        }
    }
}
