using katio.Data.Dto;
using katio.Data.Models;

public interface INarratorService
{
    Task<BaseMessage<Narrator>> CreateNarrator(Narrator narrator);
    Task<BaseMessage<Narrator>> GetAllNarrators();

    Task<BaseMessage<Narrator>> DeleteNarrator(Narrator narrator);
    Task<BaseMessage<Narrator>> UpdateNarrator(Narrator narrator);

    Task<BaseMessage<Narrator>> FindNarratorById(int id);

    Task<BaseMessage<Narrator>> FindNarratorByName(string name);



}