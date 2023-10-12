using Microsoft.AspNetCore.Mvc;
using Demo.Revition.WepApi.Models;
using Demo.Revition.Service.DTOs.Positions;
using Demo.Revition.Service.Interfaces.Positions;

namespace Demo.Revition.WepApi.Controllers;

public class PositionsController : BaseController
{
    private readonly IPositionService _positionService;
    public PositionsController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(UserPositionCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _positionService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(long id, UserPositionUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _positionService.UpdateAsync(id, dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _positionService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Successs",
            Data = await _positionService.GetByIdAsync(id)
        });

    //[HttpGet("get-by-position/{id:long}")]
    //public async Task<IActionResult> GetByPositionIdAsync(long id)
    //    => Ok(new Response
    //    {
    //        StatusCode = 200,
    //        Message = "Successs",
    //        Data = await _positionService.GetByUserPositionIdAsync(id)
    //    });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Successs",
           Data = await _positionService.GetAllAsync()
       });
}