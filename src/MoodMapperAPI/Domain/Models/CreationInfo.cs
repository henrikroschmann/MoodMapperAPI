namespace MoodMapperAPI.Domain.Options;

public class CreationInfo
{
	public CreationInfo(DateTime creationDate)
	{
		CreationDate = creationDate;
	}
    public DateTime CreationDate { get; set; }
}
