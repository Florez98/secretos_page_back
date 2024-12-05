using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Katio.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class BooksController: ControllerBase
{
    private readonly IBookService _bookService;
    public BooksController(IBookService bookService){
        _bookService = bookService;
    }

    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<IActionResult> Index()
    {
        var response = await _bookService.GetAllBooks();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent, response);

    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _bookService.GetById(id);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status404NotFound,"No se lo conseguí");

    }
    
    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _bookService.GetByName(name);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status404NotFound,StatusCode((int)response.statusCode, response));

    }

    [HttpPost]
    [Route("GetByAuthorsName")]
    public async Task<IActionResult> GetByAuthorsName(string name)
    {
        var response = await _bookService.GetByAuthorName(name);
        return response.TotalElements>0? Ok(response):
        StatusCode(StatusCodes.Status404NotFound,StatusCode((int)response.statusCode, response));
        
    }

     [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Book book)
    {
        var response = await _bookService.Update(book);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status404NotFound, StatusCode((int)response.statusCode, response));

    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Book book)
    {
        var response = await _bookService.CreateBook(book);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }

    [HttpGet]
    [Route("GetByGenre")]
    public async Task<IActionResult> GetByGenre(string genre)
    {
        var response = await _bookService.GetByGenre(genre);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status404NotFound,StatusCode((int)response.statusCode, response));

    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Book book)
    {
         var response = await _bookService.DeleteBook(book);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status404NotFound,StatusCode((int)response.statusCode, response));
    }
}