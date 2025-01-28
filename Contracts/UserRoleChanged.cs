using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class UserRoleChanged
    {
        public Guid UserId { get; init; }
        public string NewRole { get; init; }
    }
}
