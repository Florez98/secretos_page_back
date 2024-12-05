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

public class NarratorService : INarratorService
{
    
    public IUnitOfWork _unitOfWork;

    public NarratorService (IUnitOfWork unitOfWork)
    {
        
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseMessage<Narrator>> CreateNarrator(Narrator narrator)
    {
        try{
            
            await _unitOfWork.NarratorRepository.AddAsync(narrator);
            await _unitOfWork.SaveAsync();
            
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Narrator>{narrator});
    }

    public async Task<BaseMessage<Narrator>> DeleteNarrator(Narrator narrator)
    {
        try
        {
            await _unitOfWork.NarratorRepository.Delete(narrator);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}");
        }
        return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Narrator>(){narrator});
    }

    public async Task<BaseMessage<Narrator>> FindNarratorById(int id)
    {
         if (id<=0)
        {
            return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
        }

        var response = await _unitOfWork.NarratorRepository.FindAsync(id);
        return response!=null? Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Narrator>(){response}): Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Narrator>> FindNarratorByName(string name)
    {
        var response = await _unitOfWork.NarratorRepository.GetAllAsync(x =>x.Name.ToLower().Contains(name.ToLower()));
        return response.Any()? Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK,BaseMessageStatus.OK_200, response):Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Narrator>> GetAllNarrators()
    {
        var narrators = await _unitOfWork.NarratorRepository.GetAllAsync();

        if (narrators.Any()){
            return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK, BaseMessageStatus.OK_200, narrators);
        }
        return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, narrators);

    }

    public async Task<BaseMessage<Narrator>> UpdateNarrator(Narrator narrator)
    {
        try
        {
            await _unitOfWork.NarratorRepository.Update(narrator);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.NotFound, $"{BaseMessageStatus.BOOK_NOT_FOUND} | {ex.Message}");
        }
        return Utilities.Utilities.BuilResponse<Narrator>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Narrator>(){narrator});
    }
}
