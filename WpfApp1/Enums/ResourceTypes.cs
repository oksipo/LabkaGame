using System;

namespace Enums
{
    [Flags]
    public enum ResourceTypes
    {
        Religion = 1,
        Money = 2,
        Army = 4,
        People = 8
    }
}
