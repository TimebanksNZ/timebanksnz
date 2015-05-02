namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timebanks.categories")]
    public partial class category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_category { get; set; }

        [Column(TypeName = "bit")]
        public bool is_parent { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dateadded { get; set; }
    }
}
