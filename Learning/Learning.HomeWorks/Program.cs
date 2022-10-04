using Learning.HomeWorks;


var archive = new []
{
    "AA134AA77", "AA111AA77", "BG543JK37", "AA113BH78", "GF456JK03", "HA143KL65"
};


var input = Console.ReadLine();

var regex = StringBuilderRegexHomeWork.RegexInit(input);

var matches = StringBuilderRegexHomeWork.GetMatches(regex, archive);

StringBuilderRegexHomeWork.ShowMatches(matches);





