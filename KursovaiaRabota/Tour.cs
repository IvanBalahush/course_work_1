namespace KursovaiaRabota
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Tour_on_date = new HashSet<Tour_on_date>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_tour { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        public decimal? cost { get; set; }

        public int? ID_hotel { get; set; }

        public int? price { get; set; }

        [StringLength(20)]
        public string passage { get; set; }

        [StringLength(20)]
        public string residence { get; set; }

        [StringLength(20)]
        public string food { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_on_date> Tour_on_date { get; set; }
        public override string ToString()
        {
            return $"{Convert.ToString(cost)}";
        }
    }
}
