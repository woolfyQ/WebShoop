using WebShoop.Models;

namespace WebShoop.Data
{
    public class SeedData
    {
       

        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                   new Product()
                   {
                       Name = "Graphit Premium",
                       Price = 2200m,
                       Img = "pics/Kolpak1.jpg",
                       Specs = "310x310mm",
                       Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                   },
                   new Product()
                   {
                       Name = "DRAP (текстура) Premium",
                       Price = 2200m,
                       Img = "pics/Kolpak2.jpg",
                       Specs = "410x410mm",
                       Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                   },
                    new Product()
                    {
                        
                        Name = "Graphit (ТЕКСТУРА) Premium",
                        Price = 2200m,
                        Img = "pics/Kolpak3.jpg",
                        Specs = "210x210mm",
                        Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                    },
                     new Product()
                     {
                         Name = "DRAP (текстура) Premium",
                         Price = 2200m,
                         Img = "pics/Kolpak4.jpg",
                         Specs = "410x410mm",
                         Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                     },
                     new Product()
                     {
                         Name = "Graphit (ТЕКСТУРА) Premium",
                         Price = 2200m,
                         Img = "pics/Kolpak5.jpg",
                         Specs = "210x210mm",
                         Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                     },
                      new Product()
                      {
                          Name = "DRAP (текстура) Premium",
                          Price = 2200m,
                          Img = "pics/Kolpak6.jpg",
                          Specs = "310x310",
                          Description = "Graphit Premium матовый, толщина 0.45m, цвет 7024",
                      }
                );
                context.SaveChanges();


            }
        }
    }
}

