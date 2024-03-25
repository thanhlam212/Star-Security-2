using Application.DTOs.AccountsDTO;
using Application.DTOs.BranchesDTO;
using Application.DTOs.ClientsDTO;
using Application.DTOs.EmployeesDTO;
using Application.DTOs.OffersDTO;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<GetAccountDTO, Account>().ReverseMap();
			CreateMap<GetDetailAccountDTO, Account>().ReverseMap();
			CreateMap<Account, CreateAccountDTO>().ReverseMap();
			CreateMap<Account, UpdateAccountDTO>().ReverseMap();
			//CreateMap<Account, DeleteAccountDTO>().ReverseMap();

			CreateMap<Branch, GetBranchDTO>().ReverseMap();
			CreateMap<CreateBranchDTO, Branch > ().ReverseMap();
			CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
			//CreateMap<Branch, DeleteBranchDTO>().ReverseMap();

			CreateMap<Client, GetClientDTO>().ReverseMap();
			CreateMap<Client, CreateClientDTO>().ReverseMap();
			CreateMap<Client, UpdateClientDTO>().ReverseMap();
			//CreateMap<Client, DeleteClientDTO>().ReverseMap();

			CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
			CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
			CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
			//CreateMap<Employee, DeleteEmployeeDTO>().ReverseMap();

			CreateMap<Offer, GetOfferDTO>().ReverseMap();
			CreateMap<Offer, CreateOfferDTO>().ReverseMap();
			CreateMap<Offer, UpdateOfferDTO>().ReverseMap();
			//CreateMap<Offer, DeleteOfferDTO>().ReverseMap();

			/*CreateMap<Employee, GetEmployeeDTO>()
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
				.ReverseMap();*/
		}
	}
}
