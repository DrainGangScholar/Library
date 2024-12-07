using api.Core.DTOs;
using api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController(ILoanService loanService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoanDTO>> CreateLoan([FromBody] CreateLoanDTO request)
        {
            var loan = await loanService.CreateLoan(request);
            return Ok(loan);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<LoanDTO>>> GetAllLoans([FromQuery] bool? returned)
        {
            var loans = await loanService.GetAllLoans(returned);
            return Ok(loans);
        }

        [HttpPut("finish")]
        public async Task<ActionResult> FinishLoan([FromQuery] Guid id)
        {
            await loanService.FinishLoan(id);
            return Ok();
        }
    }
}
