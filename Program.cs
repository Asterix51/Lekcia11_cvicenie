namespace Lekcia11_cvicenie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Catalog catalog = new Catalog();

                catalog.AddProduct(new Product("Notebook: ASUS ROG Strix G18 G814JIR-N6003W Eclipse", 2459m, 15));
                catalog.AddProduct(new Product("Sluchadlá: HyperX Cloud III Red", 62.90m, 25));
                catalog.AddProduct(new Product("Myš: Logitech MX Vertical", 79.90m, 8));
                catalog.AddProduct(new Product("Procesor: AMD Ryzen 7 9800X3D", 592.90m, 40));
                catalog.AddProduct(new Product("SSD: Kingston FURY Renegade NVMe 2TB", 142.90m, 18));
                catalog.AddProduct(new Product("SSD: Samsung 990 PRO 2 TB Heatsink", 169.90m, 21));
                catalog.AddProduct(new Product("Chladič CPU: ARCTIC Freezer 34 eSports DUO Red", 58.60m, 2));

                var serializeProducts = catalog.SerializeProducts();
                Console.WriteLine("Serializované produkty");
                foreach (var json in serializeProducts)
                {
                    Console.WriteLine(json);
                }

                var manualJson = "{\"Name\":\"Playstation\",\"Price\":799.9,\"Quantity\":15}";
                catalog.DeserializeProducts(new List<string> { manualJson });

                Console.WriteLine("\nZoznam produktov po deserializacií:");
                catalog.PrintAllProducts();
            }

            catch (InvalidProductException e)
            {
                Console.WriteLine($"Chyba: {e.Message} (Product: {e.ProductName}, Cena: {e.Price}€)");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Neočakávaná chyba: {e.Message}");
            }
        }
    }
}
