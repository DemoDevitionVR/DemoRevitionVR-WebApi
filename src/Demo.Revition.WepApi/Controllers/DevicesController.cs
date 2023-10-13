using Microsoft.AspNetCore.Mvc;
using Demo.Revition.WepApi.Models;
using Demo.Revition.Service.DTOs.Devices;
using Demo.Revition.Service.Interfaces.Devices;

namespace Demo.Revition.WepApi.Controllers;

public class DevicesController : BaseController
{
    private readonly IDeviceService _deviceService;
    public DevicesController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(DeviceCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _deviceService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(long id, DeviceUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _deviceService.UpdateAsync(id, dto)
        });

    [HttpPut("update-isActive")]
    public async Task<IActionResult> PutIsActiveAsync(long id, bool isActive)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _deviceService.UpdateIsActiveAsync(id, isActive)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _deviceService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Successs",
            Data = await _deviceService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Successs",
           Data = await _deviceService.GetAllAsync()
       });
}