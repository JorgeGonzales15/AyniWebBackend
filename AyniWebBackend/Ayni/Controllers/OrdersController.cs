using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Resources;
using AyniWebBackend.Shared.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AyniWebBackend.Ayni.Controllers;

[EnableCors("ReglasCors")]
[ApiController]
[Route("/api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, 
            IEnumerable<OrderResource>>(orders);
        return resources;

    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var order = _mapper.Map<SaveOrderResource, 
            Order>(resource);
        var result = await _orderService.SaveAsync(order);
        if (!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, 
            OrderResource>(result.Resource);
        return Ok(orderResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var order = _mapper.Map<SaveOrderResource, 
            Order>(resource);
        var result = await _orderService.UpdateAsync(id, order);
        if (!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, 
            OrderResource>(result.Resource);
        return Ok(orderResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _orderService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, 
            OrderResource>(result.Resource);
        return Ok(orderResource);
    }
}