using Application.DTOs.AccountsDTO;
using Application.DTOs.BranchesDTO;
using Application.Features.Accounts.Requests.Commands;
using Application.Features.Accounts.Requests.Queries;
using Application.Features.Branches.Requests.Commands;
using Application.Features.Branches.Requests.Queries;
using Application.Features.Clients.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarSecurityAPI.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("v1/api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AccountsController(IMediator mediator)
		{
			_mediator = mediator;

		}
		// GET: api/<AccountsController>
		[HttpGet]
		public async Task<ActionResult<ICollection<GetAccountDTO>>> GetAllAccounts()
		{
			var accounts = await _mediator.Send(new GetAllAccountsRequest());
			return Ok(accounts); // Thêm Ok() để trả về một HTTP 200 OK response với dữ liệu đã lấy được
		}

		// GET api/<AccountsController>/5
		[HttpGet]
		[Route("Search/Id/{id}")]
		public async Task<ActionResult<GetAccountDTO>> GetAccountById(Guid id)
		{
			var query = new GetAccountByIdRequest() { Id = id };
			var account = await _mediator.Send(query);
			if (account != null)
			{
				return Ok(account);
			}
			return NotFound($"Account {id} not found!");
		}
		[HttpGet]
		[Route("Search/Email/{email}")]
		public async Task<ActionResult<GetAccountDTO>> GetAccountByEmail(string email)
		{
			var query = new GetAccountByEmailRequest() { Email = email };
			var account = await _mediator.Send(query);
			if (account != null)
			{
				return Ok(account);
			}
			return NotFound($"Account {email} not found!");
		}
		// POST api/<AccountsController>
		[HttpPost]
		public async Task<ActionResult> CreateAccount([FromBody] CreateAccountDTO createAccount)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new CreateAccountCommand() { CreateAccountDTO = createAccount };
			var response = await _mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<AccountsController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateAccount([FromBody] UpdateAccountDTO updateAccount)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new UpdateAccountCommand() { UpdateAccountDTO = updateAccount };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}

		// DELETE api/<AccountsController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAccount([FromBody] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new DeleteAccountCommand() { Id = id };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}
	}
}
