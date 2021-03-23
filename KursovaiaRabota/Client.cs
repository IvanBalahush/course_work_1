namespace KursovaiaRabota
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            TourPurchase = new HashSet<TourPurchase>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_client { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string Client_country { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        public int? Age { get; set; }

        public int? id_country { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        [StringLength(20)]
        public string isAdmin { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourPurchase> TourPurchase { get; set; }
    }
}
