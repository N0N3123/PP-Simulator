namespace Simulator;

public class Orc : Creature
{
    private int rage;
    private int hunt_count = 0;
    public int Rage
    {
        get { return rage; }
        init
        {
            rage = Validator.Limiter(value, 0, 10);
        }
    }
    public override int Power => 7 * Level + 3 * rage;
    public void Hunt()
    {
        hunt_count++;
        if (hunt_count % 2 == 0)
        {
            if (rage < 10)
            {
                rage++;
            }
        }
    }
    public Orc() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {rage}.";
    public override string Info => $"{Name} [{Level}][{Rage}]";
    public override char Symbol => 'O';
}
