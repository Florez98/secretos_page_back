using katio.Data.Dto;
using katio.Data.Models;

public interface IUserService
{
    Task<BaseMessage<User>> CreateUser(User user);
    Task<BaseMessage<User>> GetAllUsers();
    Task<BaseMessage<User>> Login(string email, string Passhash);
}