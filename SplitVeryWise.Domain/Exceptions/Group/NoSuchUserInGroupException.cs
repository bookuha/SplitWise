namespace SplitVeryWise.Domain.Exceptions.Group;

public class NoSuchUserInGroupException : SplitVeryWiseException
{
    public NoSuchUserInGroupException() : base("Group. A participant with specified id was not found.")
    {
    }

    public NoSuchUserInGroupException(string additionalInfo) : base("Group. A participant with specified id was not found. " + additionalInfo)
    {
    }

}