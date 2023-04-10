namespace Patterns;

public static class FactoryMethod
{
    public static void Run()
    {
        var orcCreator = new OrcCreator("Morder");
        var skeletCreator = new SkeletonCreator("Dungeon");
        var demonCreator = new DemonCreator("Castle");

        orcCreator.Create();
        skeletCreator.Create();
        demonCreator.Create();

        Console.ReadLine();
    }
}

public abstract class Creator
{
    public string Name { get; set; }

    public Creator(string name)
    {
        Name = name;
    }

    public abstract Unit Create();
}

public class OrcCreator : Creator
{
    public OrcCreator(string name) : base(name)
    {
    }

    public override Unit Create()
    {
        return new Orc();
    }
}

public class SkeletonCreator : Creator
{
    public SkeletonCreator(string name) : base(name)
    {
    }

    public override Unit Create()
    {
        return new Skeleton();
    }
}

public class DemonCreator : Creator
{
    public DemonCreator(string name) : base(name)
    {
    }

    public override Unit Create()
    {
        return new Demon();
    }
}

public abstract class Unit
{
}

public class Orc : Unit
{
    public Orc()
    {
        Console.WriteLine("Orc created: ZAG-ZAG");
    }
}

public class Skeleton : Unit
{
    public Skeleton()
    {
        Console.WriteLine("Skeleton Cratet: jingle bones");
    }
}

public class Demon : Unit
{
    public Demon()
    {
        Console.WriteLine("Demon Created: BUGAGA");
    }
}