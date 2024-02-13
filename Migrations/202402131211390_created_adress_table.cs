namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_adress_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdressId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AdressDetail = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        OpeningHours = c.String(),
                    })
                .PrimaryKey(t => t.AdressId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adresses");
        }
    }
}
