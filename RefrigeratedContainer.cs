public class RefrigeratedContainer : BaseContainer
{
    public string Product { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(string product, double maxLoadKg, double temperature)
        : base("Chlodniczy", maxLoadKg)
    {
        double requiredTemp = GetMinTemperatureForProduct(product);
        if (temperature > requiredTemp)
            Console.WriteLine($"Produkt '{product}' wymaga <= {requiredTemp}°C, a podano {temperature}°C");
        Product = product;
        Temperature = temperature;
    }

    private static double GetMinTemperatureForProduct(string product) => product.ToLower() switch
    {
        "banany" => 13.3, "czekolada" => 18.0, "mieso" => -15.0,
        "lody" => -18.0, "pizza" => -30.0, "maslo" => 20.5,
        "ryby" => 2.0, "jajka" => 19.0, "ser" => 7.2,
        "kielbasa" => 5.0, _ => 0.0
    };
}