using System;
using CoursDevOps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOps.UnitTests;

[TestClass]
public class ElevatorTest
{
    [TestMethod]
    [DataRow(15, 5, 5)] 
    [DataRow(15, 10, 10)]
    [DataRow(15, 3, 3)]
    public void InUser_AddsUserToCurrentWeight(int maxHeight, int userWeight, int expectedResult)
    {
        Elevator elevator = new Elevator(maxHeight); 
        Employee user = new Employee { Weight = userWeight };

        elevator.InUser(user);


        Assert.AreEqual(expectedResult, elevator.CurrentWeight);
    }

    [TestMethod]
    [DataRow(15, 5, 5, 0)]  
    [DataRow(15, 10, 10, 0)]
    [DataRow(15, 3, 3, 0)]
    public void OutUser_RemovesUserFromCurrentWeight(int maxHeight, int initialWeight, int userWeight, int expectedCurrentWeight)
    {
        Elevator elevator = new Elevator(maxHeight); 
        Employee user = new Employee { Weight = userWeight };
        elevator.InUser(new Employee { Weight = initialWeight });

        elevator.OutUser(user);

        Assert.AreEqual(expectedCurrentWeight, elevator.CurrentWeight);
    }

    [TestMethod]
    [DataRow(15, 17, true)]
    [DataRow(5, 4, false)]
    [DataRow(4, 2, false)]
    public void CheckMaxWeightAllowedReached_ReturnsResult(int maxHeight, int currentWeight, bool expectedResult)
    {
        Elevator elevator = new Elevator(maxHeight);
        elevator.CurrentWeight = currentWeight;

        bool result = elevator.CheckMaxWeightAllowedReached();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(20, 17, false, false)]
    [DataRow(20, 17, true, true)]
    public void GoToVipSection_ReturnsFalseForNonExecutiveUser(int maxHeight, int userWeight, int currentWeight, bool expectedResult)
    {
        Elevator elevator = new Elevator(maxHeight);
        Employee user = new Employee { Weight = userWeight };

        elevator.InUser(user);

        bool result = elevator.GoToVipSection(user);

        Assert.AreEqual(expectedResult, result);
    }

}


