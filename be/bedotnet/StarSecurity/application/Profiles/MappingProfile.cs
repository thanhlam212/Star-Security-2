using application.DTOs;
using application.DTOs.AccountsDTO;
using application.DTOs.BranchesDTO;
using application.DTOs.ClientsDTO;
using application.DTOs.EmployeesDTO;
using application.DTOs.OffersDTO;
using AutoMapper;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<string, Name>().ConvertUsing(s => new Name(s));
			CreateMap<string, Email>().ConvertUsing(s => new Email(s));

			CreateMap<Name, string>().ConvertUsing(name => name.Value);
			CreateMap<Email, string>().ConvertUsing(email => email.Value);

			CreateMap<string, Gender>().ConvertUsing(s => Enum.Parse<Gender>(s));
			CreateMap<string, ProvideService>().ConvertUsing(s => Enum.Parse<ProvideService>(s));
			CreateMap<string, Region>().ConvertUsing(s => Enum.Parse<Region>(s));
			CreateMap<string, Role>().ConvertUsing(s => Enum.Parse<Role>(s));

			CreateMap<Gender, string>().ConvertUsing(gender => gender.ToString());
			CreateMap<ProvideService, string>().ConvertUsing(provideService => provideService.ToString());
			CreateMap<Region, string>().ConvertUsing(region => region.ToString());
			CreateMap<Role, string>().ConvertUsing(role => role.ToString());


			CreateMap<GetAccountDTO, Account>().ReverseMap();
			//CreateMap<Account, CreateAccountDTO>().ReverseMap();
			//CreateMap<Account, UpdateAccountDTO>().ReverseMap();
			//CreateMap<Account, DeleteAccountDTO>().ReverseMap();

			CreateMap<Branch, GetBranchDTO>().ReverseMap();
			//CreateMap<CreateBranchDTO, Branch > ().ReverseMap();
			CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
			//CreateMap<Branch, DeleteBranchDTO>().ReverseMap();

			CreateMap<Client, GetClientDTO>().ReverseMap();
			//CreateMap<Client, CreateClientDTO>().ReverseMap();
			CreateMap<Client, UpdateClientDTO>().ReverseMap();
			//CreateMap<Client, DeleteClientDTO>().ReverseMap();

			CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
			//CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
			CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
			//CreateMap<Employee, DeleteEmployeeDTO>().ReverseMap();

			CreateMap<Offer, GetOfferDTO>().ReverseMap();
			//CreateMap<Offer, CreateOfferDTO>().ReverseMap();
			CreateMap<Offer, UpdateOfferDTO>().ReverseMap();
			//CreateMap<Offer, DeleteOfferDTO>().ReverseMap();

			/*CreateMap<Employee, GetEmployeeDTO>()
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
				.ReverseMap();*/
		}
	}
}
