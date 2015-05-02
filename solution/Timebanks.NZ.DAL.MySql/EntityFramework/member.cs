namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timebanks.members")]
    public partial class member
    {
        [Key]
        public Guid id_members { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string street_address_1 { get; set; }

        [StringLength(100)]
        public string street_address_2 { get; set; }

        [StringLength(50)]
        public string suburb { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(6)]
        public string postcode { get; set; }

        public int? timebank_id { get; set; }

        [StringLength(20)]
        public string mobile_phone { get; set; }

        [StringLength(20)]
        public string home_phone { get; set; }

        [StringLength(20)]
        public string work_phone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created { get; set; }

        public bool approved { get; set; }

        public double geo_lat { get; set; }

        public double geo_long { get; set; }

        public bool address_privacy { get; set; }

        public bool phone_privacy { get; set; }

        [Required]
        [StringLength(100)]
        public string primary_email { get; set; }

        [StringLength(100)]
        public string secondary_email { get; set; }
    }
}
