namespace APBD_CW2;

public class ContainerG(double Height, double Weight, double Depth, SerialNumber serialNumber, double maxLoad, int maxPressure)
    : Container(Height, Weight, Depth, serialNumber, maxLoad), IHazardNotifier
{
    public int MaxPressure { get; } = maxPressure;
    public bool IsDangerous { get; set; }
    public string TypeOfLoad { get; set; } = null;

    public  void UnLoad()
    {
        this.LoadMass = LoadMass * 0.05;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("CONTAINER "+serialNumber.SerialNumberIdentifier+" HAS BEEN UNLOADED SUCCESSFULLY");
        Console.ResetColor();
        
    }

    public void Load(double loadMass, string typedOfLoad ,bool isDangerous, double temperature)
    {
        if (loadMass > MaxLoad)
        {
            throw new OverfillException("MAX LOAD FOR CONTAINER [" + serialNumber.SerialNumberIdentifier + "] IS " +
                                        MaxLoad + " KILOGRAMS");
        }
        else
        {
            LoadMass = loadMass;
            IsDangerous = isDangerous;
            TypeOfLoad = typedOfLoad;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LOAD MASS FOR CONTAINER "+ serialNumber.SerialNumberIdentifier +" HAS BEEN SET: "+ TypeOfLoad+  "-> "+ loadMass);
            Console.ResetColor();
        }
    }
    

    public override string ToString()
    {
        return base.ToString()+ "\n Is Dangerous: "+ IsDangerous + " MaxPressure: " + MaxPressure;
    }
}