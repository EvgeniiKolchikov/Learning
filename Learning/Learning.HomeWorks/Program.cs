using Learning.HomeWorks;


// DateTimeHomeWork

var start = new DateTime(2022, 10, 1, 14, 43, 32);
var end = new DateTime(2022, 10, 7, 0, 0, 0);
var checkDateTime1 = new DateTime(2022, 10, 4, 15, 25, 32);
var checDateTime2 = new DateTime(2022, 10, 1, 14, 43, 30);

var check1 = DateTimeHomeWork.CheckTimePointInLine(start, end, checkDateTime1);
var check2 = DateTimeHomeWork.CheckTimePointInLine(start, end, checDateTime2);
var check3 = DateTimeHomeWork.CheckTimePointInLine(end, start, checkDateTime1);
Console.WriteLine("Check1 - {0}",check1);
Console.WriteLine("Check2 - {0}",check2);


var startPoint = new TimeOnly(13, 0, 0);
var currentPoint = new TimeOnly(13, 10, 0);
var minute1 = 15;
var minute2 = 7;

var check4 = DateTimeHomeWork.CheckTimeStartPointWithDiapason(startPoint, currentPoint, minute1);
var check5 = DateTimeHomeWork.CheckTimeStartPointWithDiapason(startPoint, currentPoint, minute2);
Console.WriteLine($"Check4 - {check4}");
Console.WriteLine($"Check5 - {check5}");


