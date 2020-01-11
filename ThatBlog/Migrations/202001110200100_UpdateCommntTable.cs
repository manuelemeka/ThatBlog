namespace ThatBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommntTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentModel", "blogid", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentModel", "blogid");
        }
    }
}
