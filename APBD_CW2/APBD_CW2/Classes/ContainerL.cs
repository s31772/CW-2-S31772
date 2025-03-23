using System.Runtime.CompilerServices;

namespace APBD_CW2;

public class ContainerL(double Height, double Weight, double Depth, SerialNumber serialNumber, double maxLoad) 
    : Container(Height, Weight, Depth, serialNumber, maxLoad), IHazardNotifier
{
    public string TypeOfLoad { get; set; } = "null"; 
 
    public void Load (double loadMass,string typeOfLoad ,bool isDangerous, double temperature) 
    {
        if (loadMass > MaxLoad)
        {
            throw new OverfillException("MAX LOAD FOR CONTAINER ["+ serialNumber.SerialNumberIdentifier +"] IS " + MaxLoad + " KILOGRAMS");
        }else if (isDangerous &MaxLoad*0.5<loadMass)
        {
            ((IHazardNotifier)this).Notify(serialNumber);
           
        }
        else if( MaxLoad*0.9  < loadMass)
        {
            ((IHazardNotifier)this).Notify(serialNumber);
        }
        LoadMass = loadMass;
        TypeOfLoad = typeOfLoad;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("LOAD MASS FOR CONTAINER "+ serialNumber.SerialNumberIdentifier +" HAS BEEN SET: "+ typeOfLoad+  "-> "+ loadMass);
        Console.ResetColor();
    }

    public void UnLoad()
    {
        base.UnLoad();
        TypeOfLoad = "null";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("CONTAINER "+serialNumber.SerialNumberIdentifier+" HAS BEEN UNLOADED SUCCESSFULLY");
        Console.ResetColor();
    }

    
}