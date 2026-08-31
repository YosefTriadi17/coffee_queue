using Microsoft.AspNetCore.Mvc;
using CoffeeQueue.Services;

namespace CoffeeQueue.Controllers;

public class QueueController : Controller
{
    private readonly QueueService _queue;
    public QueueController(QueueService queue) => _queue = queue;

    public IActionResult Index() => View(_queue.GetAll());

    [HttpPost("api/reserve/{number}")]
    public IActionResult Reserve(string number)
    {
        if (_queue.Reserve(number))
            return Ok(new { message = $"{number.ToUpper()} reserved!", item = _queue.GetByNumber(number) });
        return BadRequest(new { message = $"{number} not available" });
    }

    [HttpPost("api/status/{number}/{status}")]
    public IActionResult UpdateStatus(string number, string status)
    {
        if (_queue.UpdateStatus(number, status))
            return Ok(new { message = $"{number} -> {status}" });
        return NotFound(new { message = "not found" });
    }

    [HttpGet("api/items")]
    public IActionResult GetItems() => Ok(_queue.GetAll());
}
