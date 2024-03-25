using Application.Contracts.Persistences;
using Application.DTOs.EmployeesDTO.Validators;
using Application.Features.Employees.Requests.Commands;
using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly UpdateEmployeeDTOValidator _validator;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
			IUnitOfWork unitOfWork,
            UpdateEmployeeDTOValidator validator,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
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
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.UpdateEmployeeDTO.Id) 
                ?? throw new NotFoundException(nameof(Employee), request.UpdateEmployeeDTO.Id);
            _mapper.Map(request.UpdateEmployeeDTO, employee);

            var isUpdated = await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
            if (!isUpdated)
            {
                throw new Exception("No employee updated!!");
            }
            return Unit.Value;
        }
    }
}
