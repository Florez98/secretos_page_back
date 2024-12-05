using System.Net;
using katio.Business.Interfaces;
using katio.Business.Services;
using katio.Data.Models;
using Katio.Data;
using katio_net.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace katio.tests;
[TestClass]
public class AuthorTest
{
    private readonly IRepository<int, Author> _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorService _authorService;

    public AuthorTest ()
    {
        _authorRepository = Substitute.For<IRepository<int, Author>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _authorService = new AuthorService(_unitOfWork);
        
    }

    [TestMethod]
    public async Task GetAllAuthorsSuccess()
    {
        _authorRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Author>>(new List<Author>(){new Author()}));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.GetAllAuthors();
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);       
    }
    
    [TestMethod]
     public async Task GetAllAuthorsFailed()
    {
        _authorRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Author>>(new List<Author>()));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.GetAllAuthors();
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode); 
    }

    [TestMethod]
    public async Task CreateAuthorSuccess()
    {
        _authorRepository.AddAsync(Arg.Any<Author>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.CreateAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task CreateAuthorFailed()
    {
        _authorRepository.AddAsync(Arg.Any<Author>()).ThrowsForAnyArgs(new Exception());
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.CreateAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);
    }

    [TestMethod]
    public async Task UpdateAuthorSuccess()
    {
        _authorRepository.Update(Arg.Any<Author>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.UpdateAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    } 

    [TestMethod]
    public async Task UpdateAuthorFailed()
    {
        _authorRepository.Update(Arg.Any<Author>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.UpdateAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    } 

    [TestMethod]
    public async Task FindByIdSuccess()
    {
        _authorRepository.FindAsync(Arg.Any<int>()).ReturnsForAnyArgs(Task.FromResult<Author>(new Author()));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.FindById(1);
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task FindByIdFailed()
    {
        _authorRepository.FindAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.FindById(1);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }



    [TestMethod]
    public async Task FindByIdFailedIdLessThanCero()
    {
        var result = await _authorService.FindById(0);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    } 

    [TestMethod]
    public async Task FindByNameSuccess()
    {
        _authorRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Author, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Author>>(new List<Author>(){new Author()}));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.FindByName("name");
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task FindByNameFailed()
    {
        _authorRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Author, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Author>>(new List<Author>()));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.FindByName("name");
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);
    }

    [TestMethod]
    public async Task DeleteSccess()
    {
        _authorRepository.Delete(Arg.Any<Author>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.DeleteAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);
    }

    [TestMethod]
    public async Task DeleteFailed()
    {
        _authorRepository.Delete(Arg.Any<Author>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.DeleteAuthor(new Author());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);
    }
}
