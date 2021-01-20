using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenNumber
{
    class OfficeHours
    {
    }

    [Flags]
    enum Week : sbyte
    {
        Monday = 0b_0000001,
        Tuethday = 0b_0000010,
        Wednesday = 0b_0000100,
        Thirsday = 0b_0001000,
        Friday = 0b_0010000,
        Satarday = 0b_0100000,
        Sunday = 0b_1000000
    }

    struct Office
    {
        public sbyte workDays { get; set; }
    }
}
