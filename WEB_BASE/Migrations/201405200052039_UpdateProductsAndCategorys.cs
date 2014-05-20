namespace WEB_BASE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductsAndCategorys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductsCategory", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsCategory", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.ProductsCategory", "UpdatedDate");
            DropColumn("dbo.ProductsCategory", "UpdatedBy");
        }
    }
}
