public class LiquidContainer : BaseContainer
{
    public bool IsHazardous { get; }

    public LiquidContainer(double maxLoadKg, bool hazardous) : base("Liquid", maxLoadKg)
    {
        IsHazardous = hazardous;
    }

    public override void Load(double kg)
    {
        double limit = IsHazardous ? MaxLoadKg * 0.5 : MaxLoadKg * 0.9;
        if (CurrentLoad + kg > limit)
            throw new InvalidOperationException($"HAZARD: Overfill detected in container {Serial}");
        base.Load(kg);
    }
}