using Microsoft.EntityFrameworkCore;
using Product_Inventory_Management_System.Data;
using Product_Inventory_Management_System.Interface;
using Product_Inventory_Management_System.Models;
using System.Xml.Linq;

namespace Product_Inventory_Management_System.Service
{
    public class ProductInformationServices : IProductInformationService
    {
        private readonly ApplicationDbContext context;

        public ProductInformationServices(ApplicationDbContext context)
        { 
            this.context = context;
        }

        public List<ProductInformation> GetAll()
        {
            return this.context.Set<ProductInformation>().ToList();
        }

        public ProductInformation GetById(int id)
        {
            return this.context.Set<ProductInformation>().Find(id);
        }

        public void Add(ProductInformation entity)
        {
            this.context.Set<ProductInformation>().Add(entity);
            this.context.SaveChanges();
        }

        public void Update(ProductInformation entity)
        {
            this.context.Set<ProductInformation>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProductInformation? entity = this.context.Set<ProductInformation>().Find(id);
            this.context.Set<ProductInformation>().Remove(entity!);
            this.context.SaveChanges();

        }

        public ProductInformation? FindByField(string fieldName, object value)
        {
            return this.GetAll().FirstOrDefault(_ =>
            {
                var propertyInfo = typeof(ProductInformation).GetProperty(fieldName);
                if (propertyInfo == null)
                {
                    return false;
                }

                var property = propertyInfo.GetValue(_);

                return Equals(property, value);
            });
        }
    }
}
