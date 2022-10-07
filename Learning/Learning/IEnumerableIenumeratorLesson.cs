using System.Collections;

namespace Learning;

public class IEnumerableIEnumeratorLesson 
{
   public void Run()
   {

      var people = new[] { "Tom", "Sam", "Bob" };

      IEnumerator peopleEnumerator = people.GetEnumerator();

      while (peopleEnumerator.MoveNext())
      {
         var item = (string)peopleEnumerator.Current;
         Console.WriteLine(item);
      }
      peopleEnumerator.Reset();
   }
}

public class Week : IEnumerable<string>, IEnumerator<string>
{
   private string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
   private int _position = -1;
   
   
   public IEnumerator<string> GetEnumerator()
   {
      return this;
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }

   public bool MoveNext()
   {
      if (_position < _days.Length - 1)
      {
         _position++;
         return true;
      }

      return false;
   }

   public void Reset()
   {
      _position = -1;
   }

   public string Current
   {
      get
      {
         if (_position == -1 || _position > _days.Length) throw new ArgumentOutOfRangeException();
         return _days[_position];
      }
   }

   object IEnumerator.Current => Current;

   public void Dispose() { }
}