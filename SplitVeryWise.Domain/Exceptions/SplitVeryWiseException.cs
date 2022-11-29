using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitVeryWise.Domain.Exceptions
{
    public class SplitVeryWiseException : Exception
    {
        public SplitVeryWiseException(string message) : base(message){}
    }
}
