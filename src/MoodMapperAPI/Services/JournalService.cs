namespace MoodMapperAPI.Services;

public class JournalService : IJournalService
{
    private readonly IJournalRepository _journalRepository;
    private readonly IModelMapper _modelMapper;

    public JournalService(IJournalRepository journalRepository, IModelMapper modelMapper)
    {
        _journalRepository = journalRepository;
        _modelMapper = modelMapper;
    }

    public async Task<Journal> CreateJournal(string userid, JournalDto dto)
    {
        var journal = _modelMapper.MapToModel<Journal, JournalDto>(dto);
        journal.UserId = userid;
        return await _journalRepository.CreateJournalAsync(journal);
    }

    public Task DeleteJournal(string userid, int id)
    {
        throw new NotImplementedException();
    }

    public Task<Journal> GetJournal(string userid, int id)
    {
        throw new NotImplementedException();
    }
}
