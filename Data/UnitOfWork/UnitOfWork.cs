using System;
using Data.GenericRepository;
using DataEntities.Models;
namespace Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private DataEntities.Models.TimeTable context = new DataEntities.Models.TimeTable();
        private GenericRepository<tblUsers> userRepository;
        private GenericRepository<tblSchools> schoolRepository;
        private GenericRepository<tblSubject> subjectRepository;
        private GenericRepository<tblSubjectOffering> subjectOfferingRepository;
        private GenericRepository<tblCurriculum> curriculumRepository;
        private GenericRepository<tblSchoolYear> schoolyearRepository;
        private GenericRepository<Section> sectionRepository;
        private GenericRepository<Faculty> facultyRepository;
        private GenericRepository<tblAdviser> adviserRepository;
        private GenericRepository<Room> roomRepository;

        public GenericRepository<tblUsers> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new GenericRepository<tblUsers>(context);
                return userRepository;
            }
        }
        public GenericRepository<tblSchools> SchoolRepository
        {
            get
            {
                if (this.schoolRepository == null)
                    this.schoolRepository = new GenericRepository<tblSchools>(context);
                return schoolRepository;
            }
        }
        public GenericRepository<tblSubject> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                    this.subjectRepository = new GenericRepository<tblSubject>(context);
                return subjectRepository;
            }
        }
        public GenericRepository<tblSubjectOffering> SubjectOfferingRepository
        {
            get
            {
                if (this.subjectOfferingRepository == null)
                    this.subjectOfferingRepository = new GenericRepository<tblSubjectOffering>(context);
                return subjectOfferingRepository;
            }
        }
        public GenericRepository<tblCurriculum> CurriculumRepository
        {
            get
            {
                if (this.curriculumRepository == null)
                    this.curriculumRepository = new GenericRepository<tblCurriculum>(context);
                return curriculumRepository;
            }
        }
        public GenericRepository<tblSchoolYear> SchoolyearRepository
        {
            get
            {
                if (this.schoolyearRepository == null)
                    this.schoolyearRepository = new GenericRepository<tblSchoolYear>(context);
                return schoolyearRepository;
            }
        }
        public GenericRepository<Section> SectionRepository
        {
            get
            {
                if (this.sectionRepository == null)
                    this.sectionRepository = new GenericRepository<Section>(context);
                return sectionRepository;
            }
        }
        public GenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (this.facultyRepository == null)
                    this.facultyRepository = new GenericRepository<Faculty>(context);
                return facultyRepository;
            }
        }
        public GenericRepository<tblAdviser> AdviserRepository
        {
            get
            {
                if (this.adviserRepository == null)
                    this.adviserRepository = new GenericRepository<tblAdviser>(context);
                return adviserRepository;
            }
        }
        public GenericRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository == null)
                    this.roomRepository = new GenericRepository<Room>(context);
                return roomRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}