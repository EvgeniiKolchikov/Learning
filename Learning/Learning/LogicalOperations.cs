namespace Learning;

public static class LogicalOperations
{
    public static bool? IfElseMethod(string? value)
    {
        if (value == "True") return true;
        else if (value == "true") return true;
        else if (value == "true") return true;
        else if (value == "1") return true;
        else if (value == "1.0") return true;
        else if (value == "False") return false;
        else if (value == "false") return false;
        else if (value == "0") return false;
        else if (value == "0.0") return false;
        else return null;
    }

    public static bool? LogicalMethod(string value)
    {
        bool trueCheck = value == "True" || value == "true" || value == "1" || value == "1.0";
        bool falseCheck = value == "False" || value == "false" || value == "0" || value == "0.0";
        bool otherCheck = trueCheck == false && falseCheck == false;

        return otherCheck == false ? (trueCheck == true ? true : false) : null;
        
    }

    public static bool? ParseMethod(string value)
    {
        bool trueCheck = value == "True" || value == "true" || value == "1";
        bool falseCheck = value == "False" || value == "false" || value == "0";
        bool otherValueCheck = trueCheck == false && falseCheck == false;

        return otherValueCheck == false ? bool.Parse(trueCheck.ToString()) : null;
    }
}