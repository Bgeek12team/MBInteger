using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MBIClassLib
{

    public static class SBEXT
    {
        public static void Prepend(this StringBuilder sb, string s)
        {
            sb.Insert(0, s);
        }
    }
    /// <summary>
    /// Класс, позволяющий осуществлять работу с большими числами,
    /// которые представляются в памяти в виде строк
    /// </summary>
    public class MyBigInteger : IComparable<MyBigInteger>
    {
        /// <summary>
        /// Строковое представление текущего числа
        /// </summary>
        private string value = "0";
        /// <summary>
        /// Флаг, отображающий, является ли число отрицательным
        /// или положительным
        /// </summary>
        private bool IsNeg = false;
        /// <summary>
        /// Конструктор класса, создающий его экземпляр на основе
        /// числа формата Int64
        /// </summary>
        /// <param name="value">Число в формате Int64, на основе которого
        /// создается экземпляр объекта</param>
        public MyBigInteger(ulong value)
        {
            this.value = value.ToString();
            this.IsNeg = value < 0;
        }
        /// <summary>
        /// Конструктор класса, создающий его экземпляр на основе
        /// числа формата Int64
        /// </summary>
        /// <param name="value">Число в формате Int64, на основе которого
        /// создается экземпляр объекта</param>
        public MyBigInteger(long value)
        {
            this.value = Math.Abs(value).ToString();
            this.IsNeg = value < 0;
        }
        /// <summary>
        /// Конструктор класса, создающий его экземпляр на основе
        /// cтроки
        /// </summary>
        /// <param name="value">Строка, на основе которой
        /// создается экземпляр объекта</param>
        public MyBigInteger(string value)
        {
            MyBigInteger temp = Parse(value);
            this.value = Parse(value).GetValue();
            this.IsNeg = temp.IsNegative();
        }
        /// <summary>
        /// Пустой конструктор класса, создающий его экземпляр
        /// со значением положительного нуля
        /// </summary>

        public MyBigInteger()
        {
            this.value = "0";
        }
        /// <summary>
        /// Закрытый конструктор класса, в котором отсутсвует автоматический
        /// парсинг строки к числу, а знак указывается явно
        /// </summary>
        /// <param name="val">Строка, служащая модулем экземпляра объект</param>
        /// <param name="t">Параметр, явно указывающий знак:
        /// "pos": позитивное число,
        /// остальные значения - отрицательные
        /// </param>]
        private MyBigInteger(string val, string t)
        {
            if (t == "pos")
            {
                this.IsNeg = false;
            }
            else
            {
                this.IsNeg = true;
            }
            this.value = val;

        }
        /// <summary>
        /// Индексатор, возвращающий определенную цифру 
        /// данного числа
        /// </summary>
        /// <param name="n">Порядковый номер возвращаемой цифры числа</param>
        /// <returns>Цифра данного числа по данному порядковому номеру</returns>
        private int this[int n]
        {
            get { return Convert.ToInt32(value[n]); }
        }
        /// <summary>
        /// Метод, который позволяет осуществлять сложение текущего числа
        /// с числом в формате MyBigInteger
        /// </summary>
        /// <param name="second">Слагаемое в формате MyBigInteger</param>
        /// <returns>Сумма текущего числа со слагаемый</returns>
        private MyBigInteger Add(MyBigInteger second)
        {
            if (!this.IsNeg)
            {
                if (second.IsNegative())
                    return this.Sub(new MyBigInteger(second.value, "pos"));
            }
            else
            {
                if (second.IsNegative())
                {
                    MyBigInteger mbi = new MyBigInteger(this.value, "pos").Add(new MyBigInteger(second.value, "pos"));
                    return new MyBigInteger(mbi.value, "neg");
                }
                else
                    return second.Sub(new MyBigInteger(this.value, "pos"));

            }

            int buf = 5;
            StringBuilder result = new StringBuilder("");
            string n = this.value;
            string m = second.value;
            if (n.Length != m.Length)
            {
                if (m.Length > n.Length)
                {
                    n = n.PadLeft(m.Length, '0');
                }
                else
                    m = m.PadLeft(n.Length, '0');
            }
            while (n.Length % buf != 0)
            {
                n = "0" + n;
                m = "0" + m;
            }
            int carry = 0;
            for (int i = n.Length; i > 0; i -= buf)
            {
                int temp = int.Parse(n.Substring(i - buf, buf)) + int.Parse(m.Substring(i - buf, buf)) + carry;
                carry = temp / (int) Math.Pow(10, buf);
                string append = temp.ToString().PadLeft(buf, '0');
                result.Prepend(append.Substring(append.Length - buf, buf));
            }
            if ((carry == 1) && (MyBigInteger.TrimLeftZeros(result.ToString())) == "")
            {
                result.Prepend("1");
            }
            MyBigInteger res = new MyBigInteger(result.ToString());
            return res;
        }

        /// <summary>
        /// Метод, позволяющий осуществлять умножение текущего числа
        /// на множитель в формате MyBigInteger
        /// </summary>
        /// <param name="second">Множитель в формате MyBigInteger</param>
        /// <returns>Произведение текущего объекта и множителя</returns>
        private MyBigInteger Multiply(MyBigInteger second)
        {
            sbyte[] digits1 = new sbyte[this.value.Length];
            for (int i = 0; i < this.value.Length; i++)
            {
                digits1[i] = Convert.ToSByte(this.value.Substring(i, 1));
            }
            sbyte[] digits2 = new sbyte[second.value.Length];
            for (int i = 0; i < second.value.Length; i++)
            {
                digits2[i] = Convert.ToSByte(second.value.Substring(i, 1));
            }
            MyBigInteger result = new MyBigInteger("0", "pos");
            MyBigInteger temp = new MyBigInteger("0", "pos");
            for (int i = 0; i < digits1.Length; i++)
            {
                for (int j = 0; j < digits2.Length; j++)
                {
                    temp.value += "0";
                    temp += digits1[i] * digits2[j];
                }
                result.value += "0";
                result += temp;
                temp = new MyBigInteger("0");
            }
            result.IsNeg = this.IsNegative() ^ second.IsNegative();
            result.value = TrimLeftZeros(result.value);
            return result;
        }
        /// <summary>
        /// Метод, позволяющий осуществлять вычитание из текущего числа
        /// число в формате MyBigInteger
        /// </summary>
        /// <param name="second">Вычитаемое в формате MyBigInteger</param>
        /// <returns>Разность текущего числа и вычитаемого</returns>
        private MyBigInteger Sub(MyBigInteger second)
        {
            if (!this.IsNeg)
            {
                if (second.IsNegative())
                    return this.Add(new MyBigInteger(second.value, "pos"));
            }
            else
            {
                if (second.IsNegative())
                {
                    return new MyBigInteger(second.value, "pos").Sub(new MyBigInteger(this.value, "pos"));
                }
                else
                {
                    MyBigInteger mbi = new MyBigInteger(this.value, "pos").Add(new MyBigInteger(second.value, "pos"));
                    return new MyBigInteger(mbi.GetValue(), "neg");
                }
            }

            bool f = false;
            string n;
            string m;
            if (this > second)
            {
                n = this.value;
                m = second.value;
            }
            else if (this == second)
            {
                return new MyBigInteger("0", "pos");
            }
            else
            {
                f = true;
                n = second.value;
                m = this.value;
            }

            int buf = 5;
            StringBuilder result = new StringBuilder("");
            if (n.Length != m.Length)
            {
                if (m.Length > n.Length)
                {
                    n = n.PadLeft(m.Length, '0');
                }
                else
                    m = m.PadLeft(n.Length, '0');
            }
            while (n.Length % buf != 0)
            {
                n = "0" + n;
                m = "0" + m;
            }
            sbyte borrow = 0;
            int temp;
            for (int i = n.Length; i > 0; i -= buf)
            {
                int n1 = int.Parse(n.Substring(i - buf, buf));
                int n2 = int.Parse(m.Substring(i - buf, buf));
                if (n2 > n1 + borrow)
                {
                    temp = (int)Math.Pow(10, buf) + n1 - n2 - borrow;
                    borrow = 1;
                }
                else
                {
                    temp = n1 - n2 - borrow;
                    borrow = 0;
                }
                string append = temp.ToString().PadLeft(buf, '0');
                result.Prepend(append.Substring(append.Length - buf, buf));
            }
            if (f) 
                return new MyBigInteger(TrimLeftZeros(result.ToString()), "neg"); 
            else 
                return new MyBigInteger(TrimLeftZeros(result.ToString()), "pos");
        }
        /// <summary>
        /// Метод, позволяющий делить текущее число на
        /// делитель в формате MyBigInteger
        /// </summary>
        /// <param name="second">Делитель в формате MyBigInteger</param>
        /// <returns>Частное текущего числа и делителя</returns>
        private MyBigInteger Divide(MyBigInteger second)
        {
            if (second == 1)
                return this;
            string result = "";
            string value1 = this.value;
            string value2 = second.value;
            string str;
            BigInteger remains = 0;
            bool flag = true;
            if (value1[0] == '-' && value2[0] == '-')
            {
                value1 = value1.Remove(0, 1);
                value2 = value2.Remove(0, 1);
                flag = true;
            }
            else if (value1[0] == '-')
            {
                value1 = value1.Remove(0, 1);
                flag = false;
            }
            else if (value2[0] == '-')
            {
                value2 = value2.Remove(0, 1);
                flag = false;
            }
            MyBigInteger res = new MyBigInteger();
            if (value2.Length > value1.Length || value2.Length == 0)
                return new();
            for (int i = 1; i <= value1.Length; i++)
            {
                if (BigInteger.Parse(value1.Substring(0, i)) >= BigInteger.Parse(value2) && remains == 0)
                {
                    if (BigInteger.Divide(BigInteger.Parse(value1), BigInteger.Parse(value2)) > 0)
                    {
                        if (result == "")
                        {
                            result += BigInteger.Divide(BigInteger.Parse(value1.Substring(0, i)), BigInteger.Parse(value2));
                            BigInteger t = BigInteger.Divide(BigInteger.Parse(value1.Substring(0, i)), BigInteger.Parse(value2));
                            remains = (t * (BigInteger.Parse(value2)));
                            remains = BigInteger.Parse(value1.Substring(0, i)) - remains;
                        }
                        else if (remains == 0 && BigInteger.Divide(BigInteger.Parse(value1.Substring(i - 1, 1)), BigInteger.Parse(value2)) > 0)
                        {
                            remains += BigInteger.Parse(value1.Substring(i - 1, 1));
                            result += BigInteger.Divide(remains, BigInteger.Parse(value2));
                            remains -= BigInteger.Parse(value2) * BigInteger.Divide(remains, BigInteger.Parse(value2));
                            continue;
                        }
                        else
                        {
                            result += "0";
                            remains += BigInteger.Parse(value1.Substring(i - 1, 1));

                        }
                    }
                }
                else if (remains != 0)
                {
                    str = remains.ToString() + BigInteger.Parse(value1.Substring(i - 1, 1));
                    if (BigInteger.Divide(BigInteger.Parse(str), BigInteger.Parse(value2)) < 1)
                    {
                        remains = BigInteger.Parse(str);
                        result += "0";
                        continue;
                    }
                    result += BigInteger.Divide(BigInteger.Parse(str), BigInteger.Parse(value2));
                    BigInteger t = BigInteger.Divide(BigInteger.Parse(str), BigInteger.Parse(value2));
                    remains = (t * (BigInteger.Parse(value2)));
                    remains = BigInteger.Parse(str) - remains;
                }
            }
            if (!flag)
                result = result.Insert(0, "-");
            res.value = result;
            return res;
        }
        /// <summary>
        /// Метод, позволяющий взять остаток от деления 
        /// текущего числа на данное в формате MyBigInteger
        /// </summary>
        /// <param name="second">Ч</param>
        /// <returns>Остаток от деления текущего числа на данное</returns>
        private MyBigInteger Mod(MyBigInteger second)
        {
            return this - second * (this / second);
        }
        /// <summary>
        /// Метод, позволяющий возвести текущее число в степень данного
        /// </summary>
        /// <param name="power">
        /// Число в степень которого возводиться текущее
        /// в формате MyBigInteger
        /// </param>
        /// <returns>
        /// Результат возведения текущего числа
        /// в данную степень
        /// </returns>
        private MyBigInteger Pow(MyBigInteger power)
        {
            if (power.IsNegative())
            {
                return 1 / (this.Pow(new MyBigInteger(power.GetValue(), "pos")));
            }
            Stack<bool> order = new Stack<bool>();
            while (power.value != "1")
            {
                string value = power.value;
                order.Push(
                    (byte.Parse(value.Substring(value.Length - 1)) % 2) == 1
                    );
                power = power.Divide(2);
            }
            MyBigInteger Base = this;
            MyBigInteger result = Base;
            foreach(bool b in order)
            {
                result *= result;
                if (b)
                {
                    result *= Base;
                }
            }
            return result;
        }
        static int Bit_Width(long x)
        {
            int n = 0;
            while (x > 0)
            {
                n++;
                x = x / 2;
            }
            return n;
        }
        /// <summary>
        /// Метод, позволяющий найти ближайщее целое число
        /// к данному подкоренному
        /// </summary>
        /// <param name="n">
        /// Подкоренное число в формате MyBigInteger
        /// </param>
        /// <returns>Ближайщее целое число
        /// к подкоренному числу</returns>
        public static MyBigInteger Sqrt(MyBigInteger x1)
        {
            int width;
            long result;
            long x = (long)x1;
            if (x < 5)
            {
                result = x / 2 + x % 2;
            }
            else
            {
                width = Bit_Width(x) - 1;   /* width > 1 */
                result = (1 << (width / 2));
                result = result | ((width % 2) << (width / 2 - 1));
                {
                    long appendix = x & ~(1 << width);
                    appendix = appendix >> (width + 3) / 2;
                    result += appendix;
                }
                result = (x / result + result) / 2;
            }
            return new(result);
        }
        /// <summary>
        /// Находит разложение натурального числа на простые делители и их степени
        /// </summary>
        /// <param name="n">Проверяемое натуральное число от 2</param>
        /// <returns>
        /// Кортеж, состоящий из двух массивов:
        /// массив целочисленных положительных делителей
        /// и массив целочисленных положительных степеней соответсвующих делителей
        /// </returns>
        public static (MyBigInteger[], MyBigInteger[]) Factorize(MyBigInteger n)
        {

            List<MyBigInteger> dividers = new List<MyBigInteger>();
            List<MyBigInteger> powers = new List<MyBigInteger>();
            MyBigInteger[] primes = AllPrimes(new MyBigInteger("2"), n);
            long i = 0;
            int k = 0;
            while (n > 1)
            {
                if (n % primes[i] == 0)
                {
                    dividers.Add(primes[i]);
                    powers.Add(new MyBigInteger(0));
                    while (n % primes[i] == 0)
                    {
                        powers[k]++;
                        n /= primes[i];
                    }
                    k++;
                }
                i++;
            }
            return (dividers.ToArray(), powers.ToArray());
        }
        /// <summary>
        /// Находит все простые числа на отрезке 
        /// от данного натурального d 
        /// до данного натурального n
        /// с помощью метода сегментированного решета Аткина
        /// </summary>
        /// <param name="d">
        /// Начало проверяемого отрезка,
        /// натуральное число от 2
        /// </param>
        /// <param name="n">
        /// Конец проверяемого отрезка,
        /// натуральное число от n
        /// </param>
        /// <returns>Массив простых чисел на отрезке [d; n]</returns>
        private static MyBigInteger[] AllPrimes(MyBigInteger start, MyBigInteger end)
        {
            const int buffer = 100; //размер сегмента в алгоритме
            List<MyBigInteger> primesList = new List<MyBigInteger>();
            if (start <= 2)
            {
                primesList.Add(new MyBigInteger(2));
                primesList.Add(new MyBigInteger(3));
            }
            else if (start == 3)
            {
                primesList.Add(new MyBigInteger(3));
            }
            MyBigInteger startSegment = start;
            MyBigInteger endSegment = start + buffer;
            while (endSegment < end + buffer)
            {
                SieveSegment(startSegment, MyBigInteger.Min(endSegment, end), primesList);
                startSegment = endSegment + 1;
                endSegment += buffer;
            }

            return primesList.ToArray();
        }

        /// <summary>
        /// Обработка сегмента заданного размера в алгоритме решета Аткина
        /// </summary>
        /// <param name="start">Начало сегмента</param>
        /// <param name="end">Конец сегмента</param>
        /// <param name="primesList">Список простых чисел, найденных в предидущих сегментах</param>
        private static void SieveSegment(MyBigInteger start, MyBigInteger end, List<MyBigInteger> primesList)
        {
            MyBigInteger size = end - start + 1;
            bool[] isPrime = new bool[(int)size];
            MyBigInteger sqrt = MyBigInteger.Sqrt(end);

            for (MyBigInteger x = new MyBigInteger(1); x <= sqrt; x++)
            {
                for (MyBigInteger y = new MyBigInteger(1); y <= sqrt; y++)
                {
                    MyBigInteger n = (4 * x * x) + (y * y);
                    if (n >= start && n <= end && (n % 12 == 1 || n % 12 == 5))
                    {
                        isPrime[(int)(n - start)] = !isPrime[(int)(n - start)];
                    }

                    n = (3 * x * x) + (y * y);
                    if (n >= start && n <= end && n % 12 == 7)
                    {
                        isPrime[(int)(n - start)] = !isPrime[(int)(n - start)];
                    }

                    n = (3 * x * x) - (y * y);
                    if (x > y && n >= start && n <= end && n % 12 == 11)
                    {
                        isPrime[(int)(n - start)] = !isPrime[(int)(n - start)];
                    }
                }
            }
            for (MyBigInteger n = start + 2; n <= sqrt; n++)
            {
                if (isPrime[(int)(n - start)])
                {
                    MyBigInteger x = n * n;
                    for (MyBigInteger i = x; i <= end; i += x)
                    {
                        isPrime[(int)(i - start)] = false;
                    }
                }
            }

            for (MyBigInteger i = start; i <= end; i++)
            {
                if (isPrime[(int)(i - start)])
                {
                    primesList.Add(i);
                }
            }
        }
        /// <summary>
        /// Метод, позволяющий найти минимальное из двух данных чисел
        /// в формате MyBigInteger
        /// </summary>
        /// <param name="a">Первое данное число в формате MyBigInteger</param>
        /// <param name="b">Второе данное число в формате MyBigInteger</param>
        /// <returns>Минимальное из двух данных чисел</returns>
        public static MyBigInteger Min(MyBigInteger a, MyBigInteger b)
        {
            if (a >= b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        /// <summary>
        /// Метод, который позволяет осуществлять сложение текущего числа
        /// с числом в формате Int64
        /// </summary>
        /// <param name="second">Слагаемое в формате Int64</param>
        /// <returns>Сумма текущего числа со слагаемым</returns>
        private MyBigInteger Add(long second)
        {
            return this.Add(new MyBigInteger(second));
        }
        /// <summary>
        /// Метод, позволяющий совершать перемножение числа типа MyBigInteger и Long
        /// </summary>
        /// <param name="second">Второй множитель</param>
        /// <returns>Результат произведения двух чисел</returns>
        private MyBigInteger Multiply(long second)
        {
            return this.Multiply(new MyBigInteger(second));
        }
        /// <summary>
        /// Метод, позволяющий находить разность числа типа MyBigInteger и Long
        /// </summary>
        /// <param name="second">Вычитаемое</param>
        /// <returns>Результат вычитания двух чисел</returns>
        private MyBigInteger Sub(long second)
        {
            return this.Sub(new MyBigInteger(second));
        }
        /// <summary>
        /// Метод, позволяющий находить результат деления числа типа MyBigInteger и Long
        /// </summary>
        /// <param name="second">Делитель</param>
        /// <returns>Результат деления двух чисел</returns>
        private MyBigInteger Divide(long second)
        {
            return this.Divide(new MyBigInteger(second));
        }
        /// <summary>
        /// Метод, позволяющий находить остаток от деления числа типа MyBigInteger и Long
        /// </summary>
        /// <param name="second">Делитель</param>
        /// <returns>Остаток от деления</returns>
        private MyBigInteger Mod(long second)
        {
            return this.Mod(new MyBigInteger(second));
        }
        /// <summary>
        /// Метод, позволяющий возводить в степень число типа MyBigInteger
        /// </summary>
        /// <param name="second">Степень</param>
        /// <returns>Результат взведения в степень</returns>
        private MyBigInteger Pow(long second)
        {
            return this.Pow(new MyBigInteger(second));
        }
        /// <summary>
        /// Оператор сложения двух чисел типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат сложения</returns>
        public static MyBigInteger operator +(MyBigInteger first, MyBigInteger Second)
        {
            return first.Add(Second);
        }
        /// <summary>
        /// Оператор вычитания двух чисел типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат вычитания</returns>
        public static MyBigInteger operator -(MyBigInteger first, MyBigInteger Second)
        {
            return first.Sub(Second);
        }
        /// <summary>
        /// Оператор произведения двух чисел типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат произведения</returns>
        public static MyBigInteger operator *(MyBigInteger first, MyBigInteger Second)
        {
            return first.Multiply(Second);
        }
        /// <summary>
        /// Оператор деления двух чисел типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат деления</returns>
        public static MyBigInteger operator /(MyBigInteger first, MyBigInteger Second)
        {
            return first.Divide(Second);
        }
        /// <summary>
        /// Оператор нахождения остатка от деления двух чисел типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Остаток от деления</returns>
        public static MyBigInteger operator %(MyBigInteger first, MyBigInteger Second)
        {
            return first.Mod(Second);
        }
        /// <summary>
        /// Оператор сложения двух чисел типа MyBigInteger и Long
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат сложения</returns>

        public static MyBigInteger operator +(MyBigInteger first, long Second)
        {
            return first.Add(Second);
        }
        /// <summary>
        /// Оператор вычитания числа типа Long из числа типа MyBigInteger
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат вычитания</returns>
        public static MyBigInteger operator -(MyBigInteger first, long Second)
        {
            return first.Sub(Second);
        }
        /// <summary>
        /// Оператор произведения двух чисел типа MyBigInteger и Long
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="Second">Второе число</param>
        /// <returns>Результат произведения</returns>
        public static MyBigInteger operator *(MyBigInteger first, long Second)
        {
            return first.Multiply(Second);
        }
        /// <summary>
        /// Перегрузка оператора деления (/) для объекта MyBigInteger и типа long
        /// </summary>
        /// <param name="first">Делимое в формате объекта MyBigInteger </param>
        /// <param name="second">Делитель типа long</param>
        /// <returns>Результат деления в виде объекта MyBigInteger </returns>
        public static MyBigInteger operator /(MyBigInteger first, long second)
        {
            return first.Divide(second);
        }

        /// <summary>
        /// Перегрузка оператора остатка от деления (%) для объекта MyBigInteger и типа long
        /// </summary>
        /// <param name="first">Делимое в формате объекта MyBigInteger </param>
        /// <param name="second">Делитель типа long</param>
        /// <returns>Осататок от деления в виде объекта MyBigInteger</returns>
        public static MyBigInteger operator %(MyBigInteger first, long second)
        {
            return first.Mod(second);
        }

        /// <summary>
        /// Перегрузка оператора сложения (+) для типа long и объекта MyBigInteger
        /// </summary>
        /// <param name="first">Слагаемое типа long</param>
        /// <param name="second">Слагаемое в виде объекта MyBigInteger</param>
        /// <returns> Сумма в виде объекта MyBigInteger </returns>
        public static MyBigInteger operator +(long first, MyBigInteger second)
        {
            MyBigInteger num = new MyBigInteger(first);
            return num.Add(second);
        }

        /// <summary>
        /// Перегрузка оператора вычитания (-) для типа long и объекта MyBigInteger
        /// </summary>
        /// <param name="first">Уменьшаемое типа long </param>
        /// <param name="second">Вычитаемое в виде объекта MyBigInteger</param>
        /// <returns>Разность в виде объекта MyBigInteger</returns>
        public static MyBigInteger operator -(long first, MyBigInteger second)
        {
            MyBigInteger num = new MyBigInteger(first);
            return num.Sub(second);
        }

        /// <summary>
        /// Перегрузка оператора умножения (*) для типа long и объекта MyBigInteger
        /// </summary>
        /// <param name="first">Множитель типа long</param>
        /// <param name="second">Множитель в виде объекта MyBigInteger</param>
        /// <returns>Произведение в виде  объекта MyBigInteger</returns>
        public static MyBigInteger operator *(long first, MyBigInteger second)
        {
            MyBigInteger num = new MyBigInteger(first);
            return num.Multiply(second);
        }

        /// <summary>
        /// Перегрузка оператора деления (/) для типа long и объекта MyBigInteger
        /// </summary>
        /// <param name="first">Делимое типа long </param>
        /// <param name="second">Делитель в виде объекта MyBigInteger</param>
        /// <returns>Результат деления в виде объекта MyBigInteger </returns>
        public static MyBigInteger operator /(long first, MyBigInteger second)
        {
            MyBigInteger num = new MyBigInteger(first);
            return num.Divide(second);
        }

        /// <summary>
        /// Перегрузка оператора остатка от деления (%) для типа long и объекта MyBigInteger
        /// </summary>
        /// <param name="first">Делимое типа long </param>
        /// <param name="second">Делитель в формате объекта MyBigInteger</param>
        /// <returns>Осататок от деления в виде объекта MyBigInteger</returns>
        public static MyBigInteger operator %(long first, MyBigInteger second)
        {
            MyBigInteger num = new MyBigInteger(first);
            return num.Mod(second);
        }
        /// <summary>
        /// Перегрузка оператора возведения в степень для чисел типа MyBigInteger
        /// </summary>
        /// <param name="num">Число, возводимое в степень</param>
        /// <param name="pow">Степень</param>
        /// <returns></returns>
        public static MyBigInteger operator ^(MyBigInteger num, MyBigInteger pow)
        {
            return num.Pow(pow);
        }
        /// <summary>
        /// Перегрузка оператора неравенства (!=) для объектов MyBigInteger
        /// </summary>
        /// <param name="first">Элемент в формате объекта MyBigInteger </param>
        /// <param name="second">Элемент в формате объекта MyBigInteger</param>
        /// <returns>Элемент типа bool</returns>
        public static bool operator !=(MyBigInteger first, MyBigInteger second)
        {
            return first.CompareTo(second) != 0;
        }

        /// <summary>
        /// Перегрузка оператора равенства (==) для объектов MyBigInteger
        /// </summary>
        /// <param name="first">Элемент в формате объекта MyBigInteger </param>
        /// <param name="second">Элемент в формате объекта MyBigInteger</param>
        /// <returns>Элемент типа bool </returns>
        public static bool operator ==(MyBigInteger first, MyBigInteger second)
        {
            return first.CompareTo(second) == 0;
        }

        /// <summary>
        /// Перегрузка оператора "меньше" (<) для объектов MyBigInteger
        /// </summary>
        /// <param name="first">Элемент в формате объекта MyBigInteger </param>
        /// <param name="second">Элемент в формате объекта MyBigInteger</param>
        /// <returns>Элемент типа bool </returns>
        public static bool operator <(MyBigInteger first, MyBigInteger second)
        {
            return first.CompareTo(second) == -1;
        }

        /// <summary>
        /// Перегрузка оператора "больше" (>) для объектов MyBigInteger
        /// </summary>
        /// <param name="first">Элемент в формате объекта MyBigInteger </param>
        /// <param name="second">Элемент в формате объекта MyBigInteger</param>
        /// <returns>Элемент типа bool </returns>
        public static bool operator >(MyBigInteger first, MyBigInteger Second)
        {
            return first.CompareTo(Second) == 1;
        }

        /// <summary>
        /// Оператор, который сравнивает два числа типа MyBigInteger
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first меньше или равно second, 
        /// false - если first больше second</returns>
        public static bool operator <=(MyBigInteger first, MyBigInteger Second)
        {
            return first.CompareTo(Second) <= 0;
        }
        /// <summary>
        /// Оператор, который сравнивает два числа типа MyBigInteger
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first больше или равно second, 
        /// false - если first меньше second </returns>
        public static bool operator >=(MyBigInteger first, MyBigInteger Second)
        {
            return first.CompareTo(Second) >= 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first != second, 
        /// false - если first == second </returns>
        public static bool operator !=(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) != 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first == second, 
        /// false - если first != second </returns>
        public static bool operator ==(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) == 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first меньше second, 
        /// false - если first больше или равно second </returns>
        public static bool operator <(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) == -1;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first больше second, 
        /// false - если first меньше или равно second </returns>
        public static bool operator >(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) == 1;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first меньше или равно second, 
        /// false - если first больше second </returns>
        public static bool operator <=(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) <= 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа MyBigInteger</param>
        /// <param name="Second">число типа long</param>
        /// <returns>true - в случае, если first больше или равно second, 
        /// false - если first меньше second </returns>
        public static bool operator >=(MyBigInteger first, long Second)
        {
            return first.CompareTo(new MyBigInteger(Second)) >= 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа long</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first не равно second, 
        /// false - если first равно second </returns>
        public static bool operator !=(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) != 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа long</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first равно second, 
        /// false - если first не равно second </returns>
        public static bool operator ==(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) == 0;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа long</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first меньше second, 
        /// false - если first больше или равно second </returns>
        public static bool operator <(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) == 1;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа long</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first больше second, 
        /// false - если first меньше или равно second </returns>
        public static bool operator >(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) == -1;
        }
        /// <summary>
        /// Оператор, который сравнивает число типа MyBigInteger и long
        /// </summary>
        /// <param name="first">число типа long</param>
        /// <param name="Second">число типа MyBigInteger</param>
        /// <returns>true - в случае, если first меньше или равно second, 
        /// false - если first больше second </returns>
        public static bool operator <=(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) >= 0;
        }
        /// <summary>
        /// Оператор сравнения числа типа long с числом типа MyBigInteger
        /// </summary>
        /// <param name="first">Чисто типа long</param>
        /// <param name="Second">Число типа MyBigInteger</param>
        /// <returns></returns>
        public static bool operator >=(long first, MyBigInteger Second)
        {
            return Second.CompareTo(new MyBigInteger(first)) <= 0;
        }
        /// <summary>
        /// Оператор, позволяющий увеличить на единицу число типа MyBigInteger
        /// </summary>
        /// <param name="myBigInteger"></param>
        /// <returns></returns>
        public static MyBigInteger operator ++(MyBigInteger myBigInteger)
        {
            return myBigInteger.Add(1);
        }
        /// <summary>
        /// Оператор, позволяющий увеличить на единицу число типа MyBigInteger
        /// </summary>
        /// <param name="myBigInteger"></param>
        /// <returns></returns>
        public static MyBigInteger operator >>(MyBigInteger myBigInteger, int shift)
        {
            return myBigInteger * (2 ^ shift);
        }
        /// <summary>
        /// Оператор, позволяющий увеличить на единицу число типа MyBigInteger
        /// </summary>
        /// <param name="myBigInteger"></param>
        /// <returns></returns>
        public static MyBigInteger operator <<(MyBigInteger myBigInteger, int shift)
        {
            return myBigInteger / (2 ^ shift);
        }
        /// <summary>
        /// Преобразует число типа MyBigInteger в число типа int
        /// </summary>
        /// <param name="n">преобразуемое число</param>
        public static explicit operator int(MyBigInteger n)
        {
            return int.Parse(n.ToString());
        }
        /// <summary>
        /// Преобразует число типа MyBigInteger в число типа int
        /// </summary>
        /// <param name="n">преобразуемое число</param>
        public static explicit operator long(MyBigInteger n)
        {
            return long.Parse(n.ToString());
        }
        /// <summary>
        /// Преобразует число типа MyBigInteger в число типа int
        /// </summary>
        /// <param name="n">преобразуемое число</param>
        public static explicit operator ulong(MyBigInteger n)
        {
            return ulong.Parse(n.ToString());
        }
        /// <summary>
        /// Метод, который проверяет является ли введенная строка нулём
        /// </summary>
        /// <returns></returns>
        private bool IsZero()
        {
            return value == "0";
        }
        /// <summary>
        /// Метод, который проверяет является ли число отрицательным
        /// </summary>
        /// <returns></returns>
        private bool IsNegative()
        {
            return this.IsNeg;
        }
        /// <summary>
        /// Метод, преобразующий значение MyBiginteger в строку 
        /// </summary>
        /// <returns></returns>
        private string GetValue()
        {
            return this.value;
        }
        /// <summary>
        /// Метод, который по необходимости добавляет к итоговой
        /// строке "-"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IsNeg ? "-" + this.value : this.value;
        }
        /// <summary>
        /// Метод, предоставляет этот хэш-код для алгоритмов,
        /// которым требуется быстрая проверка равенства объектов.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            long hash = 1;
            for (int i = 0; i < value.Length; i++)
            {
                int symbolValue = int.Parse(value[i].ToString());
                hash *= symbolValue * ((int)Math.Pow(17, i) % 65536);
                hash %= int.MaxValue;
            }
            return (int)hash;
        }
        /// <summary>
        /// Метод для проверки на равенство значений
        /// </summary>
        /// <param name="myBigInteger">сравниваемое  число</param>
        /// <returns>возвращает результат сравнения</returns>
        public override bool Equals(object? myBigInteger)
        {
            if (myBigInteger == this)
                return true;

            if (myBigInteger == null)
                return false;

            string num = myBigInteger.ToString();
            if (!IsNumber(num))
                return false;

            MyBigInteger myBigInteger1 = new MyBigInteger(num);
            if (this.GetHashCode() == myBigInteger1.GetHashCode())
                return this.CompareTo(myBigInteger1) == 0;
            return false;
        }
        /// <summary>
        /// Метод, позволяющий скопировать число типа MyBigInteger
        /// </summary>
        /// <param name="first">Копируемое число</param>
        /// <returns>возвращает копию числа</returns>
        private static MyBigInteger Copy(MyBigInteger first)
        {
            return new MyBigInteger(first.GetValue());
        }
        /// <summary>
        /// Метод преобразующий число типа MyBigInteger в строку
        /// </summary>
        /// <param name="num">преобразуемое число</param>
        /// <returns>возвращает преобразованное в строку число </returns>
        /// <exception cref="ArgumentException"></exception>
        public static MyBigInteger Parse(string num)
        {
            string trimmed = num.Trim();
            if (trimmed.Length == 0)
                return new MyBigInteger();

            if (!IsNumber(trimmed))
                throw new ArgumentException("string cannot be a number");

            if (!IsNegative(trimmed))
            {
                trimmed = TrimLeftZeros(trimmed);

                if (trimmed.Length == 0)
                    return new MyBigInteger();

                return new MyBigInteger(trimmed, "pos");
            }
            else
            {
                trimmed = trimmed.Substring(1);
                trimmed = TrimLeftZeros(trimmed);
                if (trimmed.Length == 0)
                    return new MyBigInteger();

                return new MyBigInteger(trimmed, "neg");
            }
        }
        /// <summary>
        /// Метод, который сравнивает данный экземпляр с указанным объектом типа MyBigInteger
        /// и показывает, расположен ли экземпляр перед, после или в той же позиции в порядке
        /// сортировки, что и заданный объект Object.
        /// </summary>
        /// <param name="sec">сравниваемый объект</param>
        /// <returns></returns>
        public int CompareTo(MyBigInteger sec)
        {

            int res = 0;
            int signComp;
            if (this.IsNeg)
            {
                if (sec.IsNeg)
                    signComp = -1;
                else
                    return -1;
            }
            else
            {
                if (sec.IsNeg)
                    return 1;
                else
                    signComp = 1;
            }

            string cur = this.value;
            string s = sec.GetValue();
            if (s.Length < cur.Length)
                s = s.PadLeft(cur.Length, '0');
            if (cur.Length < s.Length)
                cur = cur.PadLeft(s.Length, '0');

            for (int i = 0; i < cur.Length; i++)
            {
                if (cur[i] > s[i])
                {
                    res = 1;
                    break;
                }
                if (cur[i] < s[i])
                {
                    res = -1;
                    break;
                }
            }

            return res * signComp;
        }
        /// <summary>
        /// Метод, который проверяет является ли строка числом
        /// </summary>
        /// <param name="str"> Проверяемая строка </param>
        /// <returns></returns>
        private static bool IsNumber(string str)
        {
            if (!Char.IsDigit(str[0]) && str[0] != '-')
                return false;

            for (int i = 1; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Метод, который убирает лишние слева нули в строке
        /// </summary>
        /// <param name="num"> преобразуемая строка </param>
        /// <returns>возращает строку без лишних нулей слева</returns>
        private static string TrimLeftZeros(string num)
        {
            int i = 0;
            for (i = 0; i < num.Length; i++)
            {
                if (num[i] == '0')
                    continue;
                else
                    break;
            }
            return num.Substring(i);
        }
        /// <summary>
        /// Метод, добавляющий слева к строке минус
        /// </summary>
        /// <param name="num"> преобразуемая строка</param>
        /// <returns>Возвращает строку с минусом слева</returns>
        private static bool IsNegative(string num)
        {
            return num[0] == '-';
        }
        /// <summary>
        /// Метод, который переворачивает строку
        /// </summary>
        /// <param name="str"> преобразуемая строка </param>
        /// <returns>Возвращает перевернутую строку</returns>
        private static string Reverse(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}