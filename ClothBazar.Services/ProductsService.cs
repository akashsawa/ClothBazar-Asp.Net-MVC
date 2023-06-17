using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ProductsService
    {
        public Product GetProduct(int id)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(id);
            }
        }
        public List<Product> GetProducts()
        {
            using (var context = new CBContext())
            {
                return context.Products.ToList();
            }
        }

       

        public void SaveProduct(Product Product)
        {
            using(var context = new CBContext())
            {
                context.Products.Add(Product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product Product)
        {
            using (var context = new CBContext())
            {
                context.Entry(Product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int Id)
        {
            using (var context = new CBContext())
            {
                //context.Entry(Category).State = System.Data.Entity.EntityState.Deleted;
                var Product = context.Products.Find(Id);
                context.Products.Remove(Product);
                context.SaveChanges();
            }
        }
    }
}
