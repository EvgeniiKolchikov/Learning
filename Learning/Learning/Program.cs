using Learning;
using MyLibrary;

var sm = new StaticModifierLesson();
Console.WriteLine(StaticModifierLesson.GetCount());
var sm2 = new StaticModifierLesson();



var count = StaticModifierLesson.GetCount();
Console.WriteLine(count);

var objCount = sm.GetObjectCount();
Console.WriteLine(objCount);
