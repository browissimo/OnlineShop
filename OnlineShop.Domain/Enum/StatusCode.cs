using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Enum
{
    public enum StatusCode
    {
        ItemNotFound = 0,
        Ok = 200,
        InternalServerError = 500
    }
}
