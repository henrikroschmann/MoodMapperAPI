namespace MoodMapperAPI.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Authorize]
public class JournalController(IJournalService journalService, ILogger<JournalController> logger) : ControllerBase
{
    private readonly IJournalService _journalService = journalService;
    private readonly ILogger<JournalController> _logger = logger;

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetJournal(int id)
    {
        try
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _journalService.GetJournal(userid, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateJournal([FromBody] JournalDto journal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            Guard.IsNotNullOrEmpty(journal.Name);
            var result = await _journalService.CreateJournal(journal);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJournal(int id)
    {
        try
        {
            await _journalService.DeleteJournal(id);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Something unexpected happened {e.Message}, {e}");
            return BadRequest();
        }
    }
}