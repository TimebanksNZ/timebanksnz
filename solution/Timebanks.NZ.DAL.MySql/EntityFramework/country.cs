namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timebanks.country")]
    public partial class country
    {
        [Key]
        public int id_country { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        [StringLength(3)]
        public string abbreviation { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? date_added { get; set; }
    }
}
