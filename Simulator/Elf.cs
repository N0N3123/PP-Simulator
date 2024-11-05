namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCount = 0;

    public int Agility
    {
        get => agility;
        init
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 10)
            {
                value = 10;
            }
            agility = value;
        }
    }
    public Elf() { }

    public Elf(string name = "Unknown", int level = 1, int agility = 1): base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}");

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCount++;
        if (singCount % 3 == 0 && Agility < 10)
        {
            agility++;
            Console.WriteLine($"{Name}'s agility increased to {Agility}!");
        }
    }

    public override int Power => (8 * Level) + (2 * Agility);
}