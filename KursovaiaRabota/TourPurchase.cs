namespace KursovaiaRabota
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourPurchase")]
    public partial class TourPurchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_purchase { get; set; }

        public int? quantity { get; set; }

        public int? total_price { get; set; }

        public int? ID_client { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data { get; set; }

        public int? ID_tour { get; set; }

        public virtual Client Client { get; set; }

        public virtual Tour_on_date Tour_on_date { get; set; }
    }
}
