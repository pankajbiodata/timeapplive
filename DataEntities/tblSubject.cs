namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblSubject")]
    public partial class tblSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSubject()
        {
            tblSubjectOffering = new HashSet<tblSubjectOffering>();
        }

        [Key]
        [StringLength(50)]
        public string SubjectCode { get; set; }

        [StringLength(50)]
        public string DescriptiveTitle { get; set; }

        [StringLength(50)]
        public string YearLevel { get; set; }

        [StringLength(50)]
        public string Units { get; set; }

        [StringLength(50)]
        public string HrsWk { get; set; }

        [StringLength(50)]
        public string CurriculumID { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual tblCurriculum tblCurriculum { get; set; }

        public virtual tblSchools tblSchools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSubjectOffering> tblSubjectOffering { get; set; }
    }
}
