namespace ThatBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbTables1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
