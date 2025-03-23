
using APBD_CW2;

Console.WriteLine("\n________________[L]_________________\n");
var containerL1 = new ContainerL(300.5, 150.0, 30.0, new SerialNumber("L"), 1500.5);
Console.WriteLine(containerL1.ToString());

var containerL2 = new ContainerL(300.5, 150.0, 30.0, new SerialNumber("L"), 1500.5);
Console.WriteLine(containerL2.ToString());

try
{
    containerL1.Load(1600.0, "Fuel", true, 10);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}

try
{
    containerL2.Load(1200.0,"Milk",  true, 20);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(containerL1.ToString());
Console.WriteLine(containerL2.ToString());
containerL2.UnLoad();
Console.WriteLine(containerL2.ToString());

Console.WriteLine("\n_______________[G]__________________\n");

var containerG3 = new ContainerG(300.5, 150.0, 50.0, new SerialNumber("G"), 2000.5, 200);
Console.WriteLine(containerG3.ToString());
try
{
    containerG3.Load(1900.0, "Hydrogen", true, 20);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(containerG3.ToString());
containerG3.UnLoad();
Console.WriteLine(containerG3.ToString());

Console.WriteLine("\n_______________[C]_________________\n");
var containerC4 = new ContainerC(300.5, 150.0, 30.0, new SerialNumber("C"), 1500.5, 18);
Console.WriteLine(containerC4.ToString());

try
{
    containerC4.Load(540.0, "Bananas", false, 13.3);
    containerC4.Load(300.0, "Chocolate", false, 18);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine(containerC4.ToString());
containerC4.UnLoad();
Console.WriteLine(containerC4.ToString());
try
{
    containerC4.Load(200.0, "Chocolate", false, 18);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine(containerC4.ToString());

Console.WriteLine("\n\n\n\n\n________________[ADDING_ONE]___________________\n");
var containerShip = new ContainerShip("ShipShip",300,5.5,200);
Console.WriteLine(containerShip.ToString());
containerShip.AddContainer(containerL2);
containerShip.AddContainer(containerG3);
containerShip.AddContainer(containerC4);
Console.WriteLine(containerShip.ToString());
Console.WriteLine("\n_________________[REPLACING_CON]__________________");
containerShip.ReplaceContainers(containerL1, containerC4);
Console.WriteLine(containerShip.ToString());
Console.WriteLine("\n_________________[DELETING]__________________");
containerShip.DeleteContainer(containerG3);
Console.WriteLine(containerShip.ToString());
Console.WriteLine("\n_________________[ADDING_LIST]__________________");
List<Container> containerLs = new List<Container>();
containerLs.Add(containerG3);
containerShip.AddContainers(containerLs);
Console.WriteLine(containerShip.ToString());
Console.WriteLine("\n\n____________________[SWAPPING]_______________________");
containerShip.DeleteContainer(containerL1);
Console.WriteLine(containerShip.ToString());
Console.WriteLine("___________________________________");
var containerShip2 = new ContainerShip("Ship222Ship",222,22.2,222);
containerShip2.AddContainer(containerL1);
containerShip2.AddContainer(containerC4);
Console.WriteLine(containerShip2.ToString());
containerShip2.SwapContainers(containerShip, containerC4,containerL2);
Console.WriteLine("___________________________________");
Console.WriteLine(containerShip.ToString());
Console.WriteLine("___________________________________");
Console.WriteLine(containerShip2.ToString());
Console.WriteLine("\n\n____________________[SWAPPING]_______________________");
containerShip.SwapContainers(containerShip2,"KON-G-3","KON-L-1");
Console.WriteLine(containerShip.ToString());
Console.WriteLine("___________________________________");
Console.WriteLine(containerShip2.ToString());

