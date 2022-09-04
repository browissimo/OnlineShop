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
        ItemNotFound = 0,
        InternalServerError = 500
    }
}
