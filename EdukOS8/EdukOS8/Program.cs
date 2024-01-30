using System.Xml.Schema;

//Zadaca: Dovrsi ovaj primjer Mementa
namespace MementoZadatak
{
    public class Equipment
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Equipment(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class CarConfigurator//memento
    {
        public string Model { get; private set; }
        private List<Equipment> additionalEquipment = new List<Equipment>();
        public void AddExtra(Equipment package) { additionalEquipment.Add(package); }
        public void Remove(Equipment package) { additionalEquipment.Remove(package); }
        public void Rollback(CarConfiguration configuration)
        {
            Model = configuration.GetModel();
            additionalEquipment.Clear();
            additionalEquipment.AddRange(configuration.GetPackages());
        }
        public CarConfiguration Store() { return new CarConfiguration(Model, additionalEquipment); }
    }

    public class CarConfiguration//origniator
    {
        private string model;
        private List<Equipment> additionalEquipment;

        public CarConfiguration(string model, List<Equipment> additionalEquipment)
        {
            this.model = model;
            this.additionalEquipment = additionalEquipment;
        }

        public string GetModel()
        {
            return model;
        }

        public List<Equipment> GetPackages() 
        {
            return additionalEquipment;
        }

    }

    public class ConfigurationManger//skrbnik
    {
        private List<CarConfiguration> configurations = new List<CarConfiguration>();
        public void AddConfiguration(CarConfiguration configuration) { configurations.Add(configuration); }
        public void DeleteConfiguration(CarConfiguration configuration) { configurations.Remove(configuration); }
        public CarConfiguration GetConfiguration(int index) { return configurations[index]; }
    }
}

