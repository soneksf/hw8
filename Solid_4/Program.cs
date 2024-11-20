using System;

namespace ProductExample
{
    // Interface for items that have a price
    interface IPriceable
    {
        void SetPrice(double price);
    }

    // Interface for items that can have discounts applied
    interface IDiscountable
    {
        void ApplyDiscount(string discount);
        void ApplyPromocode(string promocode);
    }

    // Interface for items that have a color
    interface IColorable
    {
        void SetColor(byte color);
    }

    // Interface for items that have a size
    interface ISizedItem
    {
        void SetSize(byte size);
    }

    // Book class implementing relevant interfaces
    class Book : IPriceable, IDiscountable
    {
        private double _price;
        private double _discountedPrice;

        public void SetPrice(double price)
        {
            _price = price;
            Console.WriteLine($"Book price set to {_price}");
        }

        public void ApplyDiscount(string discount)
        {
            // Implement discount logic here
            // For simplicity, let's assume discount is a percentage in string form
            if (double.TryParse(discount.TrimEnd('%'), out double discountPercentage))
            {
                _discountedPrice = _price - (_price * (discountPercentage / 100));
                Console.WriteLine($"Book discounted price after {discount}% discount is {_discountedPrice}");
            }
            else
            {
                Console.WriteLine("Invalid discount format");
            }
        }

        public void ApplyPromocode(string promocode)
        {
            // Implement promo code logic here
            // For simplicity, let's assume a fixed amount is deducted
            if (promocode == "SAVE10")
            {
                _discountedPrice = _price - 10;
                Console.WriteLine($"Book price after applying promo code '{promocode}' is {_discountedPrice}");
            }
            else
            {
                Console.WriteLine("Invalid promo code");
            }
        }
    }

    // Outerwear class implementing relevant interfaces
    class Outerwear : IPriceable, IDiscountable, IColorable, ISizedItem
    {
        private double _price;
        private double _discountedPrice;
        private byte _color;
        private byte _size;

        public void SetPrice(double price)
        {
            _price = price;
            Console.WriteLine($"Outerwear price set to {_price}");
        }

        public void ApplyDiscount(string discount)
        {
            // Implement discount logic here
            if (double.TryParse(discount.TrimEnd('%'), out double discountPercentage))
            {
                _discountedPrice = _price - (_price * (discountPercentage / 100));
                Console.WriteLine($"Outerwear discounted price after {discount}% discount is {_discountedPrice}");
            }
            else
            {
                Console.WriteLine("Invalid discount format");
            }
        }

        public void ApplyPromocode(string promocode)
        {
            // Implement promo code logic here
            if (promocode == "SAVE20")
            {
                _discountedPrice = _price - 20;
                Console.WriteLine($"Outerwear price after applying promo code '{promocode}' is {_discountedPrice}");
            }
            else
            {
                Console.WriteLine("Invalid promo code");
            }
        }

        public void SetColor(byte color)
        {
            _color = color;
            Console.WriteLine($"Outerwear color set to {_color}");
        }

        public void SetSize(byte size)
        {
            _size = size;
            Console.WriteLine($"Outerwear size set to {_size}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Working with Book
            Book myBook = new Book();
            myBook.SetPrice(50);
            myBook.ApplyDiscount("10%");
            myBook.ApplyPromocode("SAVE10");

            Console.WriteLine();

            // Working with Outerwear
            Outerwear myJacket = new Outerwear();
            myJacket.SetPrice(150);
            myJacket.SetColor(5); // Assuming 5 represents a color code
            myJacket.SetSize(42);
            myJacket.ApplyDiscount("15%");
            myJacket.ApplyPromocode("SAVE20");

            Console.ReadKey();
        }
    }
}
