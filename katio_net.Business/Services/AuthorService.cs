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

public class AuthorService : IAuthorService
{
    public IUnitOfWork _unitOfWork;

    public AuthorService (IUnitOfWork unitOfWork)
    {
        
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseMessage<Author>> CreateAuthor(Author author)
    {
        try{
            await _unitOfWork.AuthorRepository.AddAsync(author);
            await _unitOfWork.SaveAsync();
        }

        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }

        return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author>{author});
    }

    public async Task<BaseMessage<Author>> DeleteAuthor(Author author)
    {
        try
        {
            await _unitOfWork.AuthorRepository.Delete(author);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}");
        }
        return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author>() {author});
    }

    public async Task<BaseMessage<Author>> FindById(int id)
    {
        if (id<=0)
        {
            return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
        }

        var response = await _unitOfWork.AuthorRepository.FindAsync(id);
        return response!=null? Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author>(){response}): Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Author>> FindByName(string name)
    {
         var response = await _unitOfWork.AuthorRepository.GetAllAsync(x => x.Name.Contains(name));

        return response.Any()? Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
    }

    public async Task<BaseMessage<Author>> GetAllAuthors()
    {
        var response = await _unitOfWork.AuthorRepository.GetAllAsync();

        return response.Any()? Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Author>());
    }

    public async Task<BaseMessage<Author>> UpdateAuthor(Author author)
    {
         try{
            await _unitOfWork.AuthorRepository.Update(author);
            await _unitOfWork.SaveAsync();
            return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author>{author});
        }catch
        {
            return Utilities.Utilities.BuilResponse<Author>(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND);
        }
    }
}