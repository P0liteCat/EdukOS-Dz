
namespace ApstraktnaTvornicaExtraPrimjer
{
    
    public interface IDisplay
    {
        public void UseInterface() { }
        public void SellDisplay() { }
    }

    public interface ITV
    {
        public void UseInterface() { }
        public void SellTV() { }
    }



    public class DellDisplay : IDisplay
    {
        public void UseInterface() { }
        public void SellDisplay() { }
    }

    public class SamsungDisplay : IDisplay
    {
        public void UseInterface() { }
        public void SellDisplay() { }
    }

    public class DellTV : ITV
    {
        public void UseInterface() { }
        public void SellTV() { }
    }

    public class SamsungTV : ITV
    {
        public void UseInterface() { }
        public void SellTV() { }
    }

    public abstract class Factory
    {
        public abstract IDisplay CreateDisplay();
        public abstract ITV CreateTV();
    }

    public class SamsungFactory: Factory
    {
        public override IDisplay CreateDisplay()
        {
            return new SamsungDisplay();
        }

        public override ITV CreateTV()
        {
            return new SamsungTV();
        }
    }


    public class DellFactory : Factory
    {
        public override IDisplay CreateDisplay()
        {
            return new DellDisplay();
        }

        public override ITV CreateTV()
        {
            return new DellTV();
        }


    }

    public class App
    {
        List<Factory> factories = new List<Factory>
        { new SamsungFactory(), new DellFactory()};

        public App()
        {
            foreach (Factory factory in factories)
            {
                factory.CreateDisplay();
                factory.CreateTV();
            }
        }


    }
    //SOLID načela
    //Klasa App koristi listu tvornica umjesto vise klasa proizvoda(SRP)
    //Omoguceno je proširenje ukoliko želimo dodati jos tipova uredjaja(OCP)
    //Konkretne klase Factory su medjusobno zamjenjive(LSP)
    //TV i Display su odvojeni u 2 sučelja(ISP)
    //Klase ovise o apstrakcijama tj DellDisplay, DellTV, SamsungDisplay i SamsungTV ovise o IDisplay i ITV(DIP)




}