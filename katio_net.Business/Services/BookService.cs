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

public class BookService : IBookService
{

    public IUnitOfWork _unitOfWork;
    
    

    public BookService (IUnitOfWork unitOfWork)
    {
       
        _unitOfWork = unitOfWork;
        
    }

    public async Task<BaseMessage<Book>> CreateBook(Book book)
    {
        try{
            await _unitOfWork.BookRepository.AddAsync(book);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>{book});
    }

    public async Task<BaseMessage<Book>> GetAllBooks()
    {
        
        var response = await _unitOfWork.BookRepository.GetAllAsync();

        return response.Any()? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());

    }

    public async Task<BaseMessage<Book>> GetByAuthorId(int AuthorId)
    {
        //var BookList = await _context.Books.Where(x => x.AuthorId == AuthorId).ToListAsync();
        var BookList = await _unitOfWork.BookRepository.GetAllAsync(x=>x.AuthorId ==AuthorId);
        return BookList.Any()? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK,BaseMessageStatus.OK_200,BookList): 
        Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound,BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<BaseMessage<Book>> GetByAuthorName(string AuthorName)
    {
        var BookList = await _unitOfWork.BookRepository.GetAllAsync(x => x.Author.Name.Contains(AuthorName));
        return BookList.Any()? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK,BaseMessageStatus.OK_200,BookList): 
        Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound,BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<BaseMessage<Book>> GetById(int id)
    {
        
        if (id<=0)
        {
            return Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
        }

        var response = await _unitOfWork.BookRepository.FindAsync(id);
        return response!=null? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>(){response}): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<BaseMessage<Book>> GetByName(string name)
    {
        var response = await _unitOfWork.BookRepository.GetAllAsync(x => x.Title.Contains(name));

        return response.Any()? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());

    }

    public async Task<BaseMessage<Book>> Update(Book book)
    {
        try{
            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveAsync();
            return Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>{book});
        }
        catch
        {
            return Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
        }
    }

    public async Task<BaseMessage<Book>> GetByGenre(string genre)
    {
        var response = await _unitOfWork.BookRepository.GetAllAsync(x => x.Genre.Contains(genre));

        return response.Any()? Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, response): Utilities.Utilities.BuilResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());

    }

    public async Task<BaseMessage<Book>> DeleteBook(Book book)
    {
         try{
            await _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.SaveAsync();
        }
        catch(Exception ex)
        {
            return Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
        }
        return Utilities.Utilities.BuilResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>{book});
    }
}

