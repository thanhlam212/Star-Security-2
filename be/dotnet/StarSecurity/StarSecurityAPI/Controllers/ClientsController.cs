using Application.DTOs.ClientsDTO;
using Application.Features.Clients.Requests.Commands;
using Application.Features.Clients.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarSecurityAPI.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("v1/api/[controller]")]
	[ApiController]
	public class ClientsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ClientsController(IMediator mediator)
		{
			_mediator = mediator;

		}
		// GET: api/<ClientsController>
		[HttpGet]
		public async Task<ActionResult<ICollection<GetClientDTO>>> GetAllClients()
		{
			var clients = await _mediator.Send(new GetAllClientRequest());
			return Ok(clients); // Thêm Ok() để trả về một HTTP 200 OK response với dữ liệu đã lấy được
		}

		// GET api/<ClientsController>/5
		[HttpGet]
		[Route("Search/Id/{id}")]
		public async Task<ActionResult<GetClientDTO>> GetClientById(Guid id)
		{
			var query = new GetClientByIdRequest() { Id = id };
			var client = await _mediator.Send(query);
			if (client != null)
			{
				return Ok(client);
			}
			return NotFound($"Client {id} not found!");
		}
		
		[HttpGet]
		[Route("Search/Email/{email}")]
		public async Task<ActionResult<GetClientDTO>> GetClientByEmail(string email)
		{
			var query = new GetClientByEmailRequest() { Email = email };
			var client = await _mediator.Send(query);
			if (client != null)
			{
				return Ok(client);
			}
			return NotFound($"Client {email} not found!");
		}
		
		[HttpGet]
		[Route("Search/YearOfBirth/{year-of-birth}")]
		public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClientsByYearOfBirth([FromQuery] int yearOfBirth)
		{
			try
			{
				var query = new GetClientByYearOfBirthRequest { YearOfBirth = yearOfBirth };
				var clients = await _mediator.Send(query);
				return Ok(clients);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		
		[HttpGet]
		[Route("Search/Gender/{gender}")]
		public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClientsByGender([FromQuery] string gender)
		{
			try
			{
				var query = new GetClientByGenderRequest { Gender = gender };
				var clients = await _mediator.Send(query);
				return Ok(clients);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		
		[HttpGet]
		[Route("Search/Name/{name}")]
		public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClientsByName([FromQuery] string name)
		{
			try
			{
				var query = new GetClientByNameRequest { Name = name };
				var clients = await _mediator.Send(query);
				return Ok(clients);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		// POST api/<ClientsController>
		[HttpPost]
		public async Task<ActionResult> CreateClient([FromBody] CreateClientDTO createClient)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new CreateClientCommand() { CreateClientDTO = createClient };
			var response = await _mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<ClientsController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateClient([FromBody] UpdateClientDTO updateClient)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new UpdateClientCommand() { UpdateClientDTO = updateClient };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}

		// DELETE api/<ClientsController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteClient([FromBody] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new DeleteClientCommand() { Id = id };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}
	}
}
