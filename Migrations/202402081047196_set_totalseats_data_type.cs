namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_totalseats_data_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClassRooms", "TotalSeats", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClassRooms", "TotalSeats", c => c.Int(nullable: false));
        }
    }
}
