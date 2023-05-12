namespace Product_Inventory_Management_System.Interface
{
    using System.Collections.Generic;
    public interface IGenericService<T>
        where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

        T? FindByField(string fieldName, object value);

    }
}
