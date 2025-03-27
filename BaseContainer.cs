public abstract class BaseContainer
{
    private static int serialCounter = 1;
    public string Serial { get; }
    public string Type { get; }
    public double MaxLoadKg { get; }
    public double CurrentLoad { get; protected set; }

    protected BaseContainer(string type, double maxLoadKg)
    {
        Serial = $"KON-{type[0]}-{serialCounter++}";
        Type = type;
        MaxLoadKg = maxLoadKg;
        CurrentLoad = 0;
    }

    public virtual void Load(double kg)
    {
        if (CurrentLoad + kg > MaxLoadKg)
            throw new InvalidOperationException("Overfill detected in container {Serial}");
        CurrentLoad += kg;
    }

    public virtual void Unload() => CurrentLoad = 0;
}