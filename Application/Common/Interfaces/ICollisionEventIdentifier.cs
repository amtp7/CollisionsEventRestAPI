using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionsEventRestAPI.Application.Common.Interfaces
{
    public interface ICollisionEventIdentifier
    {
        Guid New { get; }
    }
}
