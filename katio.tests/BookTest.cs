using System.Linq.Expressions;
using System.Net;
using katio.Business.Interfaces;
using katio.Business.Services;
using katio.Data.Models;
using Katio.Data;
using katio_net.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace katio.tests;
[TestClass]
public class BookTest
{
    private readonly IRepository<int, Book> _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookService _bookService;

    public BookTest ()
    {
        _bookRepository = Substitute.For<IRepository<int, Book>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _bookService = new BookService(_unitOfWork);
        
    }

#region TestMetods

    [TestMethod]
    public async Task GetAllBooksSuccess()
    {
        _bookRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>(){new Book()}));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetAllBooks();
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task GetAllBooksFailed()
    {
        _bookRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetAllBooks();
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }


    [TestMethod]
    public async Task CreateBookSuccess()
    {
        _bookRepository.AddAsync(Arg.Any<Book>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.CreateBook(new Book());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);   
    }

    [TestMethod]
    public async Task CreateBookFailed()
    {
        _bookRepository.AddAsync(Arg.Any<Book>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.CreateBook(new Book());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);      
    } 

    [TestMethod]
    public async Task GetByNameSuccess()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>(){new Book()}));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByName("Cien Años");
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }    

    [TestMethod]
    public async Task GetByNameFailed()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByName("Cien Años");
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }    

    [TestMethod]
    public async Task UpdateSuccess()
    {
        _bookRepository.Update(Arg.Any<Book>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.Update(new Book());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);        
    }

    [TestMethod]
    public async Task UpdateFailed()
    {
        _bookRepository.Update(Arg.Any<Book>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.Update(new Book());
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);       
    } 
    
    [TestMethod]
    public async Task GetByAuthorIdSuccess()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>(){new Book()}));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorId(1);
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task GetByAuthorIdFailed()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorId(1);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }

    [TestMethod]
    public async Task GetByAuthorNameSuccess()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>(){new Book()}));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorName("Gabriel");
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task GetByAuthorNameFailed()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorName("Gabriel");
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }
    
    [TestMethod]
    public async Task GetByGenreSuccess()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>(){new Book()}));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorName("Genres");
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    } 

    [TestMethod]
    public async Task GetByGenreFailed()
    {
        _bookRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Book, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Book>>(new List<Book>()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetByAuthorName("Genres");
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }

    [TestMethod]
    public async Task GetByIdSuccess()
    {
        _bookRepository.FindAsync(Arg.Any<int>()).ReturnsForAnyArgs(Task.FromResult<Book>(new Book()));
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetById(1);
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);

    }

    [TestMethod]
    public async Task GetByIdFailed()
    {
        _bookRepository.FindAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        _unitOfWork.BookRepository.Returns(_bookRepository);
        var result = await _bookService.GetById(1);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);

    }

    [TestMethod]
    public async Task GetByIdFailedLessThanOne()
    {
        var result = await _bookService.GetById(0);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }


#endregion
}    