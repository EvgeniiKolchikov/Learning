namespace Learning;

public static class LogicalOperations
{
    public static bool? IfElseMethod(string? value)
    {
        if (value == "True") return true;
        if (value == "true") return true;
        if (value == "1") return true;
        if (value == "1.0") return true;
        if (value == "False") return false;
        if (value == "false") return false;
        if (value == "0") return false;
        if (value == "0.0") return false;
        return null;
    }

    public static bool? LogicalMethod(string value)
    {
        var trueCheck = value == "True" || value == "true" || value == "1" || value == "1.0";
        var falseCheck = value == "False" || value == "false" || value == "0" || value == "0.0";
        var otherCheck = trueCheck == false && falseCheck == false;

        return otherCheck == false ? trueCheck : null;
        
    }

    public static bool? ParseMethod(string value)
    {
        var trueCheck = value == "True" || value == "true" || value == "1";
        var falseCheck = value == "False" || value == "false" || value == "0";
        var otherValueCheck = trueCheck == false && falseCheck == false;

        return otherValueCheck == false ? bool.Parse(trueCheck.ToString()) : null;
    }
}