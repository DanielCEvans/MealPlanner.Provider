﻿// <auto-generated />
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
    [Migration("20240602102424_AddIngredientAmountColumn")]
    partial class AddIngredientAmountColumn
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
                        .HasColumnType("text")
                        .HasColumnName("ingredient_name");

                    b.HasKey("IngredientId");

                    b.ToTable("ingredient");
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
                        .HasColumnType("text")
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
                    b.Property<string>("Meal")
                        .HasColumnType("text")
                        .HasColumnName("meal");

                    b.Property<string>("Ingredient")
                        .HasColumnType("text")
                        .HasColumnName("ingredient");

                    b.Property<string>("IngredientAmount")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ingredient_amount");

                    b.HasKey("Meal", "Ingredient");

                    b.ToTable("meal_ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
