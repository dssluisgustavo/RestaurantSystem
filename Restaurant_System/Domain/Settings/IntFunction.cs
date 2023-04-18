using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Settings
{
    public static class IntFunction
    {
        public static bool IsBetween(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
