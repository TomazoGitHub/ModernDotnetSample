using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDotnetSample.Domain.Enums;

public enum OrderStatus
{
    Created = 0,
    Paid = 1,
    Shipped = 2,
    Cancelled = 3
}