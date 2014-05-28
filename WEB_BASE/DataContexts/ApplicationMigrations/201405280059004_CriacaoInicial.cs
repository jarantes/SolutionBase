namespace WEB_BASE.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductsCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductsCategory");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductsCategory");
        }
    }
}
