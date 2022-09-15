namespace Learning.Test;
using Learning;

public class StorageTests
{
    
    [Fact]
    public void AddNewElementTest()
    {
        //Arrange
        var storage = new Storage<int>();
        var stringStor = new Storage<string>();
        //Act
        storage.AddNewElement(32);
        stringStor.AddNewElement(null);
        //Assert
        Assert.Equal(storage[0].Value == 32,storage[0].Value == 32);
      
    }

    [Fact]
    public void GetArrayTestIsTypeString()
    {
        //Arrange
        var storage = new Storage<string>();
        //Act
        var array = storage.GetArray();
        //Assert
        Assert.IsType<string[]>(array);
        
    }

    [Fact]
    public void GetElementValueNullTest()
    {
        //Arrange
        var storage = new Storage<string>();
        
        try
        {
            //Act
            var el = storage.ElementFromIndex(1);
        }
        catch (Exception e)
        {
            //Assert
            Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'Индекс должен быть от 0, т.к. массив пустой')",
                e.Message);
        }
    }

    [Fact]
    public void IndexFromElementTest()
    {
        //Arrange
        var storage = new Storage<double>();
        //Act
        var ind = storage.IndexFromElement(34);
        //Assert
        Assert.Equal(-1,ind);
    }

    [Fact]
    public void DeleteElementTest()
    {
        //Arrange
        var storage = new Storage<int>();
      
        try
        {
            //Act
            storage.DeleteElement(10);
           
        }
        catch (NullReferenceException e)
        {
            //Assert
            Assert.Equal("Нельзя удалить из пустого массива",e.Message);
        }
        
        
       

    }
    
    
}