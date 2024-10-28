﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MealPlanner.Provider.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    [DbContext(typeof(MealPlannerContext))]
    partial class MealPlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("GramsPerCup")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.IngredientCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IngredientCategories");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("GeneratedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.ShoppingListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<decimal>("RequiredQuantity")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListItems");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.StoredCredential", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("bytea");

                    b.Property<Guid>("AaGuid")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("AttestationClientDataJson")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("AttestationFormat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("AttestationObject")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Descriptor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<byte[]>>("DevicePublicKeys")
                        .IsRequired()
                        .HasColumnType("bytea[]");

                    b.Property<bool>("IsBackedUp")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBackupEligible")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("PublicKey")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTimeOffset>("RegDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("SignCount")
                        .HasColumnType("bigint");

                    b.Property<int[]>("Transports")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<byte[]>("UserHandle")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("UserId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("StoredCredentials");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<byte[]>("Fido2Id")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.UserIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UserId", "IngredientId")
                        .IsUnique();

                    b.ToTable("UserIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.IngredientCategory", "Category")
                        .WithMany("Ingredients")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.RecipeIngredient", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealPlanner.Provider.Persistence.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.ShoppingList", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.User", "User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.ShoppingListItem", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.Ingredient", "Ingredient")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealPlanner.Provider.Persistence.Models.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.StoredCredential", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.User", "User")
                        .WithMany("StoredCredentials")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.UserIngredient", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.Ingredient", "Ingredient")
                        .WithMany("UserIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealPlanner.Provider.Persistence.Models.User", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("ShoppingListItems");

                    b.Navigation("UserIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.IngredientCategory", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListItems");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.User", b =>
                {
                    b.Navigation("ShoppingLists");

                    b.Navigation("StoredCredentials");

                    b.Navigation("UserIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
