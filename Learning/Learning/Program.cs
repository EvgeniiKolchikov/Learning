using Learning;

var constVsReadonly = new ConstVsReadonlyLesson(32);

constVsReadonly.GetReadonlyFields();

ConstVsReadonlyLesson.GetConstFields();
Console.WriteLine(ConstVsReadonlyLesson.PI);
Console.Read();

