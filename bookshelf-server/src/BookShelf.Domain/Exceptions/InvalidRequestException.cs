namespace BookShelf.Domain.Exceptions;

public class InvalidRequestException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public InvalidRequestException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public InvalidRequestException(IDictionary<string, string[]> failures) : this()
    {
        Errors = failures;
    }
}
