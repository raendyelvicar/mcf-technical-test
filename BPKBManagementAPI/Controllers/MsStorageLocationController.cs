using BPKBManagementAPI.Data;
using BPKBManagementAPI.Data.ResultModel;
using BPKBManagementAPI.Data.SubmitModel;
using BPKBManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BPKBManagementAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class MsStorageLocationController : ControllerBase
    {
        private readonly IMsStorageLocationService _msStorageLocationService;

        public MsStorageLocationController(IMsStorageLocationService msStorageLocationService)
        {
            this._msStorageLocationService = msStorageLocationService;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetMsStorageLocationListAsync()
        {
            try
            {
                var response =  await _msStorageLocationService.GetMsStorageLocationListAsync();
                return Ok(new BaseResult()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Data = response
                });
            }
            catch
            {
                throw;
            }
        }

       
    }
}
