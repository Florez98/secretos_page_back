using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class AuthorController: ControllerBase
{
    private readonly IAuthorService _autorService;
    public AuthorController(IAuthorService authorService){
        _autorService = authorService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> Index()
    {
        var response = await _autorService.GetAllAuthors();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _autorService.FindById(id);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _autorService.FindByName(name);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Author author)
    {
        var response = await _autorService.UpdateAuthor(author);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Author author)
    {
        var response = await _autorService.CreateAuthor(author);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Author author)
    {
        var response = await _autorService.DeleteAuthor(author);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);
    }

}