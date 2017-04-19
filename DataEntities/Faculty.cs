namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Faculty")]
    public partial class Faculty
    {
        [StringLength(50)]
        public string FacultyID { get; set; }

        [StringLength(50)]
        public string LName { get; set; }

        [StringLength(50)]
        public string FName { get; set; }

        [StringLength(50)]
        public string MName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string OnService { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual tblSchools tblSchools { get; set; }
    }
}
