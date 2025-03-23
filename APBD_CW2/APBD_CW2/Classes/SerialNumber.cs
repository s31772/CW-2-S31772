namespace APBD_CW2;

public class SerialNumber(string containerType)
{
    public string SerialNumberIdentifier { get; private set; } = "KON-" + containerType + "-"+ ++counter;
    private static int counter = 0;
    
}