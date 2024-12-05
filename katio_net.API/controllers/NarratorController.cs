using System;
using katio.Business.Interfaces;
using katio.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace katio_net.API.Controllers;
[Route("Api/[controller]")]
[ApiController]


public class NarratorController: ControllerBase
{
    private readonly INarratorService _narratorService;
    public NarratorController(INarratorService narratorService){
        _narratorService = narratorService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> Index()
    {
        var response = await _narratorService.GetAllNarrators();
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);

    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _narratorService.FindNarratorById(id);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);

    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _narratorService.FindNarratorByName(name);
        return response.TotalElements > 0 ? Ok(response): StatusCode(StatusCodes.Status204NoContent,response);

    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Narrator narrator)
    {
        var response = await _narratorService.CreateNarrator(narrator);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Narrator narrator)
    {
        var response = await _narratorService.UpdateNarrator(narrator);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Narrator narrator)
    {
        var response = await _narratorService.DeleteNarrator(narrator);
        return response.statusCode == System.Net.HttpStatusCode.OK? Ok(response): StatusCode((int)response.statusCode, response);
    }

}