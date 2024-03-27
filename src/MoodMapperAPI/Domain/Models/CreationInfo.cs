namespace MoodMapperAPI.Domain.Models;

public class CreationInfo
{
	public CreationInfo(DateTime creationDate)
	{
		CreationDate = creationDate;
	}
    public DateTime CreationDate { get; set; }
}
