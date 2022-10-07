namespace Learning.HomeWorks;

public static class DateTimeHomeWork
{
    public static bool CheckTimePointInLine(DateTime start, DateTime end, DateTime current)
    {
        return current >= start && current <= end;
    }

    public static bool CheckTimeStartPointWithDiapason(TimeOnly startingPoint, TimeOnly currentTimePoint, int minutesDiapason)
    {
        var startPoint = startingPoint.AddMinutes(-minutesDiapason);
        var endPoint = startingPoint.AddMinutes(minutesDiapason);
        
        return currentTimePoint >= startPoint && currentTimePoint <= endPoint;
    }
}