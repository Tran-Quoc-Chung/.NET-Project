using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.DTO;
using server.DTO.StatusActive;
using server.DTO.Voucher;
using server.Models;


namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SystemStatus, GetStatusActiveDTO>();
            CreateMap<AddStatusActiveDTO, SystemStatus>();
            CreateMap<AddUserDTO, User>();
            CreateMap<User, GetUserDTO>().ForMember(dest=>dest.Status, opt=>opt.MapFrom(x=>x.Status.StatusID));
            CreateMap<SystemStatus, GetUserDTO>();
            CreateMap<RoleDTO, Role>().ForMember(dest=>dest.CreatedAt,opt=>opt.Ignore()).ForMember(dest=>dest.CreatedBy,opt=>opt.Ignore());
            CreateMap<Role, RoleDTO>();
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<UserToRole, UserToRoleDTO>();
            CreateMap<UserToRoleDTO, UserToRole>();
            CreateMap< UserToRole,UserToRoleDetailDTO>();
            CreateMap<Product,AddProductDTO>();
            CreateMap<AddProductDTO,Product>();
            CreateMap<AddCustomerDTO,Customer>();
            CreateMap<Customer,AddCustomerDTO>();
            CreateMap<AddInventoryDTO,Inventory>();
            CreateMap<Inventory, GetInventoryDTO>().ForMember(dest=>dest.CreatedBy,otp=>otp.MapFrom(x=>x.User.DisplayName));
            CreateMap<InventoryDetailDTO,InventoryDetail>();
            CreateMap<InventoryDetail, InventoryDetailDTO>();
            CreateMap<InventoryDetail, GetInventoryDTO>();
            CreateMap<Voucher,GetVoucherDTO>();
            CreateMap<AddVoucherDTO, Voucher>();
            CreateMap<InvoiceDetailDTO, InvoiceDetail>();
            CreateMap<AddInvoiceDTO, Invoice>();

        }
    }
}