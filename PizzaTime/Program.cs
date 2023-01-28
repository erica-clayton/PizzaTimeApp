
using Newtonsoft.Json;
using PizzaTime;

var allPizzas = JsonConvert.DeserializeObject<List<PizzaToppings>>(File.ReadAllText(@"C:\Users\erica\E20\PizzaTimeApp\PizzaTime\Assests\pizzas.json"));

Dictionary<string, int> pizzaCounter = new();

foreach (PizzaToppings pizza in allPizzas)
{
    var toppingsAsString = String.Join(",", pizza.Toppings);
    if(pizzaCounter.ContainsKey(toppingsAsString))
    {
        pizzaCounter[toppingsAsString] += 1;
    }
    else
    {
        pizzaCounter[toppingsAsString] = 1;
    }
}

var mostCOmmonPizza = pizzaCounter.OrderByDescending(p => p.Value).Take(20);

foreach (var common in mostCOmmonPizza)
{
    Console.WriteLine($"The topping(s) {common.Key} is seen {common.Value} times");
}