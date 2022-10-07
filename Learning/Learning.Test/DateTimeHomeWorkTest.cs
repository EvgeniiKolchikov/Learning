using Learning.HomeWorks;

namespace Learning.Test;

public class DateTimeHomeWorkTest
{
    [Fact]
    public void CheckTimePointInLine_Return_True()
    {
        //Arrange
        var startPoint = new DateTime(2020, 3, 3, 4, 54, 4);
        var endPoint = new DateTime(2021, 1, 2, 3, 3, 3);
        var currentTimePoint = new DateTime(2020, 10, 3, 2, 2, 2);

        //Act
        var result = DateTimeHomeWork.CheckTimePointInLine(startPoint, endPoint, currentTimePoint);
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void CheckTimePointInLine_Return_False()
    {
        //Arrange
        var startPoint = new DateTime(2020, 3, 3, 4, 54, 4);
        var endPoint = new DateTime(2022, 1, 2, 3, 3, 3);
        var currentTimePoint = new DateTime(2019, 10, 3, 2, 2, 2);

        //Act
        var result = DateTimeHomeWork.CheckTimePointInLine(startPoint, endPoint, currentTimePoint);
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void CheckDateTimeWithDiapason_Return_True()
    {
        //Arrange
        var startPoint = new TimeOnly( 4, 54, 4);
        var checkPoint = new TimeOnly( 4, 3, 3);
        var diapason = 59;

        //Act
        var result = DateTimeHomeWork.CheckTimeStartPointWithDiapason(startPoint, checkPoint, diapason);
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void CheckDateTimeWithDiapason_Return_False()
    {
        //Arrange
        var startPoint = new TimeOnly( 4, 54, 4);
        var checkPoint = new TimeOnly( 4, 3, 3);
        var diapason = 9;

        //Act
        var result = DateTimeHomeWork.CheckTimeStartPointWithDiapason(startPoint, checkPoint, diapason);
        //Assert
        Assert.False(result);
    }
}