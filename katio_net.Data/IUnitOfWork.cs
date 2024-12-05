using katio.Data.Models;
using katio_net.Data;

namespace Katio.Data;
public interface IUnitOfWork
{
    IRepository<int, Book> BookRepository{get;}
    IRepository<int, Author> AuthorRepository{get;}
    IRepository<int, User> UserRepository{get;}
    IRepository<int, Genres> GenresRepository{get;}
    IRepository<int, Narrator> NarratorRepository{get;}
    IRepository<int, Role> RoleRepository{get;}
    IRepository<int, AudioBooks> AudioBookRepository{get;}
    Task SaveAsync();
}