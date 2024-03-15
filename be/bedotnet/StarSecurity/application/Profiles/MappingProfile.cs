using application.DTOs;
using application.DTOs.AccountsDTO;
using application.DTOs.BranchesDTO;
using application.DTOs.ClientsDTO;
using application.DTOs.EmployeesDTO;
using application.DTOs.OffersDTO;
using AutoMapper;
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
            CreateMap<Account, GetAccountDTO>().ReverseMap();
			CreateMap<Account, CreateAccountDTO>().ReverseMap();
			CreateMap<Account, UpdateAccountDTO>().ReverseMap();
			CreateMap<Account, DeleteAccountDTO>().ReverseMap();

			CreateMap<Branch, GetBranchDTO>().ReverseMap();
			CreateMap<Branch, CreateBranchDTO>().ReverseMap();
			CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
			CreateMap<Branch, DeleteBranchDTO>().ReverseMap();

			CreateMap<Client, GetClientDTO>().ReverseMap();
			CreateMap<Client, CreateClientDTO>().ReverseMap();
			CreateMap<Client, UpdateClientDTO>().ReverseMap();
			CreateMap<Client, DeleteClientDTO>().ReverseMap();

			CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
			CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
			CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
			CreateMap<Employee, DeleteEmployeeDTO>().ReverseMap();

			CreateMap<Offer, GetOfferDTO>().ReverseMap();
			CreateMap<Offer, CreateOfferDTO>().ReverseMap();
			CreateMap<Offer, UpdateOfferDTO>().ReverseMap();
			CreateMap<Offer, DeleteOfferDTO>().ReverseMap();

			/*CreateMap<Branch, BranchDTO>().ReverseMap();
			CreateMap<Branch, BranchDetailDTO>().ReverseMap();
			CreateMap<Client, ClientDTO>().ReverseMap();
			CreateMap<Employee, EmployeeDTO>().ReverseMap();
			CreateMap<Offer, OfferDTO>().ReverseMap();*/
		}
    }
}
