﻿// <auto-generated />
using System;
using MealPlanner.Provider.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    [DbContext(typeof(MealPlannerContext))]
    [Migration("20240609035146_AlterInventoryTableRelationshipsAgain")]
    partial class AlterInventoryTableRelationshipsAgain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ingredient_name");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("InventoryIngredientId")
                        .HasColumnType("integer");

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("measurement_unit");

                    b.HasKey("IngredientId");

                    b.HasIndex("InventoryId", "InventoryIngredientId");

                    b.ToTable("ingredient");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .HasColumnType("integer")
                        .HasColumnName("inventory_id");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("InventoryAmount")
                        .HasColumnType("integer")
                        .HasColumnName("inventory_amount");

                    b.HasKey("InventoryId", "IngredientId");

                    b.ToTable("inventory");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("meal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MealId"));

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("meal_name");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("meal_type");

                    b.HasKey("MealId");

                    b.ToTable("meal");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.MealIngredients", b =>
                {
                    b.Property<string>("MealName")
                        .HasColumnType("text")
                        .HasColumnName("meal_name");

                    b.Property<string>("IngredientName")
                        .HasColumnType("text")
                        .HasColumnName("ingredient_name");

                    b.Property<int>("IngredientAmount")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_amount");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("MealId")
                        .HasColumnType("integer")
                        .HasColumnName("meal_id");

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("measurement_unit");

                    b.HasKey("MealName", "IngredientName");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MealId");

                    b.ToTable("meal_ingredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.Inventory", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("InventoryId", "InventoryIngredientId");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.MealIngredients", b =>
                {
                    b.HasOne("MealPlanner.Provider.Persistence.Models.Ingredient", "Ingredient")
                        .WithMany("MealIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealPlanner.Provider.Persistence.Models.Meal", "Meal")
                        .WithMany("MealIngredients")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.Navigation("MealIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Inventory", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Meal", b =>
                {
                    b.Navigation("MealIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
