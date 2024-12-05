using System.Net;
using katio.Data.Dto;
using katio.Data.Models;
using Katio.Data;
using katio_net.Data;

namespace katio.Business.Services;

public class UserService : IUserService
{

    public IUnitOfWork _unitOfWork;
    public PasswordHasher _passwordHasher;

    public UserService (IUnitOfWork unitOfWork)
    {
       
        _passwordHasher = new PasswordHasher();
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseMessage<User>> CreateUser(User user)
    {
        if(user.Passhash.Length>10)
        {
            user.Passhash = _passwordHasher.hash(user.Passhash);
            try
            {
               await _unitOfWork.UserRepository.AddAsync(user);
               await _unitOfWork.SaveAsync();

            }catch(Exception ex)
            {
                return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | {ex.Message}" );
            }
            return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<User>{user});
        }
        return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | Password debe tener minimo 10 caracteres" );
    }

    public async Task<BaseMessage<User>> GetAllUsers()
    {
        
            var listUsers = await _unitOfWork.UserRepository.GetAllAsync();
            return listUsers.Any()?Utilities.Utilities.BuilResponse<User>(HttpStatusCode.OK, BaseMessageStatus.OK_200, listUsers ):Utilities.Utilities.BuilResponse<User>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_500} | No se puso obtener" );
            
    }
    public async Task<BaseMessage<User>> Login(string email, string inputPassword)
    {
        //var userList = _context.User.Where(x => x.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase)).ToList();
        var userList = await _unitOfWork.UserRepository.GetAllAsync(x => x.Email.Contains(email));
        if (!userList.Any())
        {
            return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.NotFound, BaseMessageStatus.NOT_FOUND_404, new List<User>());
        }
    
        var user = userList[0];
        var validator = _passwordHasher.verify(user.Passhash, inputPassword);
    
        if (validator)
        {
            return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.OK, BaseMessageStatus.OK_200, userList);
        }
        else
        {
            return Utilities.Utilities.BuilResponse<User>(HttpStatusCode.NotFound, BaseMessageStatus.NOT_FOUND_404, new List<User>());
        }
    }



}