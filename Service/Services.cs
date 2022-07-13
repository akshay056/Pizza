using Pizza.Models;
namespace Pizza.Service
{
    public static class Services
    {
        static List<PizzaW> Pizzas { get; }
        static int nextId = 3;
        static Services()
        {
            Pizzas = new List<PizzaW>
                {
                    new PizzaW { Id = 1, Name = "Classic Italian", Price=20.00M, Size=PizzaSize. Large, IsGlutenFree = false },
                    new PizzaW { Id = 2, Name = "Veggie", Price=15.00M, Size=PizzaSize.Small,IsGlutenFree = true }
                };
        }

        public static List<PizzaW> GetAll() => Pizzas;

        public static PizzaW? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(PizzaW pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(PizzaW pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
