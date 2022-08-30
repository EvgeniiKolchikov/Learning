using Learning;


var bobik = new ClassLessonHomeWork("Bobik",0);

var barsik = new ClassLessonHomeWork("Barsik", 3, 1);

bobik.AddDiagnosis(ClassLessonHomeWork.DiagnosisEnum.NoHelp);
barsik.AddDiagnosis(ClassLessonHomeWork.DiagnosisEnum.Surgery);

Console.WriteLine(bobik.ToString());
Console.WriteLine(barsik.ToString());

Console.Read();