using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemoFinal
{
   public class ProductDal
    {
        public List<Product> GetAll() 
        { 
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();// Veri TAbanından ürünler çekildi ve lsitele çevrilecek
            }

        }
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
                // Veri TAbanından ürünler çekildi kontrolleri yapıldı liste haline getirildi
            }

        }



        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);// gönderilen productı databasedekiyle eşliyor
                entity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);// gönderilen productı databasedekiyle eşliyor
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }


    }
}
