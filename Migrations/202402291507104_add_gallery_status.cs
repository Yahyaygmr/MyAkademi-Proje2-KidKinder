namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_gallery_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "Status");
        }
    }
}
