namespace APBD_CW2;

public abstract class Container
{
    public double LoadMass { get; protected set; } = 0;
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Depth { get; private set; }
    public SerialNumber serialNumber { get; }
    public double MaxLoad { get; private set; }
    public static Dictionary<string, Container> AllContainers= new Dictionary<string, Container>();
    public bool IsOnTheShip { get;  set; }

    public Container(double height, double weight, double depth, SerialNumber serialNumber, double maxLoad)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        this.serialNumber = serialNumber;
        MaxLoad = maxLoad;
        IsOnTheShip = false;
        AllContainers.Add(this.serialNumber.SerialNumberIdentifier,this);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("NEW CONTAINER HAS BEEN CREATED");
        Console.ResetColor();
    }


    
    public virtual void UnLoad()
    {
        this.LoadMass = 0;
    }

    public virtual void Load(double loadMass, string kindOfLoad ,bool isDangerous, double temperature)
    {
        if (loadMass > MaxLoad)
        {
            throw new OverfillException("MAX LOAD FOR CONTAINER [" + serialNumber.SerialNumberIdentifier + "] IS " +
                                        MaxLoad + " KILOGRAMS");
        }
        else
        {
            LoadMass = loadMass;
        }
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- SerialNumber:{serialNumber.SerialNumberIdentifier}, Properties -- Height:  {Height} Weight:  {Weight} Depth:  {Depth} Max_Load:  {MaxLoad} Load_Mass: {LoadMass}" ;
    }
}