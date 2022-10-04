using Learning.HomeWorks;

namespace Learning.Test;


public class RegexHomeWorkTests
{
    [Fact]
    public void RegexInitNullInputTest()
    {
        //Arrange
        var s = "";
        
        try
        {
            //Act
            StringBuilderRegexHomeWork.RegexInit(s);
        }
        catch (ArgumentNullException e)
        {
            //Assert
            Assert.Equal("Пусто, Введите значение поиска", e.Message);
        }
    }

    [Fact]
    public void IncorrectInputRegexInitTest()
    {
        //Arrange
        var s = "/";
        //Act
        var ex = Assert.Throws<ArgumentException>(() => StringBuilderRegexHomeWork.RegexInit(s));
        //Assert
        Assert.Equal("Некорректный формат поиска", ex.Message);
    }

    [Fact]
    public void CorrectInputRegexInitTest()
    {
        //Arrange
        var s = "AA*";
        //Act
        var regex = StringBuilderRegexHomeWork.RegexInit(s);
        //Assert
        Assert.Equal(@"^AA\w\w*",regex.ToString());
    }

    [Fact]
    public void GetMatches_Return_IEnumerable_Collection()
    {
        //Arrange
        var archive = new[] { "AA123BB12","AA2223232" };
        var input = "AA*";
        //Act
        var regex = StringBuilderRegexHomeWork.RegexInit(input);
        var matches = StringBuilderRegexHomeWork.GetMatches(regex, archive);
        //Assert
        Assert.True(matches.SequenceEqual(archive));
    }
}