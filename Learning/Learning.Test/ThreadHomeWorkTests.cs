using Learning.HomeWorks;

namespace Learning.Test;

public class ThreadHomeWorkTests
{
    [Fact]

    public void ThreadMethod_Argument_Not_Int()
    {
        //Arrange
        var threads = new ThreadArrayHomeWork(10);
        //Act
        threads.TaskMethod();
        //Assert
    }
}