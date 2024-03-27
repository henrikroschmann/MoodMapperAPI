namespace MoodMapperAPI.Exceptions;

public class JournalNotFoundException : Exception
{
    public JournalNotFoundException() : base()
    {
    }

    public JournalNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public JournalNotFoundException(string? message) : base(message)
    {
    }
}