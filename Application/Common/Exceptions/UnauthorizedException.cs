using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionsEventRestAPI.Application.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base()
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UnauthorizedException(string name, object key)
            : base($"Entity \"{name}\" ({key}) is unauthorized.")
        {
        }

        public UnauthorizedException(string name, object key, int invoker)
            : base($"Entity \"{name}\" ({key}) is unauthorized for \"{invoker}\".")
        {
        }
    }
}
