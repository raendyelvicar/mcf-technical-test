using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BPKBManagementAPI.Data.ResultModel
{
    public class TrBpkbResultModel
    {
        [Column("agreement_number")] // Specify the column name in snake_case
        public string AgreementNumber { get; set; }

        [Column("bpkb_no")]
        public string BpkbNo { get; set; }

        [Column("branch_id")]
        public string BranchId { get; set; }

        [Column("bpkb_date")]
        public DateTime BpkbDate { get; set; }

        public string? BpkbDateString
        {
            get
            {
                return BpkbDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
            }
        }

        [Column("faktur_no")]
        public string FakturNo { get; set; }

        [Column("faktur_date")]
        public DateTime FakturDate { get; set; }
        public string? FakturDateString
        {
            get
            {
                return FakturDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
            }
        }

        [Column("location_name")]
        public string LocationName { get; set; }

        [Column("police_no")]
        public string PoliceNo { get; set; }

        [Column("bpkb_date_in")]
        public DateTime BpkbDateIn { get; set; }

        public string? BpkbDateInString
        {
            get
            {
                return BpkbDateIn.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
            }
        }

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
        public string? CreatedOnString { 
            get { 
                return CreatedOn.HasValue ? CreatedOn.Value.ToString("dd MMMM yyyy", new CultureInfo("id-ID")) : "";
            } 
        }

        [Column("last_updated_by")]
        public string? LastUpdatedBy { get; set; }

        [Column("last_updated_on")]
        public DateTime? LastUpdatedOn { get; set; }
        public string? LastUpdatedOnString
        {
            get
            {
                return LastUpdatedOn.HasValue ? LastUpdatedOn.Value.ToString("dd MMMM yyyy", new CultureInfo("id-ID")) : "";
            }
        }
    }
}
