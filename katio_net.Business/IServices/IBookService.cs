
using katio.Data.Dto;
using katio.Data.Models;
namespace katio.Business.Interfaces;
public interface IBookService
{
    Task<BaseMessage<Book>> GetAllBooks();

    Task<BaseMessage<Book>> GetById(int id);

    Task<BaseMessage<Book>> GetByName(string name);
    Task<BaseMessage<Book>> CreateBook(Book book);
    Task<BaseMessage<Book>> Update(Book book);

    Task<BaseMessage<Book>> GetByAuthorId(int AuthorId);
    Task<BaseMessage<Book>> GetByAuthorName(string AuthorName);
    Task<BaseMessage<Book>> GetByGenre(string genre);

    Task<BaseMessage<Book>> DeleteBook(Book book);
}