using System;

namespace Dto;

public class ExceptionDto : Exception
{
    public ExceptionDto() {}

    public ExceptionDto(string message) : base(message)
    {
        
    }
    
    public ExceptionDto(string message , Exception ex) : base(message , ex)
    {
        InternalException = ex;
    }
    
    public Exception? InternalException { get;}
}