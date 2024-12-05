using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Katio.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class GenresController: ControllerBase
{
    private readonly IGenresService _genresService;
    public GenresController(IGenresService genresService){
        _genresService = genresService;
    }

    [HttpGet]
    [Route("GetAllGenres")]
    public async Task<IActionResult> Index()
    {
        var response = await _genresService.GetAllGenres();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent, response);

    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Genres genre)
    {
        var response = await _genresService.CreateGenres(genre);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }
}