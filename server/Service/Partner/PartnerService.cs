using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.middlewares;
using server.Models;

namespace server.Service;

public class PartnerService : IPartnerService
{
    private readonly DataContext _dataContext;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PartnerService( DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<PartnerDTO>> GetById(int id)
    {

        var serviceResponse = new ServiceResponse<PartnerDTO>();
        var dbPartner = await _dataContext.Partners.FirstOrDefaultAsync(x => x.PartnerId == id);
        var result = new PartnerDTO
        {
            PartnerID=dbPartner.PartnerId,
            DisplayName=dbPartner.DisplayName,
            Email=dbPartner.Email,
            Address=dbPartner?.Address  ?? "",
            Phone=dbPartner?.Phone ?? "",

        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<PartnerDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<PartnerDTO>>();
        var dbPartner = await _dataContext.Partners.ToListAsync();
        try
        {
            var result = dbPartner.Select(x => new PartnerDTO
        {
           PartnerID=x.PartnerId,
            DisplayName=x.DisplayName,
            Email=x.Email,
            Address=x?.Address  ?? "",
            Phone=x?.Phone ?? "",
            //Birthday=x?.Birthday.ToString("dd/MM/yyyy")
        }).ToList();
        serviceResponse.Data = result;
            serviceResponse.Success = true;   
        }
        catch (System.Exception)
        {
            serviceResponse.Success = false;
            throw;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PartnerDTO>>> Create(PartnerDTO partner)
    {
        var serviceResponse = new ServiceResponse<List<PartnerDTO>>();
        // var token = _httpContextAccessor.HttpContext.Request.Cookies["user"];
        try
        {
        var partnerNew = new Partner {
           DisplayName=partner.DisplayName,
            Email=partner.Email,
            Address=partner?.Address  ?? "",
            Phone=partner?.Phone ?? ""
        };

        _dataContext.Partners.Add(partnerNew);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
            serviceResponse.Message = "Thêm mới đối tác thành công";
        }
        catch (System.Exception)
        {
             serviceResponse.Success = false;
            serviceResponse.Message = "Thêm mới đối tác thất bại";
            throw;
        }
       
        return serviceResponse;
    }

    public async Task<ServiceResponse<PartnerDTO>> Update(PartnerDTO partnerDTO)
    {
        var serviceResponse = new ServiceResponse<PartnerDTO>();
        try
        {
            var partner = await _dataContext.Partners.FirstOrDefaultAsync(c => c.PartnerId == partnerDTO.PartnerID);
            if(partner is null)
                throw new Exception("Không tìm thấy đối tác có ID là "+partnerDTO.PartnerID );

            partner.DisplayName = partnerDTO.DisplayName;
            partner.Email = partnerDTO.Address;
            partner.Address = partnerDTO.Address;
            partner.Phone = partnerDTO.Phone;
            await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
            serviceResponse.Message = "Cập nhật đối tác thành công";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Cập nhật đối tác thất bại";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PartnerDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<PartnerDTO>>();
        try
        {
            var partner = await _dataContext.Partners.FirstOrDefaultAsync(c => c.PartnerId == id);
            if (partner is null)
                throw new Exception("Không tìm thấy đối tác có ID là "+ id);
            _dataContext.Partners.Remove(partner);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Xóa đối tác thành công";

        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Xóa đối tác thất bại";
        }
        return serviceResponse;
    }
}