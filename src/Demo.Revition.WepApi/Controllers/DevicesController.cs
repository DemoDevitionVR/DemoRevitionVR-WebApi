using Demo.Revition.Service.DTOs.Devices;
using Demo.Revition.Service.Interfaces.Devices;
using Demo.Revition.WepApi.Models;
using Microsoft.AspNetCore.Mvc;

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
}
