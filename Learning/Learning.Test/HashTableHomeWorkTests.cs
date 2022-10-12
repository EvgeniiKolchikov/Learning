using Learning.HomeWorks;

namespace Learning.Test;

public class HashTableHomeWorkTests
{
    [Fact]
    public void AddElement_Correct_Add_In_Table()
    {
        //Arrange
        var hastable = new HashTableHomeWork<Something>(10);
        //Act
        hastable.AddNewElement(new Something("Julia",3));
        //Assert
        
        Assert.True(hastable[9].Notes.Contains(new Something("Julia",3)));
    }
    
}