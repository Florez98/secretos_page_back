
using katio.Data.Dto;
using katio.Data.Models;
namespace katio.Business.Interfaces;
public interface IAuthorService
{
        Task<BaseMessage<Author>> CreateAuthor(Author author);
        Task<BaseMessage<Author>> GetAllAuthors();
        Task<BaseMessage<Author>> DeleteAuthor(Author author);
        Task<BaseMessage<Author>> UpdateAuthor(Author author);
        Task<BaseMessage<Author>> FindById(int id);
        Task<BaseMessage<Author>> FindByName(string name);
}