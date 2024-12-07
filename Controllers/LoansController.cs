using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Services;
using api.DTOs;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(DataContext context, ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<ActionResult<LoanDTO>> CreateLoan([FromBody] CreateLoanDTO request)
        {
            var loan = await _loanService.CreateLoan(request);
            return Ok(loan);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<LoanDTO>>> GetAllLoans([FromQuery] bool? returned)
        {
            var loans = await _loanService.GetAllLoans(returned);
            return Ok(loans);
        }

        [HttpPut("finish")]
        public async Task<ActionResult> FinishLoan([FromQuery] Guid id)
        {
            await _loanService.FinishLoan(id);
            return Ok();
        }
    }
}
