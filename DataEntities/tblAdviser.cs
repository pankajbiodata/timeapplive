namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblAdviser")]
    public partial class tblAdviser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAdviser()
        {
            Faculty = new HashSet<Faculty>();
        }
        [Key]
        [StringLength(50)]
        public string AdviserID { get; set; }

        [StringLength(50)]
        public string FacultyID { get; set; }

        [StringLength(50)]
        public string SectionID { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }


        public virtual tblSchools tblSchools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faculty> Faculty { get; set; }
    }
}
