namespace WEB_BASE.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFavoriteColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FavoriteColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FavoriteColor");
        }
    }
}
