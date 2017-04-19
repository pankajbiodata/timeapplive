namespace DataEntities.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataEntities.Models;

    public  class TimeTable : DbContext
    {
        public TimeTable()
            : base("name=TimeTableEntities")
        {
        }

        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<tblCurriculum> tblCurriculum { get; set; }
        public virtual DbSet<tblSchools> tblSchools { get; set; }
        public virtual DbSet<tblSchoolYear> tblSchoolYear { get; set; }
        public virtual DbSet<tblSubject> tblSubject { get; set; }
        public virtual DbSet<tblSubjectOffering> tblSubjectOffering { get; set; }
        public virtual DbSet<tblUsers> tblUsers { get; set; }

        public virtual DbSet<tblAdviser> tblAdvisers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<Section>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCurriculum>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchools>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchools>()
                .Property(e => e.SchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchools>()
                .Property(e => e.SchoolAddress)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchools>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchools>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<tblSchoolYear>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblSubject>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblSubjectOffering>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.Designation)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsers>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);
        }
    }
}
