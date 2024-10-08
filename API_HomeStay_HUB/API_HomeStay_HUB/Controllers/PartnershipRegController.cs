using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnershipRegController : ControllerBase
    {
        private readonly IPartnershipRegService _regService;
        public PartnershipRegController(IPartnershipRegService regService)
        {
            _regService = regService;
        }
        [HttpGet("getbyStatus/{status}")]
        public async Task<IActionResult> getbyStatus(int status)
        {
            return Ok(await _regService.getbyStatus(status));
        }
        [HttpPost("registerPartnershipReg")]
        public async Task<IActionResult> registerPartnershipReg([FromBody] PartnershipReg partnership)
        {
            if (partnership == null)
            {
                return BadRequest("Not null Data");
            }
            else
            {
                if (await _regService.registerParterShip(partnership))
                {
                    return Ok("Register success");
                }
                return BadRequest("Register faild");

            }
        }
        [HttpGet("cancelPartReg/{idPart}/{rejectReson}")]
        public async Task<IActionResult> cancelPartReg(int idPart,string rejectReson)
        {
            bool check= await _regService.cancel_PartnerShip(idPart,rejectReson);
            return check ? Ok() : NotFound();
        }

        [HttpGet("confirmPartReg/{idPart}")]
        public async Task<IActionResult> confirmPartReg(int idPart)
        {
            bool check = await _regService.confirm_PartnerShip(idPart);
            return check ? Ok() : NotFound();
        }
    }
}
