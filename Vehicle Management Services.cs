// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

public abstract class ToolVehicle
{
    // Properties
    public int VehicleID { get; set; }
    public string RegNo { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }

    // Static Properties
    public static int TotalVehicles { get; private set; }
    public static int TotalTaxPayingVehicles { get; private set; }
    public static int TotalNonTaxPayingVehicles { get; private set; }
    public static decimal TotalTaxCollected { get; private set; }

    // Constructor
    public ToolVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice, string vehicleType)
    {
        VehicleID = vehicleID;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;
        TotalVehicles++;
    }

    // Abstract Method
    public abstract void PayTax();

    // Method for passing without paying tax
    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;
    }

    // Methods to update static properties
    protected void UpdateTaxCollected(decimal taxAmount)
    {
        TotalTaxCollected += taxAmount;
        TotalTaxPayingVehicles++;
    }
}
public class Car : ToolVehicle
{
    private const decimal CarTaxAmount = 2.0m;

    public Car(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Car") { }

    public override void PayTax()
    {
        UpdateTaxCollected(CarTaxAmount);
    }
}
public class Bike : ToolVehicle
{
    private const decimal BikeTaxAmount = 1.0m;

    public Bike(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Bike") { }

    public override void PayTax()
    {
        UpdateTaxCollected(BikeTaxAmount);
    }
}
public class HeavyVehicle : ToolVehicle
{
    private const decimal HeavyVehicleTaxAmount = 4.0m;

    public HeavyVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Heavy Vehicle") { }

    public override void PayTax()
    {
        UpdateTaxCollected(HeavyVehicleTaxAmount);
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of vehicles
        Car car1 = new Car(1, "ABC123", "Model S", "Tesla", 79999.99m);
        Car car2 = new Car(2, "DEF456", "Model T", "Audi", 8999.45m);
        
        Bike bike1 = new Bike(3, "XYZ987", "Ninja", "Kawasaki", 14999.99m);
        HeavyVehicle heavyVehicle1 = new HeavyVehicle(4, "LMN456", "Actros", "Mercedes", 120000.00m);

        // Vehicles pay tax
        car1.PayTax();
        bike1.PayTax();
        heavyVehicle1.PayTax();

        // Vehicle passes without paying tax
        Car car3 = new Car(5, "DEF456", "Mustang", "Ford", 55999.99m);
        car2.PassWithoutPaying();

        // Output statistics
        Console.WriteLine($"Total Vehicles: {ToolVehicle.TotalVehicles}");
        Console.WriteLine($"Total Tax Paying Vehicles: {ToolVehicle.TotalTaxPayingVehicles}");
        Console.WriteLine($"Total Non-Tax Paying Vehicles: {ToolVehicle.TotalNonTaxPayingVehicles}");
        Console.WriteLine($"Total Tax Collected: ${ToolVehicle.TotalTaxCollected}");
    }
}


