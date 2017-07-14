using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Orm.Enums
{
    public enum Status
    {
        None,
        Active,
        Inactive,
        Disabled,
        Available,
        Unavailable,
        Deleted,
        NotOnSale
    }
}
