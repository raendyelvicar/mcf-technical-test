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
    public class TrBpkbController : ControllerBase
    {
        private readonly ITrBpkbService _trBpkbService;

        public TrBpkbController(ITrBpkbService trBpkbService)
        {
            this._trBpkbService = trBpkbService;
        }

        [HttpGet("bpkbs")]
        public async Task<IActionResult> GetTrBpkbListAsync()
        {
            try
            {
                var response =  await _trBpkbService.GetTrBpkbListAsync();
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

        [HttpGet("bpkb/{aggrementNumber}")]
        public async Task<IActionResult> GetTrBpkbByAgreementNumberAsync(string aggrementNumber)
        {
            try
            {
                var response = await _trBpkbService.GetTrBpkbByAgreementNumberAsync(aggrementNumber);

                if (response == null)
                {
                    return null;
                }

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

        [HttpPost("bpkb")]
        public async Task<IActionResult> AddTrBpkbAsync(TrBpkbSubmitModel TrBpkb)
        {
            if (TrBpkb == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _trBpkbService.AddTrBpkbAsync(TrBpkb);

                return Ok(new {Message = "Data berhasil ditambahkan."});
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("bpkb")]
        public async Task<IActionResult> UpdateTrBpkbAsync(TrBpkbSubmitModel TrBpkb)
        {
            if (TrBpkb == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _trBpkbService.UpdateTrBpkbAsync(TrBpkb);
                return Ok(new { Message = "Data berhasil diubah." });
            }
            catch
            {
                throw;
            }
        }
    }
}
