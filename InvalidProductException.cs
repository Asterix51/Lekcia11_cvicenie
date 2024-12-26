namespace Lekcia11_cvicenie
{
    internal class InvalidProductException : Exception
    {
        public string ProductName { get; }
        public decimal Price { get; }
        public InvalidProductException(string massage, string productName, decimal price) : base(massage)
        {
            ProductName = productName;
            Price = price;
        }
    }
}
