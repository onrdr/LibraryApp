﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("nvarchar(34)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Concrete.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            Name = "Author 1"
                        },
                        new
                        {
                            Id = new Guid("a8305503-a8da-4830-bcec-fa985e594a90"),
                            Name = "Author 2"
                        },
                        new
                        {
                            Id = new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"),
                            Name = "Author 3"
                        });
                });

            modelBuilder.Entity("Models.Entities.Concrete.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BorrowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ReturnDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84c52f0a-401d-40d2-80a1-281e48d5c17e"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            BorrowerId = new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                            ISBN = "2ae4acc6",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = false,
                            Name = "Book 1",
                            ReturnDate = new DateTimeOffset(new DateTime(2024, 3, 2, 3, 36, 5, 542, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 3, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("db63310e-3ddc-4715-a9cd-1f0cf4b14a59"),
                            AuthorId = new Guid("a8305503-a8da-4830-bcec-fa985e594a90"),
                            ISBN = "ad9b5ab4",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 2"
                        },
                        new
                        {
                            Id = new Guid("5c3a0e12-2bc9-45e1-abb3-c3201c94295e"),
                            AuthorId = new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"),
                            BorrowerId = new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                            ISBN = "2c22ad2d",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = false,
                            Name = "Book 3",
                            ReturnDate = new DateTimeOffset(new DateTime(2024, 1, 28, 3, 36, 5, 542, DateTimeKind.Unspecified).AddTicks(324), new TimeSpan(0, 3, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("b64f2fee-3829-4b9b-af12-bfee40fde344"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            BorrowerId = new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                            ISBN = "82a5e586",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = false,
                            Name = "Book 4",
                            ReturnDate = new DateTimeOffset(new DateTime(2024, 2, 29, 3, 36, 5, 542, DateTimeKind.Unspecified).AddTicks(335), new TimeSpan(0, 3, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("765d0dac-fe8c-447d-a238-f2d941a919aa"),
                            AuthorId = new Guid("a8305503-a8da-4830-bcec-fa985e594a90"),
                            ISBN = "99a07582",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 5"
                        },
                        new
                        {
                            Id = new Guid("7f039958-66fc-4b1a-9234-a3775c00cbe6"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            BorrowerId = new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                            ISBN = "bd6f2c67",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = false,
                            Name = "Book 6",
                            ReturnDate = new DateTimeOffset(new DateTime(2024, 2, 3, 3, 36, 5, 542, DateTimeKind.Unspecified).AddTicks(360), new TimeSpan(0, 3, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("f95b5bbe-daa9-4b45-9db7-dfff0126d384"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            ISBN = "a2b1bcd4",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 7"
                        },
                        new
                        {
                            Id = new Guid("442daaec-0a77-48b2-b236-140fd3636cdb"),
                            AuthorId = new Guid("a8305503-a8da-4830-bcec-fa985e594a90"),
                            ISBN = "d5f77f84",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 8"
                        },
                        new
                        {
                            Id = new Guid("094ada91-108c-42d2-876b-a982db803495"),
                            AuthorId = new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"),
                            ISBN = "69209cf9",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 9"
                        },
                        new
                        {
                            Id = new Guid("444e0e9b-51ce-4776-ab84-0031ae083cc4"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            ISBN = "3cd25bba",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 10"
                        },
                        new
                        {
                            Id = new Guid("517c37bb-720c-48d5-8e26-8d2ed1e3933a"),
                            AuthorId = new Guid("a8305503-a8da-4830-bcec-fa985e594a90"),
                            BorrowerId = new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                            ISBN = "c47d2d46",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = false,
                            Name = "Book 11",
                            ReturnDate = new DateTimeOffset(new DateTime(2024, 2, 27, 3, 36, 5, 542, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 3, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("3c042ca7-6ebc-4e8c-80c0-cd65f7ebc021"),
                            AuthorId = new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                            ISBN = "01cfd586",
                            ImageUrl = "images\\book\\default.jpg",
                            IsAvailable = true,
                            Name = "Book 12"
                        });
                });

            modelBuilder.Entity("Models.Entities.Concrete.Borrower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LibraryBorrowerId")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryBorrowerId")
                        .IsUnique();

                    b.ToTable("Borrowers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                            LibraryBorrowerId = "a373da2e",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                            LibraryBorrowerId = "4ecc1064",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("Models.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f514e34-8a22-4e36-aefc-752ba3aa0b34"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Models.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3e8fb682-ddad-4e8d-855a-35117415c2df"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a57cf2ef-4ac5-4af6-a9b7-028fc2856a8f",
                            Email = "admin@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAELQ6HjHz1tWMZ6Jydtfckt+1A+rA1t5itXYr5pfxyGMES/m2txWWPE5wz2VMcPz32Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a8ec31e9958e4e58b7cc6221f4eb6351",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Models.Identity.AppUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasDiscriminator().HasValue("AppUserRole");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3e8fb682-ddad-4e8d-855a-35117415c2df"),
                            RoleId = new Guid("2f514e34-8a22-4e36-aefc-752ba3aa0b34")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Models.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Models.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Entities.Concrete.Book", b =>
                {
                    b.HasOne("Models.Entities.Concrete.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Concrete.Borrower", "Borrower")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BorrowerId");

                    b.Navigation("Author");

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("Models.Entities.Concrete.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Models.Entities.Concrete.Borrower", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
