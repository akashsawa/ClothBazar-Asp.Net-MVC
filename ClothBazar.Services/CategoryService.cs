﻿using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoryService
    {
        public Category GetCategory(int id)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(id);
            }
        }
        public List<Category> GetCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }

       

        public void SaveCategory(Category Category)
        {
            using(var context = new CBContext())
            {
                context.Categories.Add(Category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category Category)
        {
            using (var context = new CBContext())
            {
                context.Entry(Category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int Id)
        {
            using (var context = new CBContext())
            {
                //context.Entry(Category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(Id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
