namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Room")]
    public partial class Room
    {
        [StringLength(50)]
        public string RoomID { get; set; }

        [StringLength(50)]
        public string RoomNo { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        public int? Capacity { get; set; }

        [StringLength(50)]
        public string SchoolID { get; set; }

        public virtual tblSchools tblSchools { get; set; }
    }
}
