using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab1.Rational
{
    interface IComparable
    {
        int CompareTo(Rational compare_obj);
    }

    interface ICloneable
    {
        Rational Clone();
    }

    interface IFormattable
    {
        String ToString(int type);
    }
}
