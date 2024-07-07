using BPKBManagementAPI.Data;
using BPKBManagementAPI.Data.ResultModel;
using BPKBManagementAPI.Data.SubmitModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BPKBManagementAPI.Services
{

    public interface ITrBpkbService
    {
        public Task<List<TrBpkbResultModel>> GetTrBpkbListAsync();
        public Task<IEnumerable<TrBpkb>> GetTrBpkbByAgreementNumberAsync(string agreementNumber);
        public Task<int> AddTrBpkbAsync(TrBpkbSubmitModel trBpkb);
        public Task<int> UpdateTrBpkbAsync(TrBpkbSubmitModel trBpkb);
    }

    public class TrBpkbService : ITrBpkbService
    {
        private readonly BPKBManagementAPIContext _dbContext;

        public TrBpkbService(BPKBManagementAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddTrBpkbAsync(TrBpkbSubmitModel trBpkb)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@AgreementNumber", trBpkb.AgreementNumber));
            parameter.Add(new SqlParameter("@BranchId", trBpkb.BranchId));
            parameter.Add(new SqlParameter("@BpkbNo", trBpkb.BpkbNo));
            parameter.Add(new SqlParameter("@BpkbDateIn", trBpkb.BpkbDateIn));
            parameter.Add(new SqlParameter("@BpkbDate", trBpkb.BpkbDate));
            parameter.Add(new SqlParameter("@FakturNo", trBpkb.FakturNo));
            parameter.Add(new SqlParameter("@FakturDate", trBpkb.FakturDate));
            parameter.Add(new SqlParameter("@PoliceNo", trBpkb.PoliceNo));
            parameter.Add(new SqlParameter("@LocationId", trBpkb.LocationId));
            parameter.Add(new SqlParameter("@CreatedBy", "raendy"));
            parameter.Add(new SqlParameter("@CreatedOn", DateTime.UtcNow.AddHours(7)));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewTrBpkb @AgreementNumber, 
                                                    @BranchId, 
                                                    @BpkbNo, 
                                                    @BpkbDateIn, 
                                                    @BpkbDate, 
                                                    @FakturNo, 
                                                    @FakturDate, 
                                                    @PoliceNo, 
                                                    @LocationId, 
                                                    @CreatedBy, 
                                                    @CreatedOn", parameter.ToArray()));

            return result;
        }

        public async Task<IEnumerable<TrBpkb>> GetTrBpkbByAgreementNumberAsync(string agreementNumber)
        {
            var param = new SqlParameter("@AgreementNumber", agreementNumber);

            var trBpkbDetails = await Task.Run(() => _dbContext.TrBpkb
                            .FromSqlRaw(@"exec GetTrBpkbByAgreementNumber @AgreementNumber", param).ToListAsync());

            return trBpkbDetails;
        }

        public async Task<List<TrBpkbResultModel>> GetTrBpkbListAsync()
        {
            var trBpkbList = await (from tb in _dbContext.TrBpkb
                                    join sl in _dbContext.MsStorageLocation
                                    on tb.LocationId equals sl.LocationId
                                    select new TrBpkbResultModel
                                    {
                                        AgreementNumber = tb.AgreementNumber,
                                        BpkbNo = tb.BpkbNo ,
                                        BranchId = tb.BranchId,
                                        BpkbDate = tb.BpkbDate,
                                        FakturNo = tb.FakturNo,
                                        FakturDate = tb.FakturDate,
                                        PoliceNo = tb.PoliceNo,
                                        BpkbDateIn = tb.BpkbDateIn,
                                        CreatedBy = tb.CreatedBy,
                                        CreatedOn = tb.CreatedOn,
                                        LastUpdatedBy = tb.LastUpdatedBy,
                                        LastUpdatedOn = tb.LastUpdatedOn,
                                        LocationName = sl.LocationName
                                    }).ToListAsync();

            return trBpkbList;
        }   

        public async Task<int> UpdateTrBpkbAsync(TrBpkbSubmitModel trBpkb)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@AgreementNumber", trBpkb.AgreementNumber));
            parameter.Add(new SqlParameter("@BranchId", trBpkb.BranchId));
            parameter.Add(new SqlParameter("@BpkbNo", trBpkb.BpkbNo));
            parameter.Add(new SqlParameter("@BpkbDateIn", trBpkb.BpkbDateIn));
            parameter.Add(new SqlParameter("@BpkbDate", trBpkb.BpkbDate));
            parameter.Add(new SqlParameter("@FakturNo", trBpkb.FakturNo));
            parameter.Add(new SqlParameter("@FakturDate", trBpkb.FakturDate));
            parameter.Add(new SqlParameter("@PoliceNo", trBpkb.PoliceNo));
            parameter.Add(new SqlParameter("@LocationId", trBpkb.LocationId));
            parameter.Add(new SqlParameter("@LastUpdatedBy", trBpkb.LastUpdatedBy));
            parameter.Add(new SqlParameter("@LastUpdatedOn", trBpkb.LastUpdatedOn));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec UpdateTrBpkb @AgreementNumber, 
                                                    @BranchId, 
                                                    @BpkbNo, 
                                                    @BpkbDateIn, 
                                                    @BpkbDate, 
                                                    @FakturNo, 
                                                    @FakturDate, 
                                                    @PoliceNo, 
                                                    @LocationId,
                                                    @LastUpdatedBy,
                                                    @LastUpdatedOn", parameter.ToArray()));

            return result;
        }
    }
}
