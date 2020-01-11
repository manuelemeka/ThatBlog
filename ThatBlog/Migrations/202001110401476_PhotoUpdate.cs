namespace ThatBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogModel", "photo", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogModel", "photo");
        }
    }
}
