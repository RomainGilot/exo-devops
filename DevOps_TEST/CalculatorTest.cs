using CoursDevOps;

namespace DevOps_TEST;

[TestClass]
public class CalculatorTests
{

    private Calculator _calculator;

    [TestInitialize]
    public void Init()
    {
        _calculator = new Calculator();
    }

    [TestMethod]
    [DataRow(3, 3, 6)]
    [DataRow(28, 11, 39)]
    public void Add_WithTwoNumbers_ReturnInt(int number1, int number2, int expectedResult)
    {
        var result = _calculator.Add(number1, number2);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(4, 3, 1)]
    [DataRow(62, 11, 51)]
    public void Substract_WithTwoNumbers_ReturnInt(int number1, int number2, int expectedResult)
    {
        var result = _calculator.Substract(number1, number2);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(4, 2, 8)]
    [DataRow(8, 8, 64)]
    public void Multiply_WithTwoNumbers_ReturnInt(int number1, int number2, int expectedResult)
    {
        var result = _calculator.Multiply(number1, number2);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(6, 6, 1)]
    [DataRow(14, 2, 7)]
    public void Divide_WithTwoNumbers_ReturnInt(int number1, int number2, int expectedResult)
    {
        var result = _calculator.Divide(number1, number2);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(1, 0)] // Si le nombre 2 = à 0
    [DataRow(23, 0)] // Si le nombre 2 = à 0
    public void Divide_WithTwoNumbers_Number2Egal0_ThrowsArgumentException(int number1, int number2)
    {
        Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(number1, number2));
    }
}
