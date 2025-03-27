public class Ship
{
    public string Name { get; }
    public double Speed { get; }
    public int MaxContainers { get; }
    public double MaxWeightTons { get; }
    private readonly List<BaseContainer> containers = new();

    public Ship(string name, double speed, int maxContainers, double maxWeightTons)
    {
        Name = name;
        Speed = speed;
        MaxContainers = maxContainers;
        MaxWeightTons = maxWeightTons;
    }

    public bool TryLoadContainer(BaseContainer container)
    {
        if (containers.Count >= MaxContainers || TotalWeight + container.CurrentLoad / 1000.0 > MaxWeightTons)
            return false;
        containers.Add(container);
        return true;
    }

    public void RemoveContainer(string serial) => containers.RemoveAll(c => c.Serial == serial);

    public void PrintShip()
    {
        Console.WriteLine($"Statek: {Name}\n- Max prędkość: {Speed} węzłów\n- Max kontenery: {MaxContainers}, Max waga: {MaxWeightTons} ton\n- Kontenery:");
        if (!containers.Any())
        {
            Console.WriteLine("  (brak)");
            return;
        }
        foreach (var c in containers)
        {
            Console.WriteLine(c is RefrigeratedContainer rc
                ? $"  - {c.Serial} | typ: {c.Type} | masa: {c.CurrentLoad}/{c.MaxLoadKg}kg | produkt: {rc.Product}, temp: {rc.Temperature}°C"
                : c is LiquidContainer lc
                ? $"  - {c.Serial} | typ: {c.Type} | masa: {c.CurrentLoad}/{c.MaxLoadKg}kg | niebezpieczny: {lc.IsHazardous}"
                : c is GasContainer gc
                ? $"  - {c.Serial} | typ: {c.Type} | masa: {c.CurrentLoad}/{c.MaxLoadKg}kg | ciśnienie: {gc.Pressure} bar"
                : $"  - {c.Serial} | typ: {c.Type} | masa: {c.CurrentLoad}/{c.MaxLoadKg}kg");
        }
    }

    private double TotalWeight => containers.Sum(c => c.CurrentLoad) / 1000.0;
}