namespace WEB_BASE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductsCategory", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductsCategory", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
