public class GasContainer : BaseContainer
{
    public double Pressure { get; }

    public GasContainer(double maxLoadKg, double pressure) : base("Gas", maxLoadKg)
    {
        Pressure = pressure;
    }

    public override void Unload() => CurrentLoad *= 0.05;
}