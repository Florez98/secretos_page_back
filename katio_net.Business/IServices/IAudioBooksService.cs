using katio.Data.Dto;
using katio.Data.Models;
namespace katio.Business.Interfaces;
public interface IAudioBookService
{
    Task<BaseMessage<AudioBooks>> GetAllAudioBooks();

    Task<BaseMessage<AudioBooks>> GetById(int id);

    Task<BaseMessage<AudioBooks>> GetByName(string name);
    Task<BaseMessage<AudioBooks>> CreateAudioBook(AudioBooks audioBooks);
    Task<BaseMessage<AudioBooks>> Update(AudioBooks audioBooks);

    Task<BaseMessage<AudioBooks>> GetByAuthorId(int AuthorId);
    Task<BaseMessage<AudioBooks>> GetByAuthorName(string AuthorName);
    Task<BaseMessage<AudioBooks>> GetByGenre(string genre);

    Task<BaseMessage<AudioBooks>> GetByNarratorName(string NarratorName);

    Task<BaseMessage<AudioBooks>> GetByNarratorId(int NarratorId);

    Task<BaseMessage<AudioBooks>> DeleteAudioBook(AudioBooks audioBooks);

}