using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using katio.Business.Utilities;
using katio_net.Data;
using katio.Data.Dto;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Katio.Data;

namespace katio.Business.Services;

public class GenresService : IGenresService
{

    public IUnitOfWork _unitOfWork;
    
    

    public GenresService (IUnitOfWork unitOfWork)
    {
       
        _unitOfWork = unitOfWork;
        
    }

    public async Task<BaseMessage<Genres>> CreateGenres(Genres genre)
    {
        try{
            await _unitOfWork.GenresRepository.AddAsync(genre);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Genres>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Genres>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Genres>{genre});
    }

    public async Task<BaseMessage<Genres>> GetAllGenres()
    {
        var response = await _unitOfWork.GenresRepository.GetAllAsync();

        return response.Any()? Utilities.Utilities.BuilResponse<Genres>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Genres>());
    }
}