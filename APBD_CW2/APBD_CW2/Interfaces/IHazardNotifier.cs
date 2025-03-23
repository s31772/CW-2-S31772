namespace APBD_CW2;

public interface IHazardNotifier
{
        public void Notify(SerialNumber serialNumber){
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("RISKY OPERATION HAS BEEN PERFORMED FOR: "+ serialNumber.SerialNumberIdentifier);
            Console.ResetColor();
        }
}