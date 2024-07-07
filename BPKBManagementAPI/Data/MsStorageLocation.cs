using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPKBManagementAPI.Data
{
    [Table("ms_storage_location")]
    public class MsStorageLocation
    {
        [Key]
        [Column("location_id")]
        [StringLength(10)]
        public string LocationId { get; set; }

        [Column("location_name")]
        [StringLength(100)]
        public string LocationName { get; set; }

        public ICollection<TrBpkb> TrBpkbs { get; set; }
    }
}
