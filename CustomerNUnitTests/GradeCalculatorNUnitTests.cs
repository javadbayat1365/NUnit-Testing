using CustomerPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerNUnitTests;

[TestFixture]
public class GradeCalculatorNUnitTests
{
    private GradingCalculator GC;
    [SetUp]
    public void Setup()
    {
        //arrange
        GC = new GradingCalculator();
    }

    [Test]
    [TestCase(91,92)]
    public void GetGrade_ScoreMorethan90AndAttendanceMoreThan90_ReturnA(int score,int attendance)
    {
        //act
        GC.Score = score;
        GC.AttendancePercentage = attendance;
        var result = GC.GetGrade();

        //assert
        Assert.AreEqual(result, 'A');
    }

    [Test]
    [TestCase(98, 92,ExpectedResult = 'A')]
    [TestCase(98, 10,ExpectedResult = 'F')]
    [TestCase(82, 63,ExpectedResult = 'B')]
    public char GetGrade_ScoreAndAttendanceCorrect_ReturnSuitableGrade(int score, int attendance)
    {
        //act
        GC.Score = score;
        GC.AttendancePercentage = attendance;
        var result = GC.GetGrade();

        //assert
       return result;
    }
}
