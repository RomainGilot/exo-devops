using System;
using CoursDevOps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOps.UnitTests;

[TestClass]
public class DateValidatorTest
{

    [TestMethod]
    [DataRow("25-10-2023")]
    public void CheckNumberOfDashes_ValidInput_ReturnsTrue(string date)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckNumberOfDashes();

        Assert.IsTrue(result);
    }

    [TestMethod]
    [DataRow("25-10--2023")]
    public void CheckNumberOfDashes_InvalidInput_ThrowsException(string date)
    {
        Assert.ThrowsException<Exception>(() => new DateValidator(date));

    }

    [TestMethod]
    [DataRow("25-10-2023")]
    public void CheckAllNumbersAreIntegers_ValidInput_ReturnsTrue(string date)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckAllNumbersAreIntegers();

        Assert.IsTrue(result);
    }

    [TestMethod]
    [DataRow("20-12-yyyy")]
    public void CheckAllNumbersAreIntegers_InvalidInput_ReturnsFalse(string date)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckAllNumbersAreIntegers();

        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("dd-mm-yyyy")]
    public void ThrowExceptionIfNumbersAreNotIntegers_InvalidInput_ThrowsException(string date)
    {
        var dateValidator = new DateValidator(date);

        Assert.ThrowsException<InvalidCastException>(() => dateValidator.ThrowExceptionIfNumbersAreNotIntegers());
    }

    [TestMethod]
    [DataRow("25-10-2023", true)]
    [DataRow("32-10-2023", false)] 
    public void CheckDayNumber_ValidatesDayNumber(string date, bool expectedResult)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckDayNumber();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("25-10-2023", true)]
    [DataRow("25-13-2023", false)] 
    public void CheckMonthNumber_ValidatesMonthNumber(string date, bool expectedResult)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckMonthNumber();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("25-10-2023", true)]
    [DataRow("25-10-20231", false)] 
    public void CheckYearNumber_ValidatesYearNumber(string date, bool expectedResult)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.CheckYearNumber();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("25-10-2023", true)]
    [DataRow("25-10-20231", false)]
    public void IsValid_ValidInput_ReturnsTrue(string date, bool expectedResult)
    {
        var dateValidator = new DateValidator(date);

        var result = dateValidator.IsValid();

        Assert.AreEqual(expectedResult, result);
    }

}


