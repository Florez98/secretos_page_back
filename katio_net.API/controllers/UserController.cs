using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService){
        _userService =userService;
    }
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(User user)
    {
        var response = await _userService.CreateUser(user);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _userService.GetAllUsers();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(string email, string inputPassword)
    {
        var response = await _userService.Login(email, inputPassword);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }
}