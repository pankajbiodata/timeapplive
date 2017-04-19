namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblSchoolYear")]
    public partial class tblSchoolYear
    {
        [Key]
        [StringLength(50)]
        public string SchoolYear { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual tblSchools tblSchools { get; set; }
    }
}
