using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Enum
{
    public enum StatusCode
    {
        Ok = 200,

        UserNotFound = 01,
        ItemNotFound = 02,
        InternalServerError = 500
    }
}
