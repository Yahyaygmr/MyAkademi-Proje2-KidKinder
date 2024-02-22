namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_relation_between_branch_and_teachers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "BranchId");
            AddForeignKey("dbo.Teachers", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "BranchId", "dbo.Branches");
            DropIndex("dbo.Teachers", new[] { "BranchId" });
            DropColumn("dbo.Teachers", "BranchId");
        }
    }
}
