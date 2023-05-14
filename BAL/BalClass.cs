using DAL;
using BusinessObject.Models;
using System.Collections;

namespace BAL
{
    public class BalClass
    {
        DalClass dal = new DalClass();

        public int AddSupplier(Supplier supplier)
        {
            dal.AddSupplier(supplier);
            return 0;
        }

        public int AddInventory(Inventory inventory, int suppId)
        {
            dal.AddInventory(inventory, suppId);
            return 0;
        }

        public int DeleteSupplier(int id)
        {
            dal.DeleteSupplier(id);
            return 0;
        }

        public int DeleteInventory(int id)
        {
            dal.DeleteInventory(id);
            return 0;
        }

        public int EditInventory(int id, Inventory inventory, int suppId)
        {
            dal.EditInventory(id, inventory, suppId);
            return 0;
        }

        public int EditSupplier(int id, Supplier supplier)
        {
            dal.EditSupplier(id, supplier);
            return 0;
        }

        public List<Supplier> GetSuppliers()
        {
            return dal.GetSuppliers();
        }

        public ArrayList GetInventories()
        {
            return dal.GetInventories();
        }
    }
}