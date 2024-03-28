namespace MoodMapperAPI.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EntryController(IEntryService entryService, ILogger<EntryController> logger) : ControllerBase
{
    private readonly IEntryService _entryService = entryService;
    private readonly ILogger<EntryController> _logger = logger;

    [HttpPost]
    public async Task<IActionResult> CreateEntry([FromBody] EntryDto entry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Incorrect entry");
        }

        try
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _entryService.CreateEntry(entry, userId);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithPagination([FromQuery] EntryParameters parameters)
    {
        try
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var entries = await _entryService.GetAllWithPagination(parameters, userId);
            return Ok(entries);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEntry(int id)
    {
        try
        {
            await _entryService.DeleteEntry(id);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEntry([FromBody] EntryDto entry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var entryId = _entryService.UpdateEntry(entry);
            return Ok(entryId);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }
}