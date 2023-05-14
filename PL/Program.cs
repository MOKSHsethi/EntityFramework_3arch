using BusinessObject.Models;
using BAL;
using System.Collections;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            char ch = 'y';
            int type;

            while (ch == 'y')
            {

                Console.WriteLine("  Menu");
                Console.WriteLine("  1.Add record");
                Console.WriteLine("  2.Delete record");
                Console.WriteLine("  3.Edit record");
                Console.WriteLine("  4.Display all records");
                option = Convert.ToInt32(Console.ReadLine());
                BalClass bal = new BalClass();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("  1.Supplier");
                        Console.WriteLine("  2.Inventory");

                        type = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            Supplier supplier = new Supplier()
                            { SupplierName = "anjali", Address = "fvhj", ContactNo = "57868", Email="abc@gmail.com", CityOperatesIn="paris" };


                            bal.AddSupplier(supplier);
                        }
                        else
                        {

                            Inventory inventory = new Inventory()
                            { Pd_Name = "Rahul", Pd_Details = "xyz", QtyInStock = 5, LastUpdated=Convert.ToDateTime("20/04/2023") };
                            Console.WriteLine("Enter supplier id:");
                            int suppId = Convert.ToInt32(Console.ReadLine());
                            bal.AddInventory(inventory, suppId);

                        }
                        break;
                    case 2:
                        Console.WriteLine("  1.Supplier");
                        Console.WriteLine("  2.Inventory");

                        type = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            Console.WriteLine("Enter supplier id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            bal.DeleteSupplier(id);
                        }
                        else
                        {
                            Console.WriteLine("Enter Inventory id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            bal.DeleteInventory(id);
                        }

                        break;

                    case 3:
                        Console.WriteLine("  1.Supplier");
                        Console.WriteLine("  2.Inventory");

                        type = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            Console.WriteLine("Enter the supplier id you want to update for:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Supplier supplier = new Supplier()
                            { SupplierName = "Rahul", Address = "kiran vihar", ContactNo = "5787868", Email="xyz@gmail.com", CityOperatesIn="london" };

                            bal.EditSupplier(id, supplier);
                        }


                        else
                        {
                            Console.WriteLine("Enter the inventory id:");
                            int invId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the updated supplier id:");
                            int suppId = Convert.ToInt32(Console.ReadLine());

                            Inventory inventory = new Inventory()
                            { Pd_Name = "soap", Pd_Details = "hakuna matata", QtyInStock = 50, LastUpdated=Convert.ToDateTime("10/05/2023") };

                            bal.EditInventory(invId, inventory, suppId);
                        }

                        break;

                    case 4:
                        Console.WriteLine("  1.Supplier");
                        Console.WriteLine("  2.Inventory");

                        type = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            List<Supplier> list = bal.GetSuppliers();
                            foreach (Supplier supp in list)
                            {
                                Console.WriteLine($"{supp.SupplierName} -- {supp.Address} -- {supp.ContactNo} -- {supp.Email} -- {supp.CityOperatesIn}");
                            }

                        }


                        else
                        {
                            ArrayList list = bal.GetInventories();
                            foreach (var inv in list)
                            {
                                Console.WriteLine(inv);
                            }
                        }
                        break;
                    default: Console.WriteLine("Enter a valid number"); break;
                }
                Console.WriteLine("Do you want to repeat?");
                ch = Convert.ToChar(Console.ReadLine());

            }
        }
    }
}