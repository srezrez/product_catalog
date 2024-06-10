using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.Entities;
using product_catalog.Domain.Enums;
using System.Reflection;

namespace product_catalog.DataAccess;

public class DataContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<UserEntity>().HasData(
            new[]
            {
                new UserEntity { Id = 1, Email = "antonov@gmail.com", Password = "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6", FirstName = "Антон", LastName = "Антонов", Role = UserRole.Admin, Status = UserStatus.Active },
                new UserEntity { Id = 2, Email = "reznichenko@gmail.com", Password = "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6", FirstName = "Светлана", LastName = "Резниченко", Role = UserRole.Admin, Status = UserStatus.Active },
                new UserEntity { Id = 3, Email = "ananko@gmail.com", Password = "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2", FirstName = "Егор", LastName = "Ананько", Role = UserRole.AdvancedUser, Status = UserStatus.Active },
                new UserEntity { Id = 4, Email = "denisova@gmail.com", Password = "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2", FirstName = "Настя", LastName = "Денисова", Role = UserRole.AdvancedUser, Status = UserStatus.Active },
                new UserEntity { Id = 5, Email = "pakhomova@gmail.com", Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", FirstName = "Диана", LastName = "Пахомова", Role = UserRole.User, Status = UserStatus.Active },
                new UserEntity { Id = 6, Email = "radkevich@gmail.com", Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", FirstName = "Наташа", LastName = "Радкевич", Role = UserRole.User, Status = UserStatus.Active },
                new UserEntity { Id = 7, Email = "ivanov@gmail.com", Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", FirstName = "Иван", LastName = "Иванов", Role = UserRole.User, Status = UserStatus.Active },
            });

        modelBuilder.Entity<CategoryEntity>().HasData(
            new[]
            {
                new CategoryEntity { Id = 1, Title = "Еда"},
                new CategoryEntity { Id = 2, Title = "Вкусности"},
                new CategoryEntity { Id = 3, Title = "Вода"},
            });

        modelBuilder.Entity<ProductEntity>().HasData(
            new[]
            {
                new ProductEntity { Id = 1, Title = "Селедка", Description = "Селедка соленая", Price = 10, GeneralNote = "Акция", SpecialNote = "Пересоленая", CategoryId = 1 },
                new ProductEntity { Id = 2, Title = "Тушенка", Description = "Тушенка говяжья", Price = 20, GeneralNote = "Вкусная", SpecialNote = "Жилы", CategoryId = 1 },
                new ProductEntity { Id = 3, Title = "Сгущенка ", Description = "В банках", Price = 30, GeneralNote = "С ключом", SpecialNote = "Вкусная", CategoryId = 2 },
                new ProductEntity { Id = 4, Title = "Квас", Description = "В бутылках", Price = 15, GeneralNote = "Вятский", SpecialNote = "Теплый", CategoryId = 3 },
            });
    }
}
