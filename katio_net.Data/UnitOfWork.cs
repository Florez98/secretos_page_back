using katio.Data.Models;
using katio_net.Data;
using Microsoft.EntityFrameworkCore;

namespace Katio.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    
    private readonly katioContext _context;
    private bool _disposed = false;
    private IRepository<int, Book> _bookRepository;
    private IRepository<int, Author> _authorRepository;
    private IRepository<int, User> _userRepository;
    private IRepository<int, Genres> _genresRepository;
    private IRepository<int, Narrator> _narratorRepository;
    private IRepository<int, Role> _roleRepository;
    private IRepository<int, AudioBooks> _audioBookRepository;


    public UnitOfWork(katioContext context)
    {
        _context = context;
    }
    
    
    #region Repositories
    public IRepository<int, Book> BookRepository
    {
        get
        {
            _bookRepository ??= new Repository<int, Book>(_context);
            return _bookRepository;
        }
    }
    public IRepository<int, Genres> GenresRepository
    {
        get
        {
            _genresRepository ??= new Repository<int, Genres>(_context);
            return _genresRepository;
        }
    }

    public IRepository<int, Author> AuthorRepository
    {
        get
        {
            _authorRepository ??= new Repository<int, Author>(_context);
            return _authorRepository;
        }
    }

    public IRepository<int, User> UserRepository
    {
        get
        {
            _userRepository ??= new Repository<int, User>(_context);
            return _userRepository;
        }
    }

    public IRepository<int, Narrator> NarratorRepository
    {
         get
        {
            _narratorRepository ??= new Repository<int, Narrator>(_context);
            return _narratorRepository;
        }
    }

    public IRepository<int, Role> RoleRepository
    {
         get
        {
            _roleRepository ??= new Repository<int, Role>(_context);
            return _roleRepository;
        }
    }

    public IRepository<int, AudioBooks> AudioBookRepository
    {
         get
        {
            _audioBookRepository ??= new Repository<int, AudioBooks>(_context);
            return _audioBookRepository;
        }
    }
    #endregion

    public async Task SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            
            ex.Entries.Single().Reload();
        }
    }


#region IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if(!_disposed)
        {
            if(disposing)
            {
                _context.DisposeAsync();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }
#endregion
    
}