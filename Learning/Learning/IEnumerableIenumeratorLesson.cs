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

public class Week 
{
   private string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
   public IEnumerator GetEnumerator() => new WeekEnumenator(days);

}

public class WeekEnumenator : IEnumerator<string>
{
   private string[] _days;
   private int _position = -1;
   private string _current;
   public WeekEnumenator(string[] days) => _days = days;
   public object Current 
   {
      get
      {
         if (_position == -1 || _position > _days.Length) throw new ArgumentOutOfRangeException();
         return _days[_position];
      }
   }
   
   public bool MoveNext()
   {
      if (_position<_days.Length-1)
      {
         _position++;
         return true;
      }

      return false;
   }

   public void Reset() => _position = -1;

   string IEnumerator<string>.Current => _current;

   public void Dispose() { }
}