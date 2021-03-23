namespace KursovaiaRabota
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tour_on_date
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour_on_date()
        {
            TourPurchase = new HashSet<TourPurchase>();
        }

        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime data { get; set; }

        public int? onPrice { get; set; }

        public int? places { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_tour { get; set; }

        public virtual Tour Tour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourPurchase> TourPurchase { get; set; }
    }
}
