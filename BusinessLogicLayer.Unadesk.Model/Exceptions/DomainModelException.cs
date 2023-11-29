// ReSharper disable UnusedMember.Global

namespace BusinessLogicLayer.Unadesk.Model.Exceptions;

/// <summary>
/// Domain model exception class.
/// </summary>
public class DomainModelException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public DomainModelException()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DomainModelException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public DomainModelException(string message, Exception inner) : base(message, inner)
    {
    }
}