using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.Interface
{
    public interface IProductInformationService
    {
        List<ProductInformation> GetAll();

        ProductInformation GetById(int id);

        void Add(ProductInformation entity);

        void Update(ProductInformation entity);

        void Delete(int id);

        ProductInformation? FindByField(string fieldName, object value);
    }
}
