namespace SplitVeryWise.Domain.Exceptions.Group;

public class UserIsAlreadyParticipantException : SplitVeryWiseException
{
    public UserIsAlreadyParticipantException() : base("Group. The specified user is already a participant of this group.")
    {
    }

    public UserIsAlreadyParticipantException(string additionalInfo) : base("Group. The specified user is already a participant of this group." + additionalInfo)
    {
    }

}