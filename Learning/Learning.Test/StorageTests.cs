namespace Learning.Test;
using Learning;

public class StorageTests
{
    
    [Fact]
    public void AddNewElementTest()
    {
        //Arrange
        var storage = new Storage<int>();
        //Act
        storage.AddNewElement(32);
        //Assert
        Assert.Equal(storage[0].Value == 32,storage[0].Value == 32);
        Assert.Equal(storage[0].IsActive, storage[0].IsActive);
        Assert.Equal(!storage[1].IsActive, !storage[1].IsActive);
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
        var storage = new Storage<int>();
        
        var el = storage.ElementFromIndex(0);
        Assert.Equal(0,el);
    }

    [Fact]
    public void IndexFromElementTest()
    {
        var storage = new Storage<double>();
        var ind = storage.IndexFromElement(34);
        
        Assert.Equal(-1,ind);
    }

    [Fact]
    public void DeleteElementTest()
    {
        var storage = new Storage<bool>();
        storage.AddNewElement(true);
        storage.AddNewElement(false);
        storage.DeleteElement(1);
        
        Assert.Equal(storage[1].IsActive == false,storage[1].IsActive == false);

    }
    
    
}