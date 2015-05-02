namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timebanks.timebanks")]
    public partial class timebank
    {
        [Key]
        public int id_timebank { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string url { get; set; }

        public double? geo_long { get; set; }

        public double? geo_lat { get; set; }

        [Required]
        [StringLength(100)]
        public string Address_1 { get; set; }

        [StringLength(100)]
        public string Address_2 { get; set; }

        [StringLength(100)]
        public string suburb { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(6)]
        public string Postcode { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_member_timebanknz { get; set; }

        public int? id_country { get; set; }

        public int? id_theme { get; set; }
    }
}
