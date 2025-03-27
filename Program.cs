public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("             === SYMULACJA ===");

        var shipA = new Ship("Titan", 30, 5, 100);
        var shipB = new Ship("Poseidon", 28, 3, 60);

        var banana = new RefrigeratedContainer("Banany", 1000, 13.3);
        var iceCream = new RefrigeratedContainer("Lody", 1000, -15);
        var meat = new RefrigeratedContainer("Mieso", 1000, -20);
        var milk = new LiquidContainer(1500, false);
        var fuel = new LiquidContainer(1500, true);
        var helium = new GasContainer(800, 8);

        banana.Load(950);
        meat.Load(800);

        try { iceCream.Load(1000); } catch (Exception ex) { Console.WriteLine(ex.Message); }

        milk.Load(1300);
        try { fuel.Load(800); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        fuel.Load(700);

        helium.Load(700);

        shipA.TryLoadContainer(banana);
        shipA.TryLoadContainer(meat);
        shipA.TryLoadContainer(milk);
        shipA.TryLoadContainer(fuel);
        shipA.TryLoadContainer(helium);

        var extra = new LiquidContainer(500, false);
        extra.Load(300);
        if (!shipA.TryLoadContainer(extra))
        {
            Console.WriteLine("Oczekiwane: nie załadowano dodatkowego kontenera (limit osiągnięty)");
        }

        Console.WriteLine("\n--- STATEK A ---");
        shipA.PrintShip();

        Console.WriteLine("\nRozładunek kontenera gazowego:");
        helium.Unload();
        Console.WriteLine($"{helium.Serial}: {helium.CurrentLoad}");

        var cheese = new RefrigeratedContainer("ser", 1000, 5);
        cheese.Load(400);
        shipA.RemoveContainer(meat.Serial);
        shipA.TryLoadContainer(cheese);

        Console.WriteLine($"\nPrzenoszenie kontenera {banana.Serial} ze statku A do B");
        if (shipB.TryLoadContainer(banana))
        {
            shipA.RemoveContainer(banana.Serial);
            Console.WriteLine($"Przeniesiono kontener {banana.Serial} na statek {shipB.Name}");
        }

        banana.Unload();
        Console.WriteLine($"\nRozładunek kontenera {banana.Serial}: pozostało {banana.CurrentLoad}kg");
        
        Console.WriteLine("\nSTATEK A:");
        shipA.PrintShip();

        Console.WriteLine("\nSTATEK B:");
        shipB.PrintShip();
    }
}