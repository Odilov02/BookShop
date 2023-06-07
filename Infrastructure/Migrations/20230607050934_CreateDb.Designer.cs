﻿// <auto-generated />
using System;
using Infrastructure.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230607050934_CreateDb")]
    partial class CreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Lasted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Lasted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PageCount")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Lasted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Commentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Commentaries");
                });

            modelBuilder.Entity("Domain.Entities.IdentityEntities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8118d09-1076-4bf7-ac12-385f5fd9bd8c"),
                            PermissionName = "CreateAuthor"
                        },
                        new
                        {
                            Id = new Guid("cec85258-a576-424f-8c55-efcde161d70e"),
                            PermissionName = "GetAuthor"
                        },
                        new
                        {
                            Id = new Guid("42857e02-04db-434d-9f98-3595494d1cdd"),
                            PermissionName = "UpdateAuthor"
                        },
                        new
                        {
                            Id = new Guid("dce5e707-38e1-4e60-85e1-328ec8716195"),
                            PermissionName = "DeleteAuthor"
                        },
                        new
                        {
                            Id = new Guid("6d682a95-4a20-4f1c-947b-c89d8c5f05b6"),
                            PermissionName = "GetUser"
                        },
                        new
                        {
                            Id = new Guid("882af2fd-d21d-4938-8deb-dd1955d77f1f"),
                            PermissionName = "UpdateUserForAdmin"
                        },
                        new
                        {
                            Id = new Guid("599928ff-3a43-462d-8d99-8157c9efb600"),
                            PermissionName = "GetPermission"
                        },
                        new
                        {
                            Id = new Guid("9754f9c1-4f1a-483d-875b-fa54704163e6"),
                            PermissionName = "GetBook"
                        },
                        new
                        {
                            Id = new Guid("eadb25c4-11ac-403d-8391-3ba6fb3e8519"),
                            PermissionName = "UpdateBook"
                        },
                        new
                        {
                            Id = new Guid("4a0f97bf-d891-498a-84cd-8557bbd52e38"),
                            PermissionName = "DeleteBook"
                        },
                        new
                        {
                            Id = new Guid("26cd3943-d2a8-4bda-84e7-8ced3a665be6"),
                            PermissionName = "CreateBook"
                        },
                        new
                        {
                            Id = new Guid("2acf3135-d94b-44ea-92fa-80133bb73e5f"),
                            PermissionName = "CreateCategory"
                        },
                        new
                        {
                            Id = new Guid("d671259a-5998-4a0a-9242-ebcf0f288723"),
                            PermissionName = "GetCategory"
                        },
                        new
                        {
                            Id = new Guid("0b18d9da-e7ad-423d-9ed5-873582ca6257"),
                            PermissionName = "UpdateCategory"
                        },
                        new
                        {
                            Id = new Guid("3b3eea82-f38e-4f59-befe-ca789424e15e"),
                            PermissionName = "DeleteCategory"
                        },
                        new
                        {
                            Id = new Guid("a8bfeaf5-2ae1-47fe-bb3d-f68e5781f59a"),
                            PermissionName = "UpdateCommentary"
                        },
                        new
                        {
                            Id = new Guid("d6bd1182-8d0a-4884-9d0e-277e009f1b8d"),
                            PermissionName = "DeleteCommentary"
                        },
                        new
                        {
                            Id = new Guid("2c8b9e9f-6d42-4a4e-a1e0-524da98e480d"),
                            PermissionName = "CreateRole"
                        },
                        new
                        {
                            Id = new Guid("4f23ada4-0bf6-4873-842d-6d64b95cd083"),
                            PermissionName = "GetRole"
                        },
                        new
                        {
                            Id = new Guid("d040c078-32aa-42a7-9d21-2b1947630226"),
                            PermissionName = "UpdateRole"
                        },
                        new
                        {
                            Id = new Guid("715c6cc6-ac75-45e7-9df7-22e7957c58fb"),
                            PermissionName = "DeleteRole"
                        });
                });

            modelBuilder.Entity("Domain.Entities.IdentityEntities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("permissionsId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "permissionsId");

                    b.HasIndex("permissionsId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.HasOne("Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Commentary", b =>
                {
                    b.HasOne("Domain.Entities.Book", "book")
                        .WithMany("Commentaries")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Commentaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("book");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("Domain.Entities.IdentityEntities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.IdentityEntities.Permission", null)
                        .WithMany()
                        .HasForeignKey("permissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Domain.Entities.IdentityEntities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Navigation("Commentaries");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Commentaries");
                });
#pragma warning restore 612, 618
        }
    }
}
