namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timebanks.offer_need")]
    public partial class offer_need
    {
        [Key]
        public int id_offer_need { get; set; }

        public bool is_offer { get; set; }

        public int id_user { get; set; }

        public double geo_lat { get; set; }

        public double geo_long { get; set; }

        public DateTime created { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }
    }
}
