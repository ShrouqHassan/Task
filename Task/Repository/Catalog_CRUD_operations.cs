using System.Runtime.InteropServices;
using Task.Models;

namespace Task.Repository
{
    public class Catalog_CRUD_operations
    {
       Context context=new Context();
        public void AddCatalog(Catalog catalog)
        {
            context.Catalogs.Add(catalog);
        }
        public List<Catalog> GetAll()
        {
            List<Catalog> catalog = context.Catalogs.Where(c => !c.DeletedDate.HasValue).ToList();
            return catalog;
        }

        public void Update(Catalog catalog)
        {
            context.Catalogs.Update(catalog);
        }
        public void Delete(Catalog catalog)
        {
            catalog.DeletedDate= DateTime.Now;
            context.Catalogs.Update(catalog);
            context.SaveChanges();
        }
        public Catalog GetById(int id) {
        
            return context.Catalogs.FirstOrDefault(c => c.Id==id);
        }
        public int save()
        {
            return context.SaveChanges();

        }
    }
   
}
