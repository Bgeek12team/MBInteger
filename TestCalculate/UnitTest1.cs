using MBIClassLib;
using System.Numerics;

namespace TestCalculate
{
    /// <summary>
    /// Класс проверяющий работу основной арифметики проекта 
    /// MyBigInteger
    /// </summary>
    [TestClass]
    public class MYBIGINTTEST
    {
        /// <summary>
        /// Тест метод складывающий число с единицей
        /// </summary>
        [TestMethod]
        public void AddTest1()
        {
            MyBigInteger first = new MyBigInteger("1000000000000000");
            MyBigInteger second = new MyBigInteger("1");

            MyBigInteger result = new MyBigInteger("1000000000000001");
            Assert.AreEqual((first + second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод складывающий два длинных числа
        /// </summary>
        [TestMethod]
        public void AddNegativeZero()
        {
            MyBigInteger first = new MyBigInteger("0");
            MyBigInteger second = new MyBigInteger("-1");

            MyBigInteger result = new MyBigInteger("-1");
            Assert.AreEqual((first + second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод складывающий два длинных числа
        /// </summary>
        [TestMethod]
        public void AddBigValue()
        {
            MyBigInteger first = new MyBigInteger("9123718932781783189731831798398139781397892");
            MyBigInteger second = new MyBigInteger("6782173189737178978913789179891278378913197831798397813");

            MyBigInteger result = new MyBigInteger("6782173189746302697846570963081010210711595971579795705");
            Assert.AreEqual((first + second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод складывающий два отрицательных числа
        /// </summary>
        [TestMethod]
        public void AddNegative()
        {
            MyBigInteger first = new MyBigInteger("-4256");
            MyBigInteger second = new MyBigInteger("-5544");

            MyBigInteger result = new MyBigInteger("-9800");
            Assert.AreEqual((first + second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод вычитающий из нуля длинное число
        /// </summary>
        [TestMethod]
        public void SubWithLongValue()
        {
            MyBigInteger first = new MyBigInteger("0");
            MyBigInteger second = new MyBigInteger("554492138913138809138190908321809389012381381300918290381389013801931");

            MyBigInteger result = new MyBigInteger("-554492138913138809138190908321809389012381381300918290381389013801931");
            Assert.AreEqual((first - second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод вычитающий отрицательное число
        /// </summary>
        [TestMethod]
        public void SubWithNegative()
        {
            MyBigInteger first = new MyBigInteger("391037192793010792370103717039810318909");
            MyBigInteger second = new MyBigInteger("-55449289012381381300918290381389013801931");

            MyBigInteger result = new MyBigInteger("55840326205174392093288394098428824120840");
            Assert.AreEqual((first - second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод вычитающий два отрицательных числа
        /// /// </summary>
        [TestMethod]
        public void SubWithTwoNegative()
        {
            MyBigInteger first = new MyBigInteger("-76318912831");
            MyBigInteger second = new MyBigInteger("-7721371838");

            MyBigInteger result = new MyBigInteger("-68597540993");
            Assert.AreEqual((first - second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод перемножающий два длинных числа
        /// /// </summary>
        [TestMethod]
        public void MultiplyBase()
        {
            MyBigInteger first = new MyBigInteger("13177893199312881923");
            MyBigInteger second = new MyBigInteger("233393932909390390093003129");

            MyBigInteger result = new MyBigInteger("3075640321247542647387765961144838638846537067");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод умножающий число на 0
        /// /// </summary>
        [TestMethod]
        public void MultiplyOnZero()
        {
            MyBigInteger first = new MyBigInteger("13380180381903813980189038139981902398190213177893199312881923");
            MyBigInteger second = new MyBigInteger("0");

            MyBigInteger result = new MyBigInteger("0");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод умножающий 0 на 0
        /// /// </summary>
        [TestMethod]
        public void MultiplyZeroOnZero()
        {
            MyBigInteger first = new MyBigInteger("0");
            MyBigInteger second = new MyBigInteger("0");

            MyBigInteger result = new MyBigInteger("0");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод умножающий число на 1
        /// /// </summary>
        [TestMethod]
        public void MultiplyOnOne()
        {
            MyBigInteger first = new MyBigInteger("513380180381903813980189038139981902398190213177893199312881923");
            MyBigInteger second = new MyBigInteger("1");

            MyBigInteger result = new MyBigInteger("513380180381903813980189038139981902398190213177893199312881923");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод умножающий на отрицательное число
        /// /// </summary>
        [TestMethod]
        public void MultiplyOnNegative()
        {
            MyBigInteger first = new MyBigInteger("513380180381903813980189038139981902398190213177893199312881923");
            MyBigInteger second = new MyBigInteger("-7818281878");

            MyBigInteger result = new MyBigInteger("-4013750960804209707980395007904071334767735283685679190407346790544691394");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод делящий число на 0
        /// /// </summary>
        [TestMethod]
        public void Dividewithzero()
        {
            MyBigInteger first = new MyBigInteger("82139013890182390112312");
            MyBigInteger second = new MyBigInteger("0");

            MyBigInteger result = new MyBigInteger("0");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод выполняющий простое деление
        /// /// </summary>
        [TestMethod]
        public void DividewithMyBigInteger()
        {
            MyBigInteger first = new MyBigInteger("82139013890182390112312");
            MyBigInteger second = new MyBigInteger("7472742373");

            MyBigInteger result = new MyBigInteger("10991816630392");
            Assert.AreEqual((first * second).ToString(), result.ToString());
        }
        /// <summary>
        /// Тест метод сравнивающий два одинаковых числа
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion()
        {
            MyBigInteger first = new MyBigInteger("82139013890182390112312");
            MyBigInteger second = new MyBigInteger("82139013890182390112312");

            bool result = true;
            Assert.AreEqual(first == second, result);
        }
        /// <summary>
        /// Тест метод сравнивающий два разных числа
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion2()
        {
            MyBigInteger first = new MyBigInteger("82139013890182390112312");
            MyBigInteger second = new MyBigInteger("8213901389018239011231");

            bool result = true;
            Assert.AreEqual(first != second, result);
        }
        /// <summary>
        /// Тест метод проверяющий знак >
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion3()
        {
            MyBigInteger first = new MyBigInteger("82139013890182390112312");
            MyBigInteger second = new MyBigInteger("8213901389018239011231");

            bool result = true;
            Assert.AreEqual(first > second, result);
        }
        /// <summary>
        /// Тест метод проверяющий знак <
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion4()
        {
            MyBigInteger first = new MyBigInteger("8213");
            MyBigInteger second = new MyBigInteger("8213901389018239011231");

            bool result = true;
            Assert.AreEqual(first < second, result);
        }
        /// <summary>
        /// Тест метод проверяющий знак >=
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion5()
        {
            MyBigInteger first = new MyBigInteger("8213");
            MyBigInteger second = new MyBigInteger("2367");

            bool result = true;
            Assert.AreEqual(first >= second, result);
        }
        /// <summary>
        /// Тест метод проверяющий знак <=
        /// /// </summary>
        [TestMethod]
        public void TestByComparsion6()
        {
            MyBigInteger first = new MyBigInteger("821371798317837");
            MyBigInteger second = new MyBigInteger("2367371131798318978931");

            bool result = true;
            Assert.AreEqual(first <= second, result);
        }
        /// <summary>
        /// Тест метод возводящий в степень 0
        /// /// </summary>
        [TestMethod]
        public void ExponentiationWithZero()
        {
            MyBigInteger first = new MyBigInteger("63515253177317381381381673713813781317837");
            MyBigInteger second = new MyBigInteger("0");

            MyBigInteger result = new MyBigInteger("1");
            Assert.AreEqual(first ^ second, result);
        }
        /// <summary>
        /// Тест метод остаток от деления
        /// /// </summary>
        [TestMethod]
        public void ModTest()
        {
            MyBigInteger first = new MyBigInteger("12");
            MyBigInteger second = new MyBigInteger("5"); 

            MyBigInteger result = new MyBigInteger("2");
            Assert.AreEqual(first % second, result);
        }
        /// <summary>
        /// Тест метод проверяющий отстаток четного числа
        /// при делении на 2
        /// /// </summary>
        [TestMethod]
        public void ModTestOnTwo()
        {
            MyBigInteger first = new MyBigInteger("1231892381319028390183890139810982");
            MyBigInteger second = new MyBigInteger("2");

            MyBigInteger result = new MyBigInteger("0");
            Assert.AreEqual(first % second, result);
        }
        /// <summary>
        /// Тест метод вычисляющий корень из числа
        /// /// </summary>
        [TestMethod]
        public void SqrtByOn()
        {
            MyBigInteger first = new MyBigInteger("1");

            MyBigInteger result = new MyBigInteger("1");
            Assert.AreEqual(MyBigInteger.Sqrt(first), result);
        }


    }
}