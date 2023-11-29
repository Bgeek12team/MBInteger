using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBIClassLib
{
    static class extensionKaratsubaMult
    {
        public static MyBigInteger multiply(this MyBigInteger MBInteger, MyBigInteger second)
        {
            return KaratsubaMultiply(MBInteger, second);
        }
        private static MyBigInteger KaratsubaMultiply(MyBigInteger x, MyBigInteger y)
        {
            MyBigInteger a = new MyBigInteger(), b = new MyBigInteger(), c = new MyBigInteger(), d = new MyBigInteger();
            MyBigInteger ac = new MyBigInteger(), bd = new MyBigInteger();
            MyBigInteger result;
            int size = Math.Max(GetNumberSize(x), GetNumberSize(y));

            if (size == 1)
            {
                return x * y;
            }

            MyBigInteger halfSize = new(size / 2);
            MyBigInteger halfSizeDegree = new MyBigInteger(10) ^ halfSize;
            Parallel.Invoke(
                () => { a = x / halfSizeDegree; },
                () => { b = x % halfSizeDegree; },
                () => { c = y / halfSizeDegree; },
                () => { d = y % halfSizeDegree; }
            );

            Parallel.Invoke(
                () => { ac = KaratsubaMultiply(a, c); },
                () => { bd = KaratsubaMultiply(b, d); }
            );
            MyBigInteger adbc = KaratsubaMultiply((a + b), (c + d)) - ac - bd;


            result = (ac * (new MyBigInteger(10) ^ (halfSize * 2))) + (adbc * halfSizeDegree) + bd;

            return result;
        }

        private static int GetNumberSize(MyBigInteger number)
        {
            return number.ToString().Length;
        }

    }
}
