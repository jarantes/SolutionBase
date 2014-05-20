namespace WEB_BASE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TratamentoDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
