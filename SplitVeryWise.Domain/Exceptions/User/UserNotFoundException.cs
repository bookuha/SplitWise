namespace SplitVeryWise.Domain.Exceptions.User;

public class UserNotFoundException : SplitVeryWiseException
{
    public UserNotFoundException() : base("User. User with specified id was not found")
    {
    }

    public UserNotFoundException(string additionalInfo) : base("User. User with specified id was not found. " + additionalInfo)
    {
    }

}