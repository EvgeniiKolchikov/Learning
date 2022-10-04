namespace Learning.Test;

public class YieldTest
{
    [Fact]
    public void YieldArrayTest()
    {
        //Arrange
        var myArray = new []{ 12, 21, 33, 45 };
        var index = 0;
        //Act
        IEnumerable<int> GetInts()
        {
            foreach (var v in myArray)
            {
                yield return v;
            }
        }
       
        List<int> GetListInt()
        {
            var list = new List<int>();
            foreach (var v in myArray)
            {
                list.Add(v);
            }
            return list;
        }
        
        var coll = GetInts();
        var list = GetListInt();
        
        //Assert
       
        foreach (var v in coll)
        {
            Assert.Equal(list[index],v);
            index++;
        }
        
    }
}