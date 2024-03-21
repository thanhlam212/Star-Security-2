using application.Contracts.Persistences;
using application.DTOs.EmployeesDTO.Validators;
using application.Features.Employees.Requests.Commands;
using AutoMapper;
using domain.Common.Exceptions;
using domain.Entities;
using MediatR;

namespace application.Features.Employees.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UpdateEmployeeDTOValidator _validator;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            UpdateEmployeeDTOValidator validator,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.UpdateEmployeeDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var employee = await _employeeRepository.GetByIdAsync(request.UpdateEmployeeDTO.Id) 
                ?? throw new NotFoundException(nameof(Employee), request.UpdateEmployeeDTO.Id);
            _mapper.Map(request.UpdateEmployeeDTO, employee);

            var isUpdated = await _employeeRepository.UpdateAsync(employee);
            if (!isUpdated)
            {
                throw new Exception("No employee updated!!");
            }
            return Unit.Value;
        }
    }
}
