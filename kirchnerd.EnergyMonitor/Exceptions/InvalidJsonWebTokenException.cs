namespace kirchnerd.EnergyMonitor.Exceptions;

public class InvalidJsonWebTokenException : Exception
{
    public InvalidJsonWebTokenException() { }
    public InvalidJsonWebTokenException(string missingProperty)
        : base($"Property '{missingProperty}' must not be null in JWT.")
    {
    }
}