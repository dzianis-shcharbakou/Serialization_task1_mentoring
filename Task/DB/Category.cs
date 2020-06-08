namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [DataMember]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        [DataMember]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        [DataMember]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        [DataMember]
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            foreach (var product in Products)
            {
                product.Category = null;
                product.Order_Details = null;
                product.Supplier = null;
            }
        }

        [OnSerialized]
        void OnSerialized(StreamingContext context)
        {
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {

        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {

        }
    }
}
