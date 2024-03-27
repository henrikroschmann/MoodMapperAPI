using CommunityToolkit.Diagnostics;

namespace MoodMapperAPI.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class JournalController : ControllerBase
{
    private readonly IJournalService _journalService;

    public JournalController(IJournalService journalService)
    {
        _journalService = journalService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJournal(int id)
    {
        try
        {
            var result = await _journalService.GetJournal(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message, e);
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
            Console.WriteLine(e);
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
            Console.WriteLine(e.Message, e);
            return BadRequest();
        }
    }
}