namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMenu2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Module", newName: "Modules");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Modules", newName: "Module");
        }
    }
}
