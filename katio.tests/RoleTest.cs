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
public class RoleTest
{
    private readonly IRepository<int, Role> _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleService _roleService;
    public RoleTest ()
    {
        _roleRepository = Substitute.For<IRepository<int, Role>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _roleService = new RoleService(_unitOfWork);
    }

    [TestMethod]
    public async Task GetAllRolesSuccess()
    {
        _roleRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Role>>(new List<Role>(){new Role()}));
        _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.GetAllRoles();
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task GetAllRolesFailed()
    {
        _roleRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<List<Role>>(new List<Role>()));
        _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.GetAllRoles();
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }

   [TestMethod]
    public async Task CreateRoleSuccess()
    {
        _roleRepository.AddAsync(Arg.Any<Role>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.CreateRol(new Role());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task CreateRoleFailed()
    {
        _roleRepository.AddAsync(Arg.Any<Role>()).ThrowsAsyncForAnyArgs(new Exception());
        _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.CreateRol(new Role());
        Assert.AreEqual(HttpStatusCode.InternalServerError, result.statusCode);  
    }

    [TestMethod]
    public async Task UpdateRoleSuccess()
    {
        _roleRepository.Update(Arg.Any<Role>()).ReturnsForAnyArgs(Task.CompletedTask);
        _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.UpdateRol(new Role());
        Assert.AreEqual(HttpStatusCode.OK, result.statusCode);  
    }

    [TestMethod]
    public async Task UpdateNarratorFailed()
    {
         _roleRepository.Update(Arg.Any<Role>()).ThrowsAsyncForAnyArgs(new Exception());
         _unitOfWork.RoleRepository.Returns(_roleRepository);
        var result = await _roleService.UpdateRol(new Role());
        Assert.AreEqual(HttpStatusCode.NotFound, result.statusCode);  
    }
}    