using events_manager_api.Application.Dtos;
using events_manager_api.Application.Services;
using events_manager_api.Domain.Entities;
using FluentValidation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using events_manager_api.Infrastructure.Clients;
using events_manager_api.Domain.Structs;
using events_manager_api.Domain.Repositories;

namespace events_manager_api.Application.Controllers;

[ApiController]
[Route("home")]
public class HomeClontroller : ControllerBase
{
    private readonly IWeatherstackClient _weatherstackClient;
    private readonly ApplicationDbContext _context;

    public HomeClontroller(IWeatherstackClient weatherstackClient, ApplicationDbContext context)
    {
        _weatherstackClient = weatherstackClient;
        _context = context;
    }


    [HttpGet("{cityName}")]
    public async Task<IActionResult> Get(string cityName)
    {
        string? timeZoneId = await _weatherstackClient.GetTimeZoneIdByCityName(cityName);
        return Ok(timeZoneId);
    }

    [HttpGet("location/{cityName}")]
    public async Task<IActionResult> GetLoc(string cityName)
    {
        Location? loc = await _weatherstackClient.GetLocationByCityName(cityName);
        return Ok("he");
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(_context.Invites.Where(i => i.EventEntity.Id == 5));
    }
}