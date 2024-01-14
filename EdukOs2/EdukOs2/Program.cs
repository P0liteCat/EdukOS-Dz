//SRP los primjer



using System;

public class Radnik
{
    public string InformacijeORadniku()
    {
        //Implementacija 
    }

    public decimal ObračunPlate(decimal sati, decimal satnica)
    {
        //Implementacija
    }
}
//Klasa radnik ima dvije odvojene odgovornosti, obračunavanje plaće i pružanje informacija o radniku. Potrebno je odvojiti metode u dvije klase

//SRP ispravak

public class RadnikInformacije
{
    public string InformacijeORadniku()
    {
        
    }
}

public class Plate
{
    public decimal ObračunPlate(decimal sati, decimal satnica)
    {
       
    }
}





//OCP los primjer
public class Customer
{
    public string Type { get; set; }

    public decimal CalculateDiscount(decimal totalAmount)
    {
        decimal discount = 0;

        if (Type == "Regular")
        {
            discount = totalAmount * 0.1m;  
        }
        else if (Type == "VIP")
        {
            discount = totalAmount * 0.2m;  
        }

        return discount;
    }
}

//Klasa krši OCP zato što ne možemo dodati novi tip kupca bez izmjenjivanja postojeće klase.

//OCP ispravak

public abstract class Customer
{
    public abstract decimal CalculateDiscount(decimal totalAmount);
}

public class RegularCustomer : Customer
{
    public override decimal CalculateDiscount(decimal totalAmount)
    {
        return totalAmount * 0.1m;  
    }
}

public class VIPCustomer : Customer
{
    public override decimal CalculateDiscount(decimal totalAmount)
    {
        return totalAmount * 0.2m;  
    }
}




//LSP los primjer
public class Car
{
    public void accelerate() { }
    public void shiftUp() { }
}

public class ElectricCar : Car
{
    public void accelerate() { }

    public void shiftUp()
    {
        throw new Exception("")
    }
}

//LSP se krši zato što klasa ElectricCar nije kompatibilna sa Metodom koju nasljeđuje od klase Car


//LSP ispravak
public interface IDrivable
{
    public void accelerate() { };

}


public class CombustionCar : IDrivable
{
    public void accelerate() { }
    public void shiftUp() { }
}

public class ElectricCar : IDrivable
{
    public void accelerate() { }
}


///////////////////////////////////////////////////////////

//ISP los primjer
public interface IWorker
{
    void Work();
    void Sleep();
}

public class Manager : IWorker
{
    public void Work(){ }
     
    public void Sleep(){ }
}

public class Robot : IWorker
{
    public void Work() { }
   
    public void Sleep(){
       
         }
}

//Krši se ISP zato što sučelje IWorker uvjetuje klase koje ga implementiraju da imaju implementacije metoda Eat i Sleep iako te metode nisu smislene za određene klase


//ISP ispravak

public interface IWorkable
{
    void Work();
}


public interface ISleepable
{
    void Sleep();
}

public class Manager : IWorkable, ISleepable
{
    public void Work()
    {
    }
    public void Sleep()
    {
      
    }
}

public class Robot : IWorkable
{
    public void Work()
    {    
    }
}


///////////////////////////////////////////////////////////////

//DIP los primjer

public class Car
{
    public string Brand { get; set; }
}

public class Dealership
{
     private List<Car> Cars;

    public Dealership()
    {
        public List<Car> Cars = new List<Car>();
}



//Krši se DIP jer se stvorila čvrsta ovisnost o klasi Car. Potrebno je uvesti abstrakciju


//DIP ispravak

public interface IVehicle
{
    string Brand { get; set; }
}

public class Car : IVehicle
{
    public string Brand { get; set; }
}

public class Motorcycle : IVehicle
{
    public string Brand { get; set; }
}

public class Dealership
{
    private List<Car> Cars;

    public Dealership()
    {
        public List<IVehicle> Cars = new List<Car>();
}