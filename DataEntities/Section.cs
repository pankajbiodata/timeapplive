namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Section")]
    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            tblSubjectOffering = new HashSet<tblSubjectOffering>();
        }

        [StringLength(50)]
        public string SectionID { get; set; }

        [StringLength(50)]
        public string YearLvl { get; set; }

        [StringLength(50)]
        public string SectionName { get; set; }

        [StringLength(50)]
        public string CurriculumID { get; set; }

        public int? MaxStudent { get; set; }

        public int? MaxGrade { get; set; }

        public int? MinGrade { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual tblCurriculum tblCurriculum { get; set; }

        public virtual tblSchools tblSchools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSubjectOffering> tblSubjectOffering { get; set; }
    }
}
