namespace MoodMapperAPI.Exceptions;

public class EntryNotFoundException : Exception
{
    public EntryNotFoundException() : base()
    {
    }

    public EntryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public EntryNotFoundException(string? message) : base(message)
    {
    }
}