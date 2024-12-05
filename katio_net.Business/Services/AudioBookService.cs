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

public class AudioBookService : IAudioBookService
{

    public IUnitOfWork _unitOfWork;
    
    

    public AudioBookService (IUnitOfWork unitOfWork)
    {
       
        _unitOfWork = unitOfWork;
        
    }

    public async Task<BaseMessage<AudioBooks>> CreateAudioBook(AudioBooks audioBooks)
    {
        try{
            await _unitOfWork.AudioBookRepository.AddAsync(audioBooks);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<AudioBooks>{audioBooks});
    }

    public async Task<BaseMessage<AudioBooks>> DeleteAudioBook(AudioBooks audioBooks)
    {
        try{
            await _unitOfWork.AudioBookRepository.Delete(audioBooks);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<AudioBooks>{audioBooks});
    }

    public async Task<BaseMessage<AudioBooks>> GetAllAudioBooks()
    {
        var response = await _unitOfWork.AudioBookRepository.GetAllAsync();

        return response.Any()? Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<AudioBooks>());
    }

    public Task<BaseMessage<AudioBooks>> GetByAuthorId(int AuthorId)
    {
        return Task.FromResult(new BaseMessage<AudioBooks>());
    }

    public Task<BaseMessage<AudioBooks>> GetByAuthorName(string AuthorName)
    {
        return Task.FromResult(new BaseMessage<AudioBooks>());
    }

    public Task<BaseMessage<AudioBooks>> GetByGenre(string genre)
    {
        return Task.FromResult(new BaseMessage<AudioBooks>());
    }

    public async Task<BaseMessage<AudioBooks>> GetById(int id)
    {
        if (id<=0)
        {
            return Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<AudioBooks>());
        }

        var response = await _unitOfWork.AudioBookRepository.FindAsync(id);
        return response!=null? Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<AudioBooks>(){response}): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<AudioBooks>());
    }

    public async Task<BaseMessage<AudioBooks>> GetByName(string name)
    {
         var response = await _unitOfWork.AudioBookRepository.GetAllAsync(x => x.Name.Contains(name));

        return response.Any()? Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<AudioBooks>());
    }

    public Task<BaseMessage<AudioBooks>> GetByNarratorId(int NarratorId)
    {
        return Task.FromResult(new BaseMessage<AudioBooks>());
    }

    public Task<BaseMessage<AudioBooks>> GetByNarratorName(string NarratorName)
    {
        return Task.FromResult(new BaseMessage<AudioBooks>());
    }

    public async Task<BaseMessage<AudioBooks>> Update(AudioBooks audioBooks)
    {
        try{
            await _unitOfWork.AudioBookRepository.Update(audioBooks);
            await _unitOfWork.SaveAsync();
            return Utilities.Utilities.BuilResponse<AudioBooks>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<AudioBooks>{audioBooks});
        }catch
        {
            return Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<AudioBooks>());
        }
    }
}