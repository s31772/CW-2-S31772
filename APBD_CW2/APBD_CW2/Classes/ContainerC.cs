namespace APBD_CW2;

public class ContainerC(double height, double weight, double depth, SerialNumber serialNumber, double maxLoad, double constTemperature)
    : Container(height, weight, depth, serialNumber, maxLoad), IHazardNotifier
{
    public string TypeOfLoad { get; set; } = "null";
    public double Temp{ get; set; } = constTemperature;

    public void Load(double loadMass, string typeOfLoad, bool isDangerous, double neededTemperature)
    {
        if (loadMass > MaxLoad)
        {
            throw new OverfillException("MAX LOAD FOR CONTAINER [" + serialNumber.SerialNumberIdentifier + "] IS " +
                                        MaxLoad + " KILOGRAMS");
        }
        
        if (this.LoadMass != 0)
        {
            Console.WriteLine("THERE CAN BE ONLY ONE TYPE OF PRODUCT IN CONTAINER, LOADING HAS BEEN UNSUCCESSFUL");
        }
        else
        {
            if (neededTemperature != constTemperature)
            {
                ((IHazardNotifier)this).Notify(serialNumber);
                Console.WriteLine("INAPPROPRIATE TEMPERATURE IN CONTAINER");
            }
            
            LoadMass = loadMass;
            TypeOfLoad = typeOfLoad;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LOAD MASS FOR CONTAINER "+ serialNumber.SerialNumberIdentifier +" HAS BEEN SET: "+ typeOfLoad+  "-> "+ loadMass);
            Console.ResetColor();
            
        }
        
    }
    
    public void UnLoad()
        {
           base.UnLoad();
           TypeOfLoad = "null";
           Console.ForegroundColor = ConsoleColor.Blue;
           Console.WriteLine("CONTAINER "+serialNumber.SerialNumberIdentifier+" HAS BEEN UNLOADED SUCCESSFULLY");
           Console.ResetColor();
        }
    public override string ToString()
    {
        return base.ToString() + "\n Type_Of_Load: " + TypeOfLoad;
    }
}