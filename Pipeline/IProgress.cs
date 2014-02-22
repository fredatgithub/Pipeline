using System;
using System.Collections.Generic;

namespace Pipeline
{
    public interface IProgress
    {        
        bool Completed { get; }
        bool Cancelled { get; }
        Exception Error { get; }
        List<object> Results { get; }
    }
}
