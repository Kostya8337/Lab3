using System;

namespace Models
{
    class PublishingEdition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }

        public void DisplayInfo(string name, string type, double price)
        {
            Console.WriteLine($"Name: {name}, Type: {type}, Price: {price:F2}");
        }

        public void DisplayInfo(string name, string type, double price, int pages)
        {
            Console.WriteLine($"Name: {name}, Type: {type}, Price: {price:F2}, Pages: {pages}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PublishingEdition book = new PublishingEdition();
            book.DisplayInfo("War and Peace", "Book", 350.00);
            book.DisplayInfo("War and Peace", "Book", 350.00, 1225);
        }
    }
}
