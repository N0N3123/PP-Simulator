namespace Simulator;

public class Orc : Creature
{
    private int rage;
    private int huntCount = 0;

    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() : this("Unknown", 1, 0) { }

    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, an Orc at level {Level} with rage {Rage}!");
    }

    public void Hunt()
    {
        huntCount++;
        if (huntCount % 2 == 0 && rage < 10)
        {
            rage++;
            Console.WriteLine($"{Name}'s rage increased to {Rage}!");
        }
        else
        {
            Console.WriteLine($"{Name} goes on a hunt.");
        }
    }

    public override int Power => 7 * Level + 3 * Rage;
    public override string Info => $"{Name} [{Level}][{Rage}]";
}