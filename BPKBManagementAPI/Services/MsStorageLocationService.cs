using BPKBManagementAPI.Data;
using BPKBManagementAPI.Data.ResultModel;
using Microsoft.EntityFrameworkCore;

namespace BPKBManagementAPI.Services
{
    public interface IMsStorageLocationService
    {
        public Task<List<MsStorageLocation>> GetMsStorageLocationListAsync();
    }
    public class MsStorageLocationService : IMsStorageLocationService
    {
        private readonly BPKBManagementAPIContext _dbContext;

        public MsStorageLocationService(BPKBManagementAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MsStorageLocation>> GetMsStorageLocationListAsync()
        {
            var msStorageLocationList = await (from msl in _dbContext.MsStorageLocation
                                    select msl).ToListAsync();

            return msStorageLocationList;
        }
    }
}
