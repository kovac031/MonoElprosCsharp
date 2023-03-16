using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemastuff
{
    public interface IMember
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string ContactPhone { get; set; }
    }
}
