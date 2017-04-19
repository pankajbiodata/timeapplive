namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblCurriculum")]
    public partial class tblCurriculum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCurriculum()
        {
            Section = new HashSet<Section>();
            tblSubject = new HashSet<tblSubject>();
        }

        [Key]
        [StringLength(50)]
        public string CurriculumID { get; set; }

        [StringLength(50)]
        public string CurriculumTitle { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section> Section { get; set; }

        public virtual tblSchools tblSchools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSubject> tblSubject { get; set; }
    }
}
