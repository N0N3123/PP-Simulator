namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; init; } = true;

    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyStatus}) <{Size}>";
        }
    }
}