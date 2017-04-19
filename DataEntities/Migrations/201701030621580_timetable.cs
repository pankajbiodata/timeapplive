namespace DataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        DayName = c.String(maxLength: 50),
                        DayInitial = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyID = c.String(nullable: false, maxLength: 50),
                        LName = c.String(maxLength: 50),
                        FName = c.String(maxLength: 50),
                        MName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Contact = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        OnService = c.String(maxLength: 50),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.FacultyID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblSchools",
                c => new
                    {
                        SchoolID = c.String(nullable: false, maxLength: 50, unicode: false),
                        SchoolName = c.String(maxLength: 50, unicode: false),
                        SchoolAddress = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SchoolID);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomID = c.String(nullable: false, maxLength: 50),
                        RoomNo = c.String(maxLength: 50),
                        Building = c.String(maxLength: 50),
                        Capacity = c.Int(),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        SectionID = c.String(nullable: false, maxLength: 50),
                        YearLvl = c.String(maxLength: 50),
                        SectionName = c.String(maxLength: 50),
                        CurriculumID = c.String(maxLength: 50),
                        MaxStudent = c.Int(),
                        MaxGrade = c.Int(),
                        MinGrade = c.Int(),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.tblCurriculum", t => t.CurriculumID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.CurriculumID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblCurriculum",
                c => new
                    {
                        CurriculumID = c.String(nullable: false, maxLength: 50),
                        CurriculumTitle = c.String(maxLength: 50),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CurriculumID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblSubject",
                c => new
                    {
                        SubjectCode = c.String(nullable: false, maxLength: 50),
                        DescriptiveTitle = c.String(maxLength: 50),
                        YearLevel = c.String(maxLength: 50),
                        Units = c.String(maxLength: 50),
                        HrsWk = c.String(maxLength: 50),
                        CurriculumID = c.String(maxLength: 50),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SubjectCode)
                .ForeignKey("dbo.tblCurriculum", t => t.CurriculumID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.CurriculumID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblSubjectOffering",
                c => new
                    {
                        SubjectOfferingID = c.String(nullable: false, maxLength: 50),
                        SubjectCode = c.String(maxLength: 50),
                        SectionID = c.String(maxLength: 50),
                        cTimeIn = c.DateTime(),
                        cTimeOut = c.DateTime(),
                        cRoom = c.String(maxLength: 50),
                        cDay = c.String(maxLength: 50),
                        FacultyID = c.String(maxLength: 50),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SubjectOfferingID)
                .ForeignKey("dbo.Section", t => t.SectionID)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .ForeignKey("dbo.tblSubject", t => t.SubjectCode)
                .Index(t => t.SubjectCode)
                .Index(t => t.SectionID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblSchoolYear",
                c => new
                    {
                        SchoolYear = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SchoolYear)
                .ForeignKey("dbo.tblSchools", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 50, unicode: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 50, unicode: false),
                        PhoneNo = c.String(maxLength: 50, unicode: false),
                        Designation = c.String(maxLength: 50, unicode: false),
                        SchoolID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSchoolYear", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.Section", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.tblSubjectOffering", "SubjectCode", "dbo.tblSubject");
            DropForeignKey("dbo.tblSubjectOffering", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.tblSubjectOffering", "SectionID", "dbo.Section");
            DropForeignKey("dbo.tblSubject", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.tblSubject", "CurriculumID", "dbo.tblCurriculum");
            DropForeignKey("dbo.tblCurriculum", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.Section", "CurriculumID", "dbo.tblCurriculum");
            DropForeignKey("dbo.Room", "SchoolID", "dbo.tblSchools");
            DropForeignKey("dbo.Faculty", "SchoolID", "dbo.tblSchools");
            DropIndex("dbo.tblSchoolYear", new[] { "SchoolID" });
            DropIndex("dbo.tblSubjectOffering", new[] { "SchoolID" });
            DropIndex("dbo.tblSubjectOffering", new[] { "SectionID" });
            DropIndex("dbo.tblSubjectOffering", new[] { "SubjectCode" });
            DropIndex("dbo.tblSubject", new[] { "SchoolID" });
            DropIndex("dbo.tblSubject", new[] { "CurriculumID" });
            DropIndex("dbo.tblCurriculum", new[] { "SchoolID" });
            DropIndex("dbo.Section", new[] { "SchoolID" });
            DropIndex("dbo.Section", new[] { "CurriculumID" });
            DropIndex("dbo.Room", new[] { "SchoolID" });
            DropIndex("dbo.Faculty", new[] { "SchoolID" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblSchoolYear");
            DropTable("dbo.tblSubjectOffering");
            DropTable("dbo.tblSubject");
            DropTable("dbo.tblCurriculum");
            DropTable("dbo.Section");
            DropTable("dbo.Room");
            DropTable("dbo.tblSchools");
            DropTable("dbo.Faculty");
            DropTable("dbo.Day");
        }
    }
}
