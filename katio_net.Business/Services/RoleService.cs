using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using katio.Business.Utilities;
using katio_net.Data;
using katio.Data.Dto;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Katio.Data;

namespace katio.Business.Services;

public class RoleService : IRoleService
{
    
    public IUnitOfWork _unitOfWork;

    public RoleService (IUnitOfWork unitOfWork)
    {
        
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseMessage<Role>> CreateRol(Role role)
    {
        try{
            
            await _unitOfWork.RoleRepository.AddAsync(role);
            await _unitOfWork.SaveAsync();
            
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Role>(){role});
    }

    public async Task<BaseMessage<Role>> DeleteRolesById(int id)
    {
        try
        {
            await _unitOfWork.RoleRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Role>());
    }

    public async Task<BaseMessage<Role>> FindById(int id)
    {
         if (id<=0)
        {
            return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
        }

        var response = await _unitOfWork.RoleRepository.FindAsync(id);
        return response!=null? Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Role>(){response}): Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Role>> FindByName(string name)
    {
        var response = await _unitOfWork.RoleRepository.GetAllAsync(x =>x.roleName.ToLower().Contains(name.ToLower()));
        return response.Any()? Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK,BaseMessageStatus.OK_200, response):Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Role>> GetAllRoles()
    {
        var roles = await _unitOfWork.RoleRepository.GetAllAsync();

        if (roles.Any()){
            return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK, BaseMessageStatus.OK_200, roles);
        }
        return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, roles);
    }

    public async Task<BaseMessage<Role>> UpdateRol(Role role)
    {
        try{
            
            await _unitOfWork.RoleRepository.Update(role);
            await _unitOfWork.SaveAsync();
            
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.NotFound, $"{BaseMessageStatus.BOOK_NOT_FOUND} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Role>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Role>(){role});
    }
}    