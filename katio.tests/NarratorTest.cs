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
public class NarratorTest
{
    private readonly IRepository<int, Narrator> _narratorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly INarratorService _narratorService;
    public NarratorTest ()
    {
        _narratorRepository = Substitute.For<IRepository<int, Narrator>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _narratorService = new NarratorService(_unitOfWork);
        
    }

    [TestMethod]
    public async Task GetAllNarratorsSuccess()
    {
        _narratorRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Narrator>>(new List<Narrator>(){new Narrator()}));
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.GetAllNarrators();
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task GetAllNarratorsFailed()
    {
        _narratorRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Narrator>>(new List<Narrator>()));
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.GetAllNarrators();
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }

    [TestMethod]
    public async Task CreateNarratorSuccess()
    {
        _narratorRepository.AddAsync(Arg.Any<Narrator>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.CreateNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task CreateNarratorFailed()
    {
        _narratorRepository.AddAsync(Arg.Any<Narrator>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.CreateNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);  
    }

    [TestMethod]
    public async Task DeleteNarratorSuccess()
    {
        _narratorRepository.Delete(Arg.Any<Narrator>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.DeleteNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task DeleteNarratorFailed()
    {
        _narratorRepository.Delete(Arg.Any<Narrator>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.DeleteNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);  
    }

    [TestMethod]
    public async Task UpdateNarratorSuccess()
    {
        _narratorRepository.Update(Arg.Any<Narrator>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.UpdateNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task UpdateNarratorFailed()
    {
        _narratorRepository.Update(Arg.Any<Narrator>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.UpdateNarrator(new Narrator());
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }

    [TestMethod]
    public async Task FindNarratorByNameSuccess()
    {
        _narratorRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Narrator, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Narrator>>(new List<Narrator>(){new Narrator()}));
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.FindNarratorByName("Name");
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task FindNarratorByNameFailed()
    {
        _narratorRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<System.Func<katio.Data.Models.Narrator, bool>>>()).ReturnsForAnyArgs(Task.FromResult<List<Narrator>>(new List<Narrator>()));
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.FindNarratorByName("Name");
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }

    [TestMethod]
    public async Task FindNarratorByIdSuccess()
    {
        _narratorRepository.FindAsync(Arg.Any<int>()).ReturnsForAnyArgs(Task.FromResult<Narrator>(new Narrator()));
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.FindNarratorById(1);
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task FindNarratorByIdFailed()
    {
        _narratorRepository.FindAsync(Arg.Any<int>()).ReturnsNullForAnyArgs();
        _unitOfWork.NarratorRepository.Returns(_narratorRepository);
        var result = await _narratorService.FindNarratorById(1);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }

    [TestMethod]
    public async Task FindNarratorByIdFailedLessThanOne()
    {
        var result = await _narratorService.FindNarratorById(0);
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }
}    
