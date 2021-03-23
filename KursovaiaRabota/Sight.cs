namespace KursovaiaRabota
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sight")]
    public partial class Sight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_sight { get; set; }

        [StringLength(20)]
        public string Sight_name { get; set; }

        public int? ID_city { get; set; }

        public virtual City City { get; set; }
    }
}
