using System.Data.Entity;

namespace Office4.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "Ручка", Company = "Erich Krause", Description = "Ручка шариковая", Image = "1.jpg", Price = 10 });
            db.Products.Add(new Product { Name = "Карандаш", Company = "Erich Krause", Description = "Простой карандаш", Image = "2.jpg", Price = 5 });
            db.Products.Add(new Product { Name = "Пенал", Company = "Erich Krause", Description = "Вместительный пенал", Image = "3.jpg", Price = 200 });
            db.Products.Add(new Product { Name = "Линейка", Company = "Erich Krause", Description = "Линейка 30см", Image = "4.jpg", Price = 20 });
            db.Products.Add(new Product { Name = "Ластик", Company = "Erich Krause", Description = "Ластик средней твердости", Image = "5.jpg", Price = 9 });
            db.Products.Add(new Product { Name = "Транспартир", Company = "Erich Krause", Description = "Металлический транспортир", Image = "6.jpg", Price = 100 });
            db.Products.Add(new Product { Name = "Циркуль", Company = "Erich Krause", Description = "Циркуль для черчения", Image = "7.jpg", Price = 200 });
            base.Seed(db);
        }
    }
}