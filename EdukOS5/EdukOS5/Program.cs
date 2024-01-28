

//Zadaca: Primjeni Dekorater na ovaj set klasa:
namespace DekoraterExtraZadatak
{
    public interface IIngredient
    {
        public void AddIngredient();
    }

    public class BaseIngredient : IIngredient
    {
        public void AddIngredient()
        {
            Console.WriteLine("Add Base Ingredient");
        }
    }

    public class NoIngredient : IIngredient
    {
        public void AddIngredient()
        {
            Console.WriteLine("No Ingredient");
        }
    }

    public class BaseIngredientDecorator : IIngredient
    {
        IIngredient ingredient;

        public BaseIngredientDecorator(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }

        public virtual void AddIngredient()
        {
            ingredient.AddIngredient();
        }
    }

    public class NoodlesDecorator:BaseIngredientDecorator
    {
        public NoodlesDecorator(IIngredient ingredient) : base(ingredient) { }
        public override void AddIngredient()
        {
            base.AddIngredient();
            Console.WriteLine("Add Noodles");
        }
    }

    public class BeefDecorator : BaseIngredientDecorator
    {
        public BeefDecorator(IIngredient ingredient) : base(ingredient) { }
        public override void AddIngredient()
        {
            base.AddIngredient();
            Console.WriteLine("Add Beef");
        }
    }

    public class MushroomsDecorator : BaseIngredientDecorator
    {
        public MushroomsDecorator(IIngredient ingredient) : base(ingredient) { }
        public override void AddIngredient()
        {
            base.AddIngredient();
            Console.WriteLine("Add Mushrooms");
        }
    }

    public class WaterDecorator : BaseIngredientDecorator
    {
        public WaterDecorator(IIngredient ingredient) : base(ingredient) { }
        public override void AddIngredient()
        {
            base.AddIngredient();
            Console.WriteLine("Add Water");
        }
    }

   


   

    public class Meal
    {
        IIngredient ingredient;
        public Meal()
        {
           
        }
        public void MakeMushroomNoodleSoup()
        {
            ingredient = new BaseIngredientDecorator(
                new WaterDecorator(
                    new MushroomsDecorator(
                        new NoodlesDecorator(
                            new NoIngredient()))));         
        }

        public void MakeBeefNoodleSoup()
        {
            ingredient = new BaseIngredientDecorator(
                new WaterDecorator(
                    new BeefDecorator(
                        new NoodlesDecorator(
                            new NoIngredient()))));
        }

        public void MakeMushroomBeefSoup()
        {
            ingredient = new BaseIngredientDecorator(
                new WaterDecorator(
                    new BeefDecorator(
                        new MushroomsDecorator(
                            new NoIngredient()))));
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            new Meal().MakeBeefNoodleSoup();
        }
    }
}