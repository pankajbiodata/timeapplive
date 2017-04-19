namespace DataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adviser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdviser",
                c => new
                    {
                        AdviserID = c.String(nullable: false, maxLength: 50),
                        FacultyID = c.String(maxLength: 50),
                        SectionID = c.String(maxLength: 50),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.AdviserID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
            AddColumn("dbo.Faculty", "tblAdviser_AdviserID", c => c.String(maxLength: 50));
            CreateIndex("dbo.Faculty", "tblAdviser_AdviserID");
            AddForeignKey("dbo.Faculty", "tblAdviser_AdviserID", "dbo.tblAdviser", "AdviserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAdviser", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.Faculty", "tblAdviser_AdviserID", "dbo.tblAdviser");
            DropIndex("dbo.tblAdviser", new[] { "SchoolID" });
            DropIndex("dbo.Faculty", new[] { "tblAdviser_AdviserID" });
            DropColumn("dbo.Faculty", "tblAdviser_AdviserID");
            DropTable("dbo.tblAdviser");
        }
    }
}
