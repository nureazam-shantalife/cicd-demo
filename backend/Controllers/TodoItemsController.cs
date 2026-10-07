using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoItemsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.TodoItems.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(TodoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}