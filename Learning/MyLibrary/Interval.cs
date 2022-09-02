namespace MyLibrary;

public static class Interval
{
    public static bool IntervalCheck(int start, int end, int value)
    {
        return value <= end && value >= start;
    }

    public static bool RangeCheck(int start, int range, int value)
    {
        return value >= start - range && value <= start + range;
    }
}