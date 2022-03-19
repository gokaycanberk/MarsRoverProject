using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Core.Exceptions
{
    public abstract class BaseExceptions : Exception
    {
        public abstract string ExceptionId { get; set; }
        public abstract string ExceptionMessage { get; set; }
    }
    
}
