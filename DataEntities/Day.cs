namespace DataEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Day")]
    public partial class Day
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string DayName { get; set; }

        [StringLength(50)]
        public string DayInitial { get; set; }
    }
}
