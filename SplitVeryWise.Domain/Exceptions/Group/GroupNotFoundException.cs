namespace SplitVeryWise.Domain.Exceptions.Group;

public class GroupNotFoundException : SplitVeryWiseException
{

    
    public GroupNotFoundException() : base("Group. Group with specified id was not found")
    {
    }

    public GroupNotFoundException(string additionalInfo) : base("Group. Group with specified id was not found. " + additionalInfo)
    {
    }
}