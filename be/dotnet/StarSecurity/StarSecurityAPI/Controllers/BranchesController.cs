using Application.DTOs.BranchesDTO;
using Application.Features.Branches.Requests.Commands;
using Application.Features.Branches.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarSecurityAPI.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/v1/[controller]")]
	[ApiController]
	public class BranchesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BranchesController(IMediator mediator)
        {
			_mediator = mediator;

		}
		// GET: api/<BranchesController>
		[HttpGet]
		public async Task<ActionResult<ICollection<GetBranchDTO>>> GetAllBranches()
		{
			var branches = await _mediator.Send(new GetAllBranchesRequest());
			return Ok(branches); // Thêm Ok() để trả về một HTTP 200 OK response với dữ liệu đã lấy được
		}

		// GET api/<BranchesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<GetBranchDTO>> GetBranchById(Guid id)
		{
			var query = new GetBranchByIdRequest() { Id = id };
			var branch = await _mediator.Send(query);
			if (branch != null)
			{
				return Ok(branch);
			}
			return NotFound($"Branch {id} not found!");
		}
		// POST api/<BranchesController>
		[HttpPost]
		public async Task<ActionResult> CreateBranch([FromBody] CreateBranchDTO createBranch)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new CreateBranchCommand() { CreateBranchDTO = createBranch };
			var response = await _mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<BranchesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateBranch([FromBody] UpdateBranchDTO updateBranch)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new UpdateBranchCommand() { UpdateBranchDTO = updateBranch };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}

		// DELETE api/<BranchesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteBranch([FromBody] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new DeleteBranchCommand() { Id = id };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}
	}
}
