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
    [Migration("20240616034718_ChangeMealTableToUseNaturalKey")]
    partial class ChangeMealTableToUseNaturalKey
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

                    b.Property<int>("IngredientAmount")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_amount");

                    b.Property<string>("IngredientCategory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ingredient_category");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ingredient_name");

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("measurement_unit");

                    b.HasKey("IngredientId");

                    b.ToTable("ingredient");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Meal", b =>
                {
                    b.Property<string>("MealName")
                        .HasColumnType("text")
                        .HasColumnName("meal_name");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("meal_type");

                    b.HasKey("MealName");

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

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("MealIngredientAmount")
                        .HasColumnType("integer")
                        .HasColumnName("meal_ingredient_amount");

                    b.HasKey("MealName", "IngredientName");

                    b.HasIndex("IngredientId");

                    b.ToTable("meal_ingredients");
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
                        .HasForeignKey("MealName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Ingredient", b =>
                {
                    b.Navigation("MealIngredients");
                });

            modelBuilder.Entity("MealPlanner.Provider.Persistence.Models.Meal", b =>
                {
                    b.Navigation("MealIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
