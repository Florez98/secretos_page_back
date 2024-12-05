using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class RoleController: ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService){
        _roleService = roleService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> Index()
    {
        var response = await _roleService.GetAllRoles();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);

    }

    [HttpGet]
    [Route("FindByName")]
    public async Task<IActionResult> FindByName(string name)
    {
        var response = await _roleService.FindByName(name);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpGet]
    [Route("FindById")]
    public async Task<IActionResult> FindById(int id)
    {
        var response = await _roleService.FindById(id);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Role role)
    {
        var response = await _roleService.CreateRol(role);
        return response.TotalElements > 0 ? Ok(response): StatusCode((int)response.statusCode, response);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Role role)
    {
        var response = await _roleService.UpdateRol(role);
        return response.TotalElements > 0 ? Ok(response): StatusCode((int)response.statusCode, response);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _roleService.DeleteRolesById(id);
        return response.TotalElements > 0 ? Ok(response): StatusCode((int)response.statusCode, response);
    }


}    