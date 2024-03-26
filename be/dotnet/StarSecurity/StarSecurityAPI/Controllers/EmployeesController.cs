using Application.DTOs.EmployeesDTO;
using Application.Features.Employees.Requests.Commands;
using Application.Features.Employees.Requests.Queries;
using Application.Features.Employees.Requests.Queries.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarSecurityAPI.Controllers
{
	//[Authorize(Roles = "Admin")]
	[Route("v1/api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EmployeesController(IMediator mediator)
		{
			_mediator = mediator;

		}
		// GET: api/<EmployeesController>
		[HttpGet]
		public async Task<ActionResult<ICollection<GetEmployeeDTO>>> GetAllEmployees()
		{
			var employees = await _mediator.Send(new GetAllEmployeeRequest());
			return Ok(employees); // Thêm Ok() để trả về một HTTP 200 OK response với dữ liệu đã lấy được
		}

		// GET api/<EmployeesController>/5
		[HttpGet]
		[Route("Search/Id/{id}")]
		public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeById(Guid id)
		{
			var query = new GetEmployeeByIdRequest() { Id = id };
			var employee = await _mediator.Send(query);
			if (employee != null)
			{
				return Ok(employee);
			}
			return NotFound($"Employee {id} not found!");
		}

		[HttpGet]
		[Route("Search/Email/{email}")]
		public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeByEmail(string email)
		{
			var query = new GetEmployeeByEmailRequest() { Email = email };
			var employee = await _mediator.Send(query);
			if (employee != null)
			{
				return Ok(employee);
			}
			return NotFound($"Employee {email} not found!");
		}
		[HttpGet]
		[Route("Search/EmployeeCode/{employeeCode}")]
		public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeByEmployeeCode(string employeeCode)
		{
			var query = new GetEmployeeByEmployeeCodeRequest() { EmployeeCode = employeeCode };
			var employee = await _mediator.Send(query);
			if (employee != null)
			{
				return Ok(employee);
			}
			return NotFound($"Employee {employeeCode} not found!");
		}

		[HttpGet]
		[Route("Search/YearOfBirth/{year-of-birth}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeessByYearOfBirth([FromQuery] int yearOfBirth)
		{
			try
			{
				var query = new GetListEmployeeByYearOfBirthRequest { YearOfBirth = yearOfBirth };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("Search/Gender/{gender}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeesByGender([FromQuery] string gender)
		{
			try
			{
				var query = new GetListEmployeeByGenderRequest { Gender = gender };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("Search/Name/{name}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeesByName([FromQuery] string name)
		{
			try
			{
				var query = new GetListEmployeeByNameRequest { Name = name };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[HttpGet]
		[Route("Search/Role/{role}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetListEmployeeByRole([FromQuery] string role)
		{
			try
			{
				var query = new GetListEmployeeByRoleRequest { Role = role };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[HttpGet]
		[Route("Search/ProvideService/{provideService}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetListEmployeeByProvideService([FromQuery] string provideService)
		{
			try
			{
				var query = new GetListEmployeeByProvideServiceRequest { ProvideService = provideService };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[HttpGet]
		[Route("Search/Branch/{branchId}")]
		public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetListEmployeeByBranchId([FromQuery] Guid branchId)
		{
			try
			{
				var query = new GetListEmployeeByBranchIdRequest { BranchId = branchId };
				var employees = await _mediator.Send(query);
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		// POST api/<EmployeesController>
		[HttpPost]
		public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDTO createEmployee)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new CreateEmployeeCommand() { CreateEmployeeDTO = createEmployee };
			var response = await _mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<EmployeesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO updateEmployee)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new UpdateEmployeeCommand() { UpdateEmployeeDTO = updateEmployee };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployee([FromBody] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var command = new DeleteEmployeeCommand() { Id = id };
			var response = await _mediator.Send(command);

			return Ok(response);
			//return NoCotnent();
		}
	}
}
