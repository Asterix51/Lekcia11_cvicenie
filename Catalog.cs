using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lekcia11_cvicenie

{
    internal class Catalog
    {
        private List<Product> _products;

        public Catalog() 
        { 
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
                _products.Add(product);
        }

        public List<string> SerializeProducts()
        {
            return _products.Select(product => JsonSerializer.Serialize(product)).ToList();
        }

        public void DeserializeProducts(List<string> jsonProducts)
        {
            foreach (var json in jsonProducts)
            {
                try
                {
                    var product = JsonSerializer.Deserialize<Product>(json);
                    if (product != null)
                    {
                        _products.Add(product);
                    }
                }
                catch (JsonException e)
                {
                    Console.WriteLine($"Chyba pri deserializaci: {e.Message}");
                }

                catch (InvalidProductException e)
                {
                    Console.WriteLine($"Neplatný product: {e.Message}");
                }
            }
        }

        public void PrintAllProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"Názov: {product.Name}, Cena: {product.Price}€, Množstvo: {product.Quantity}ks");
            }
        }
    }
}
