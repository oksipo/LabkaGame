using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    [Flags]
    public enum CardTags
    {
        Priest=1,
        Knight =2,
        Trader = 4,
        Butcher =8,
        War=16,
        Death = 32
    }
}
