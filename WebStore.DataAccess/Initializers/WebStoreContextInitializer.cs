using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Initializers
{
    public class WebStoreContextInitializer
        : DropCreateDatabaseAlways<WebStoreDbContext>
    {
        protected override void Seed(WebStoreDbContext context)
        {
            context.Categories.AddRange(new List<Category>
            {
                new Category { Name = "Продукты" }, //1
            });

            context.SaveChanges();

            context.Categories.AddRange(new List<Category>
            {
                new Category {HeadCategoryId = 1, Name = "Кисло-Молочка" }, //2
                new Category {HeadCategoryId = 1, Name = "Мясо" }, //3
                new Category {HeadCategoryId = 1, Name = "Рыба" }, //4
                new Category {HeadCategoryId = 1, Name = "Овощи" }, //5
                new Category {HeadCategoryId = 1, Name = "Фрукты" },//6
                new Category {HeadCategoryId = 1, Name = "Соки и Воды" },//7
            });

            context.SaveChanges();

            context.Categories.AddRange(new List<Category>
            {
                new Category {HeadCategoryId = 7, Name = "Газировка" }, //8
                new Category {HeadCategoryId = 7, Name = "Натуральные соки" }, //9
                new Category {HeadCategoryId = 7, Name = "Вода" }, //10
                new Category {HeadCategoryId = 4, Name = "Свежая рыба(охлажденная)" }, //11
                new Category {HeadCategoryId = 4, Name = "Замороженная рыба" },//12
                new Category {HeadCategoryId = 2, Name = "Мороженное" },//13
            });
            context.SaveChanges();


            context.Products.AddRange(new List<Product>
            {
                new Product { Name = "Кефир", CategoryId = 2, Description = "Кифир домик в деревне", Price = 63 },
                new Product { Name = "Крем-Брюле", CategoryId = 13, Description = "48 Копеек", Price = 100 },
                new Product { Name = "Карась", CategoryId = 11, Description = "noName", Price = 150 },
                new Product { Name = "Аква Минерале", CategoryId = 10, Description = "Pepsi Co", Price = 50 },
                new Product { Name = "Сады Придонья", CategoryId = 9, Description = "Сады Придонья", Price = 70 },
                new Product { Name = "Картофель", CategoryId = 5, Description = "Фермерский продукт", Price = 35 },
                new Product { Name = "Морковь", CategoryId = 5, Description = "Счастливая Ферма", Price = 20 },
                new Product { Name = "Апельсины", CategoryId = 6, Description = "Чебурляндия", Price = 80 },
                new Product { Name = "Рулька Свинная", CategoryId = 3, Description = "Улыбчивый мясник", Price = 250 }
            });

            context.SaveChanges();

            context.SaveChanges();

            context.Roles.AddRange(new List<Role> {
                new Role {  Name = "Гость" },
                new Role {  Name = "Пользователь" },
                new Role {  Name = "Администратор" },
            });

            context.SaveChanges();

            context.Groups.AddRange(new List<Group> {
                new Group {  Name = "Гости", Roles = context.Roles.Where(x => x.Id == 1).ToList() },
                new Group {  Name = "Пользователи", Roles = context.Roles.Where(x => x.Id == 2).ToList() },
                new Group {  Name = "Администраторы", Roles = context.Roles.Where(x => x.Id == 3).ToList() },
            });

            context.SaveChanges();

            var random = new Random(1);

            context.Users.AddRange(new List<User> {
                new User {
                    Id = 1,
                    Login = "admin",
                    GroupId = 3,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                },
                new User {
                    Id = 2,
                    Login = "user",
                    GroupId = 2,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("user1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                },
                new User {
                    Id = 3,
                    Login = "guest",
                    GroupId = 1,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("guest1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                }
            });

            context.SaveChanges();
        }
    }
}