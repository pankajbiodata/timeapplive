namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblSubjectOffering")]
    public partial class tblSubjectOffering
    {
        [Key]
        [StringLength(50)]
        public string SubjectOfferingID { get; set; }

        [StringLength(50)]
        public string SubjectCode { get; set; }

        [StringLength(50)]
        public string SectionID { get; set; }

        public DateTime? cTimeIn { get; set; }

        public DateTime? cTimeOut { get; set; }

        [StringLength(50)]
        public string cRoom { get; set; }

        [StringLength(50)]
        public string cDay { get; set; }

        [StringLength(50)]
        public string FacultyID { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual Section Section { get; set; }

        public virtual tblSchools tblSchools { get; set; }

        public virtual tblSubject tblSubject { get; set; }
    }
}
