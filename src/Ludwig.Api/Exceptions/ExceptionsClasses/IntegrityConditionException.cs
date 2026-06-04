namespace Ludwig.Api.Exceptions.ExceptionsClasses;

public class IntegrityConditionException : Exception
{

    public IntegrityConditionException(string message) : base(message) { }

}