namespace Lekcia11_cvicenie
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            if (price < 0)
            {
                throw new InvalidProductException("Cena produktu nemôže byť záporná.", name, price);
            }

            Name = name;
            Price = price;
            Quantity = quantity;

        }
    }
}
