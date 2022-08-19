using Learning;

var methodLesson = new MethodLesson();

methodLesson.Hello();
methodLesson.SayHello();
methodLesson.PrintMessage("Hi");
methodLesson.Sum(11,2);
methodLesson.Sum2(13,9);
methodLesson.PrintPerson("Nik",112);

byte b = 34;
methodLesson.PrintPerson("Roma",b);
methodLesson.PrintPersonOptional("Henry", 44,"Apple");
methodLesson.PrintPersonOptional("Garry",65);
methodLesson.PrintPersonOptional();
methodLesson.PrintPerson(age: 54, name: "Ter");
