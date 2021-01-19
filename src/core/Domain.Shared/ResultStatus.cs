namespace Domain.Shared.Exceptions
{
    public enum ResultStatus
    {
        Success = 1000,
        ValidationError = 1001,
        
        //Users
        UserNotFound = 10001
    }
}