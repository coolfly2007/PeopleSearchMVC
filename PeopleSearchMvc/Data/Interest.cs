namespace PeopleSearchMvc.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interest")]
    public partial class Interest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Key]
        [Column("Interest", Order = 1)]
        [StringLength(5000)]
        public string Interest1 { get; set; }

        public virtual Person Person { get; set; }
    }
}
