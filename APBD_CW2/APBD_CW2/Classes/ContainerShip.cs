namespace APBD_CW2;

public class ContainerShip(string name,int maxSpeed, double maxWeightOfLoading, int maxContainersAmount)
{
    public List<Container> containers  {get; set;} = new List<Container>();
    public string name { get; private set; } = name;

    public void DeleteContainer(Container container)
    {
        containers.Remove(container);
        container.IsOnTheShip = false;
    }

    public void AddContainer(Container container)
    {
        if (!container.IsOnTheShip)
        {
            if (containers.Count < maxContainersAmount)
            {
                var sumWeight = containers.Sum(container => container.Weight);
                sumWeight += container.Weight;
                if (sumWeight <= maxWeightOfLoading*1000)
                {
                    containers.Add(container);
                    container.IsOnTheShip = true;
                }
                else
                {
                    Console.WriteLine("MAX WEIGHT OF LOADING FOR SHIP " + name+ " IS "+ maxWeightOfLoading +" TONS");
                }
            }
            else
            {
                Console.WriteLine("MAX CONTAINERS AMOUNT FOR SHIP " + name+ " IS "+ maxContainersAmount);
            }
    }
        else
        {
            Console.WriteLine("CONTAINER "+ container.serialNumber.SerialNumberIdentifier + " IS ALREADY ON THE SHIP");
        }
    }

    public void AddContainers(List<Container> newContainers)
    {
        foreach (var container in newContainers)
        {
            AddContainer(container);
        }
    }


    public void ReplaceContainers(Container newContainer, Container containerToReplace)
    {
       DeleteContainer(containerToReplace);
        AddContainer(newContainer);
    }
    
    public void SwapContainers(ContainerShip otherShip, Container containerOfThisShip, Container containerOfOtherShip)
    {
        if (containers.Contains(containerOfThisShip) && otherShip.containers.Contains(containerOfOtherShip))
        {
            DeleteContainer(containerOfThisShip);
            otherShip.DeleteContainer(containerOfOtherShip);
            
            AddContainer(containerOfOtherShip);
            otherShip.AddContainer(containerOfThisShip);
        }
        else
        {
            Console.WriteLine("FAILED TO SWAP CONTAINERS");
        }
    }

    public void SwapContainers(ContainerShip otherShip, string serialNumberOfContainerOnThisShip,
        string serialNumberOfTheContainerOnOtherShip)
    {

        if (containers.Contains(Container.AllContainers[serialNumberOfContainerOnThisShip]) &&
            otherShip.containers.Contains(Container.AllContainers[serialNumberOfTheContainerOnOtherShip]))
        {
            DeleteContainer(Container.AllContainers[serialNumberOfContainerOnThisShip]);
            otherShip.DeleteContainer(Container.AllContainers[serialNumberOfTheContainerOnOtherShip]);
            
            AddContainer(Container.AllContainers[serialNumberOfTheContainerOnOtherShip]);
            otherShip.AddContainer(Container.AllContainers[serialNumberOfContainerOnThisShip]);
        }
        else
        {
            Console.WriteLine("FAILED TO SWAP CONTAINERS");
        
        }
    }



    public override string ToString()
    {
        string containersInfo = string.Join("\n", containers.Select(c => c.ToString()));
        return $"LOADING FOR SHIP {name} IS:\n{containersInfo}";
    }

}