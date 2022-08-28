using System.Threading.Channels;
using Learning;

var classLesson = new ClassLesson();
var name = ClassLesson.ConstString;

var bob = new ClassLesson();
var tom = new ClassLesson("Tom");
var rex = new ClassLesson("Rex", 44);
ClassLesson hty = new(32, 23, 33);

var o = new ClassLesson{number = 32, number2 = 2, name = "333"};
var constructInit = new ClassLesson { number = 33, company = { title = "AppleJuice" } };

var cv = new ClassLesson(name: "3444fdsf");

var clasToParameter = new ClassLesson(bob);
    
Console.Read();
//classLesson.PrintName();