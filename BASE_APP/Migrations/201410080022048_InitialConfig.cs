namespace BASE_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APP_MODULES",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModuleDescription = c.String(),
                        ParentModuleID = c.Int(),
                        AssociateForm = c.String(),
                        Activated = c.String(),
                        CloseForm = c.String(),
                        ParentModuleDescription = c.String(),
                        Ordem = c.Int(),
                        ImageIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.APP_PROFILE_CLASS",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ProfileID = c.Int(nullable: false),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.APP_PROFILES",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        ProfileDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            CreateTable(
                "dbo.APP_USERS",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserDescription = c.String(),
                        Password = c.String(),
                        ProfileID = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        Activated = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.APP_USERS");
            DropTable("dbo.APP_PROFILES");
            DropTable("dbo.APP_PROFILE_CLASS");
            DropTable("dbo.APP_MODULES");
        }
    }
}
