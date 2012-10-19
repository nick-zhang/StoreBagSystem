using System;

namespace StoreBagSystem
{
    public class CabinetException : ApplicationException
    {
        public CabinetException(string noBoxAvailable) : base(noBoxAvailable)
        {
            
        }
    }
}