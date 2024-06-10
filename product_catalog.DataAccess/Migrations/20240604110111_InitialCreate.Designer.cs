﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using product_catalog.DataAccess;

#nullable disable

namespace product_catalog.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240604110111_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("product_catalog.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Еда"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Вкусности"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Вода"
                        });
                });

            modelBuilder.Entity("product_catalog.DataAccess.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SpecialNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Селедка соленая",
                            GeneralNote = "Акция",
                            Price = 10m,
                            SpecialNote = "Пересоленая",
                            Title = "Селедка"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Тушенка говяжья",
                            GeneralNote = "Вкусная",
                            Price = 20m,
                            SpecialNote = "Жилы",
                            Title = "Тушенка"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "В банках",
                            GeneralNote = "С ключом",
                            Price = 30m,
                            SpecialNote = "Вкусная",
                            Title = "Сгущенка "
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "В бутылках",
                            GeneralNote = "Вятский",
                            Price = 15m,
                            SpecialNote = "Теплый",
                            Title = "Квас"
                        });
                });

            modelBuilder.Entity("product_catalog.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "antonov@gmail.com",
                            FirstName = "Антон",
                            LastName = "Антонов",
                            Password = "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6",
                            Role = "Admin",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Email = "reznichenko@gmail.com",
                            FirstName = "Светлана",
                            LastName = "Резниченко",
                            Password = "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6",
                            Role = "Admin",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ananko@gmail.com",
                            FirstName = "Егор",
                            LastName = "Ананько",
                            Password = "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2",
                            Role = "AdvancedUser",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 4,
                            Email = "denisova@gmail.com",
                            FirstName = "Настя",
                            LastName = "Денисова",
                            Password = "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2",
                            Role = "AdvancedUser",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 5,
                            Email = "pakhomova@gmail.com",
                            FirstName = "Диана",
                            LastName = "Пахомова",
                            Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq",
                            Role = "User",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 6,
                            Email = "radkevich@gmail.com",
                            FirstName = "Наташа",
                            LastName = "Радкевич",
                            Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq",
                            Role = "User",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 7,
                            Email = "ivanov@gmail.com",
                            FirstName = "Иван",
                            LastName = "Иванов",
                            Password = "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq",
                            Role = "User",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("product_catalog.DataAccess.Entities.ProductEntity", b =>
                {
                    b.HasOne("product_catalog.DataAccess.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("product_catalog.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
