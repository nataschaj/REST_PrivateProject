namespace REST_PrivateProject
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catch")]
    public partial class Catchings
    {

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Species { get; set; }

        public decimal Weigtht { get; set; }

        [Required]
        [StringLength(30)]
        public string Place { get; set; }

        public int Week { get; set; }
    }
}