using application.Contracts.Persistences;
using application.DTOs.EmployeesDTO.Validators;
using application.Features.Employees.Requests.Commands;
using domain.Common.Exceptions;
using domain.Common.ValueObjects;
using domain.Entities;
using MediatR;

namespace application.Features.Employees.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly CreateEmployeeDTOValidator _validator;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            CreateEmployeeDTOValidator validator
            )
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateEmployeeDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var employee = new Employee(
                new Name(request.CreateEmployeeDTO.Name),
                request.CreateEmployeeDTO.Gender,
                request.CreateEmployeeDTO.Address,
                request.CreateEmployeeDTO.ContactNumber,
                new Email(request.CreateEmployeeDTO.Email),
                request.CreateEmployeeDTO.EmployeeCode,
                request.CreateEmployeeDTO.EducationalQualification,
                request.CreateEmployeeDTO.Role,
                request.CreateEmployeeDTO.Grade,
                request.CreateEmployeeDTO.Achievements,
                request.CreateEmployeeDTO.ProvideService,
                request.CreateEmployeeDTO.BranchId,
                request.CreateEmployeeDTO.CurrentOfferId);
            var isCreated = await _employeeRepository.AddAsync(employee);

            if (!isCreated)
            {
                throw new Exception("Failed to add empployee to repository.");
            }

            return employee.Id;
        }
    }
}
