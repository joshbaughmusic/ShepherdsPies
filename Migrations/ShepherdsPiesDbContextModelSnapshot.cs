﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShepherdsPies.Data;

#nullable disable

namespace ShepherdsPies.Migrations
{
    [DbContext(typeof(ShepherdsPiesDbContext))]
    partial class ShepherdsPiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            ConcurrencyStamp = "3d3c06bc-a32f-45f2-ac4e-ae1dcb208711",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2bda489-98c8-49c6-aa15-c295f10d3536",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEIJ49N0wtADZy+r4zWT2BpkXxV0W7Hc353acxubttaPj9jZXJY1hMJ23iRssbjkKNA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6fc02d48-87e1-4fe2-b1ba-5d03bf4794fb",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShepherdsPies.Models.Cheese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Cheeses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Buffalo Mozzarella",
                            Price = 0m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Four Cheese",
                            Price = 0m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vegan",
                            Price = 0m
                        },
                        new
                        {
                            Id = 4,
                            Name = "None (cheeseless)",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = 1234567890L
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = 2345678901L
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Phone = 3456789012L
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Pine St",
                            FirstName = "Bob",
                            LastName = "Williams",
                            Phone = 4567890123L
                        },
                        new
                        {
                            Id = 5,
                            Address = "222 Birch St",
                            FirstName = "Eve",
                            LastName = "Brown",
                            Phone = 5678901234L
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            Email = "admina@strator.comx",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Delivery")
                        .HasColumnType("boolean");

                    b.Property<int?>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Tip")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Date = new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Delivery = true,
                            DriverId = 1,
                            EmployeeId = 1,
                            Tip = 5.00m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Date = new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Delivery = false,
                            EmployeeId = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Date = new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Delivery = true,
                            DriverId = 1,
                            EmployeeId = 1,
                            Tip = 3.00m
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            Date = new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Delivery = false,
                            EmployeeId = 1,
                            Tip = 2.00m
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            Date = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Delivery = true,
                            EmployeeId = 1,
                            Tip = 3.00m
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CheeseId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("SauceId")
                        .HasColumnType("integer");

                    b.Property<int>("SizeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CheeseId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SauceId");

                    b.HasIndex("SizeId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheeseId = 1,
                            OrderId = 1,
                            SauceId = 1,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CheeseId = 2,
                            OrderId = 1,
                            SauceId = 3,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 3,
                            CheeseId = 2,
                            OrderId = 2,
                            SauceId = 1,
                            SizeId = 3
                        },
                        new
                        {
                            Id = 4,
                            CheeseId = 4,
                            OrderId = 3,
                            SauceId = 2,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 5,
                            CheeseId = 2,
                            OrderId = 4,
                            SauceId = 1,
                            SizeId = 2
                        },
                        new
                        {
                            Id = 6,
                            CheeseId = 3,
                            OrderId = 4,
                            SauceId = 2,
                            SizeId = 3
                        },
                        new
                        {
                            Id = 7,
                            CheeseId = 1,
                            OrderId = 5,
                            SauceId = 4,
                            SizeId = 3
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.PizzaTopping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer");

                    b.Property<int>("ToppingId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaToppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PizzaId = 1,
                            ToppingId = 2
                        },
                        new
                        {
                            Id = 2,
                            PizzaId = 1,
                            ToppingId = 1
                        },
                        new
                        {
                            Id = 3,
                            PizzaId = 2,
                            ToppingId = 4
                        },
                        new
                        {
                            Id = 4,
                            PizzaId = 2,
                            ToppingId = 6
                        },
                        new
                        {
                            Id = 5,
                            PizzaId = 3,
                            ToppingId = 7
                        },
                        new
                        {
                            Id = 6,
                            PizzaId = 4,
                            ToppingId = 5
                        },
                        new
                        {
                            Id = 7,
                            PizzaId = 4,
                            ToppingId = 8
                        },
                        new
                        {
                            Id = 8,
                            PizzaId = 4,
                            ToppingId = 2
                        },
                        new
                        {
                            Id = 9,
                            PizzaId = 5,
                            ToppingId = 3
                        },
                        new
                        {
                            Id = 10,
                            PizzaId = 6,
                            ToppingId = 1
                        },
                        new
                        {
                            Id = 11,
                            PizzaId = 6,
                            ToppingId = 3
                        },
                        new
                        {
                            Id = 12,
                            PizzaId = 7,
                            ToppingId = 5
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Sauce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Sauces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marinara",
                            Price = 0m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Arrabbiata",
                            Price = 0m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Garlic White",
                            Price = 0m
                        },
                        new
                        {
                            Id = 4,
                            Name = "None (sauceless pizza)",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small (10\")",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium (14\")",
                            Price = 12.00m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large (18\")",
                            Price = 15.00m
                        });
                });

            modelBuilder.Entity("ShepherdsPies.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sausage",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pepperoni",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mushroom",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Onion",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Green Pepper",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Black Olive",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Basil",
                            Price = 0.50m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Extra Cheese",
                            Price = 0.50m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShepherdsPies.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("ShepherdsPies.Models.Order", b =>
                {
                    b.HasOne("ShepherdsPies.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShepherdsPies.Models.Employee", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("ShepherdsPies.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Driver");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ShepherdsPies.Models.Pizza", b =>
                {
                    b.HasOne("ShepherdsPies.Models.Cheese", "Cheese")
                        .WithMany()
                        .HasForeignKey("CheeseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShepherdsPies.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShepherdsPies.Models.Sauce", "Sauce")
                        .WithMany()
                        .HasForeignKey("SauceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShepherdsPies.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cheese");

                    b.Navigation("Sauce");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ShepherdsPies.Models.PizzaTopping", b =>
                {
                    b.HasOne("ShepherdsPies.Models.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShepherdsPies.Models.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("ShepherdsPies.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShepherdsPies.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("ShepherdsPies.Models.Pizza", b =>
                {
                    b.Navigation("PizzaToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
