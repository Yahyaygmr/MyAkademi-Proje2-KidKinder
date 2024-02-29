namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_gallery_table_and_booaseat_classroom_connection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            AddColumn("dbo.BookASeats", "ClassRoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookASeats", "ClassRoomId");
            AddForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms", "ClassRoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.BookASeats", new[] { "ClassRoomId" });
            DropColumn("dbo.BookASeats", "ClassRoomId");
            DropTable("dbo.Galleries");
        }
    }
}
