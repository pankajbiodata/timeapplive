namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class tblUsers
    {
        [Key]
        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }
    }
}
