using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BPKBManagementAPI.Data
{
    [Table("tr_bpkb")]
    public class TrBpkb
    {
        [Key]
        [Column("agreement_number")] // Specify the column name in snake_case
        [StringLength(100)]
        public string AgreementNumber { get; set; }

        [Required]
        [Column("bpkb_no")]
        [StringLength(100)]
        public string BpkbNo { get; set; }

        [Required]
        [Column("branch_id")]
        [StringLength(10)]
        public string BranchId { get; set; }

        [Required]
        [Column("bpkb_date")]
        public DateTime BpkbDate { get; set; }

        [Required]
        [Column("faktur_no")]
        [StringLength(100)]
        public string FakturNo { get; set; }

        [Required]
        [Column("faktur_date")]
        public DateTime FakturDate { get; set; }

        [Required]
        [Column("location_id")]
        [StringLength(10)]
        public string LocationId { get; set; }

        [Required]
        [Column("police_no")]
        [StringLength(20)]
        public string PoliceNo { get; set; }

        [Required]
        [Column("bpkb_date_in")]
        public DateTime BpkbDateIn { get; set; }

        [Column("created_by")]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_updated_by")]
        [StringLength(20)]
        public string? LastUpdatedBy { get; set; }

        [Column("last_updated_on")]
        public DateTime? LastUpdatedOn { get; set; }

        [ForeignKey("LocationId")]
        public MsStorageLocation StorageLocation { get; set; }
    }
}
