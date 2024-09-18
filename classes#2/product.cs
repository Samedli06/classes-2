using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Product
    {
        public ArrayList productDetails;

        public Product(string id, string brand, string model, double price, int quantaty)
        {
            productDetails = new ArrayList { id, brand, model, price, quantaty };

        }

        public void ShowProduct()
        {
            Console.WriteLine($"ID:{productDetails[0]}");
            Console.WriteLine($"Brand:{productDetails[1]}");
            Console.WriteLine($"Model:{productDetails[2]}");
            Console.WriteLine($"Price:{productDetails[3]}");
            Console.WriteLine($"Quantaty:{productDetails[4]}");
            Console.WriteLine("============");

        }

        public string GetModel()
        {
            return productDetails[2].ToString();
        }

        public int GetQuantity()
        {
            return Convert.ToInt32(productDetails[4]);
        }

        public void SetQuantity(int newQuantity)
        {
            productDetails[4] = newQuantity;
        }

        public double GetPrice()
        {
            return Convert.ToDouble(productDetails[3]);
        }
    }


    public class Add
    {
        public ArrayList computers;
        public ArrayList phones;
        public double balance = 10000;

        public Add()
        {
            computers = new ArrayList
            {
                new Product ("1", "Acer", "Nitro5", 1000, 12),
                new Product("2", "Asus", "Zephyrus", 1700, 8),
                new Product("3", "Macbook", "Pro14", 2000, 20),
                new Product("4", "Lenovo", "Legion5", 1200, 5)
            };

            phones = new ArrayList
            {
                new Product("1", "iPhone", "Pro15", 1000, 30),
                new Product("2", "Samsung", "S23", 800, 15),
                new Product("3", "Xiaomi", "Note8", 400, 50),
                new Product("4", "Oppo", "X8", 600, 20)
            };
        }


        public void ShowAllProduct()
        {
            Console.Clear();
            Console.WriteLine("computers:");
            foreach (Product computer in computers)
            {
                computer.ShowProduct();
            }
            Console.WriteLine("phones:");
            foreach (Product phone in phones)
            {
                phone.ShowProduct();
            }
            Console.ReadKey();
        }

        public void AddProduct()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Computer\n2. Phone");
                string choice = Console.ReadLine();

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
                }

                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                double price;
                while (true)
                {
                    Console.Write("Enter Price: ");
                    if (double.TryParse(Console.ReadLine(), out price) && price>0)
                        break;
                    else
                        Console.WriteLine("Invalid input for price. Please enter a valid number.");
                }

                int quantity;
                while (true)
                {
                    Console.Write("Enter Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity>0)
                        break;
                    else
                        Console.WriteLine("Invalid input for quantity. Please enter a valid number.");
                }

                Product newproduct = new Product(id, brand, model, price, quantity);

                if (choice == "1")
                {
                    computers.Add(newproduct);
                }
                else if (choice == "2")
                {
                    phones.Add(newproduct);
                }

                Console.WriteLine("Product added successfully.");
                Console.ReadKey();
                break;
            }
        }


        public void SellProduct()
        {
        menu:
            Console.Clear();
            Console.WriteLine("select what you what to sell\n1.computer\n2.phone");
            string choice = Console.ReadLine();

            ArrayList SelectedCatogory = null;

            if (choice == "1")
            {
                SelectedCatogory = computers;
            }

            else if (choice == "2")
            {
                SelectedCatogory = phones;
            }

            else
            {
                Console.WriteLine("invalid category");
                Console.ReadKey();
                goto menu;
            }

            Console.Write("enter the model:");
            string modelSell = Console.ReadLine();

            Product productSell = null;

            foreach (Product product in SelectedCatogory)
            {
                if (product.GetModel().Equals(modelSell, StringComparison.OrdinalIgnoreCase))
                {
                    productSell = product;
                    break;
                }
            }
            if (productSell != null)
            {
                Console.Write($"Enter the quantity to sell (Available: {productSell.GetQuantity()}): ");
                int quantatySell = int.Parse(Console.ReadLine());

                if (quantatySell <= productSell.GetQuantity() && quantatySell>0 )
                {
                    productSell.SetQuantity(productSell.GetQuantity() - quantatySell);
                    Console.WriteLine("sold successfullly");
                }

                else
                {
                    Console.WriteLine("insufficient stock");
                }
            }


            else
            {
                Console.WriteLine("product not found");
            }

            Console.ReadKey();
        }

        public void totalPriceForComputers()
        {
            double totalPrice = 0;

            for (int i = 0; i < computers.Count; i++)
            {
                Product product = (Product)computers[i];
                totalPrice += product.GetPrice() * product.GetQuantity();
            }
            Console.WriteLine("Total Price: " + totalPrice);
        }

        public double totalPriceForComputerss()
        {
            double totalPrice = 0;

            for (int i = 0; i < computers.Count; i++)
            {
                Product product = (Product)computers[i];
                totalPrice += product.GetPrice() * product.GetQuantity();
            }
            return totalPrice;
        }

        public void totalPriceForPhones()
        {
            double totalPrice = 0;

            for (int i = 0; i < phones.Count; i++)
            {
                Product product = (Product)phones[i];
                totalPrice += product.GetPrice() * product.GetQuantity();
            }
            Console.WriteLine("Total Price: " + totalPrice);
        }

        public double totalPriceForPhoness()
        {
            double totalPrice = 0;

            for (int i = 0; i < phones.Count; i++)
            {
                Product product = (Product)phones[i];
                totalPrice += product.GetPrice() * product.GetQuantity();
            }
            return (double)totalPrice;
        }

        public void AllProductsTotalPrice()
        {
            double allPrice;

            allPrice = totalPriceForComputerss() + totalPriceForPhoness();

            Console.WriteLine("All products total price:" + allPrice);
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Show all products\n2. Show computers\n3. Show phones\n4. Add product\n5. Sell product\n6.Show total price of all products\n7.Show total price of products by category\n8.Quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllProduct();
                        break;
                    case "2":
                        foreach (Product computer in computers) computer.ShowProduct();
                        Console.ReadKey();
                        break;
                    case "3":
                        foreach (Product phone in phones) phone.ShowProduct();
                        Console.ReadKey();
                        break;
                    case "4":
                        AddProduct();
                        break;
                    case "5":
                        SellProduct();
                        break;
                    case "6":
                        AllProductsTotalPrice();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("1.computers\n2.phones");
                        Console.Write("chooose category:");
                        string categoryChoice = Console.ReadLine();
                        if (categoryChoice == "1")
                        {
                            totalPriceForComputers();
                        }
                        else if (categoryChoice == "2")
                        {
                            totalPriceForPhones();
                        }
                        else
                        {
                            Console.WriteLine("choose correct category");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        Console.ReadKey();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
