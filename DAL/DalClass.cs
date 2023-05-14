using BusinessObject.Models;
using DAL.Context;
using System.Collections;

namespace DAL
{
    public class DalClass
    {
        DBContext db = new DBContext();

        public int AddInventory(Inventory inventory, int suppId)
        {



            //To find supplier id



            Supplier obj = db.suppliers.Where(x => x.SupplierId == suppId).FirstOrDefault();
            if (obj != null)
            {

                inventory.supplier = obj;
            }
            else
            {
                Console.WriteLine("No supplier exists with this Id.");


            }

            db.inventories.Add(inventory);
            db.SaveChanges();
            Console.WriteLine("Record added");
            return 0;

        }

        public int AddSupplier(Supplier supplier)
        {

            // insert record


            db.suppliers.Add(supplier);
            db.SaveChanges();
            Console.WriteLine("Record added");
            return 0;
        }

        public int DeleteInventory(int id)
        {


            Inventory record = db.inventories.Where(x =>
            x.Id == id).FirstOrDefault();
            if (record != null)
            {
                db.inventories.Remove(record);
                db.SaveChanges();
                Console.WriteLine("Record deleted!");
            }
            else
                Console.WriteLine("There is no record");

            return 0;
        }

        public int DeleteSupplier(int id)
        {
            // Delete Record


            Supplier record = db.suppliers.Where(x =>
            x.SupplierId == id).FirstOrDefault();
            if (record != null)
            {
                db.suppliers.Remove(record);
                db.SaveChanges();
                Console.WriteLine("Record deleted!");
            }
            else
                Console.WriteLine("There is no record");

            return 0;
        }

        public int EditInventory(int id, Inventory inventory, int suppId)
        {

            Supplier newSupplier = db.suppliers.Find(suppId);

            //for updating 
            Inventory obj = db.inventories.Where(x => x.Id == id)
                      .FirstOrDefault();
            if (obj!=null)
            {
                foreach (Inventory temp in db.inventories)
                {
                    if (temp.Id == obj.Id)
                    {
                        temp.Pd_Name = inventory.Pd_Name;
                        temp.Pd_Details = inventory.Pd_Details;
                        temp.QtyInStock = inventory.QtyInStock;
                        temp.LastUpdated = inventory.LastUpdated;
                        temp.supplier = newSupplier;
                        temp.supplier.SupplierId = suppId;
                    }


                }

                Console.WriteLine("Record updated!");
                db.SaveChanges();
            }

            else
                Console.WriteLine("There is no record");

            return 0;
        }

        public int EditSupplier(int id, Supplier supplier)
        {


            Supplier obj = db.suppliers.Where(x => x.SupplierId == id).FirstOrDefault();

            if (obj!=null)
            {
                foreach (Supplier temp in db.suppliers)
                {
                    if (temp.SupplierId == obj.SupplierId)
                    {

                        temp.SupplierName = supplier.SupplierName;
                        temp.Address = supplier.Address;
                        temp.ContactNo = supplier.ContactNo;
                        temp.Email = supplier.Email;
                        temp.cityOperation = supplier.cityOperation;
                    }


                }
                Console.WriteLine("Record updated!");
                db.SaveChanges();
            }
            else
                Console.WriteLine("There is no record");

            return 0;
        }

        public List<Supplier> GetSuppliers()
        {
            // List of Records
            List<Supplier> list = db.suppliers.ToList();
            return list;
        }

        public ArrayList GetInventories()
        {
            // List of Records
            ArrayList list = new ArrayList();


            var query = from Supplier in db.suppliers
                        join Inventory in db.inventories
                        on Supplier.SupplierId equals Inventory.supplier.SupplierId
                        select new
                        {
                            InventoryId = Inventory.Id,
                            InventoryDetails = Inventory.Pd_Details,
                            InventoryLastUpdated = Inventory.LastUpdated,
                            SupplierId = Inventory.supplier.SupplierId,
                            InventoryName = Inventory.Pd_Name,
                            Quantity = Inventory.QtyInStock,
                            SupplierName = Supplier.SupplierName,
                            city = Supplier.cityOperation

                        };
            foreach (var order in query)
            {
                list.Add(order);
            }

            return list;


        }
    }
}