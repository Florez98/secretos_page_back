using katio.Data.Dto;
using katio.Data.Models;
namespace katio.Business.Interfaces;
public interface IGenresService
{
    Task<BaseMessage<Genres>> GetAllGenres();
    Task<BaseMessage<Genres>> CreateGenres(Genres genre);

}