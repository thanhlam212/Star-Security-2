using Application.Contracts.Persistences;
using Application.DTOs.EmployeesDTO.Validators;
using Application.Features.Employees.Requests.Commands;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

namespace Application.Features.Employees.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly CreateEmployeeDTOValidator _validator;

		public CreateEmployeeCommandHandler(
			IUnitOfWork unitOfWork,
			CreateEmployeeDTOValidator validator)
		{
			_unitOfWork = unitOfWork;
			_validator = validator;
		}
		public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateEmployeeDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
			//var employee = _mapper.Map<Employee>(request.CreateEmployeeDTO);
			var newEmployee = new Employee(
			   request.CreateEmployeeDTO.Name,
			   request.CreateEmployeeDTO.Gender,
			   request.CreateEmployeeDTO.DateOfBirth,
			   request.CreateEmployeeDTO.Address,
			   request.CreateEmployeeDTO.ContactNumber,
			   request.CreateEmployeeDTO.Email,
			   request.CreateEmployeeDTO.EmployeeCode,
			   request.CreateEmployeeDTO.EducationalQualification,
			   request.CreateEmployeeDTO.Role,
			   request.CreateEmployeeDTO.Grade,
			   request.CreateEmployeeDTO.ProvideService,
			   request.CreateEmployeeDTO.BranchId,
			   request.CreateEmployeeDTO.CurrentOfferId);


            var isCreated = await _unitOfWork.EmployeeRepository.AddAsync(newEmployee);

            if (!isCreated)
            {
                throw new Exception("Failed to add empployee to repository.");
            }

            return newEmployee.Id;
        }
    }	
}
