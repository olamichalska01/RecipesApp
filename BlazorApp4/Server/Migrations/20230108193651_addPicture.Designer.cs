﻿// <auto-generated />
using BlazorApp4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp4.Server.Migrations
{
    [DbContext(typeof(CakesDBContext))]
    [Migration("20230108193651_addPicture")]
    partial class addPicture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorApp4.Shared.Cake", b =>
                {
                    b.Property<int>("CakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CakeId"), 1L, 1);

                    b.Property<string>("CakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreparationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CakeId");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("BlazorApp4.Shared.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitOfMeasureId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("Ingerdients");
                });

            modelBuilder.Entity("BlazorApp4.Shared.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"), 1L, 1);

                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeSteps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeId");

                    b.HasIndex("CakeId")
                        .IsUnique();

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("BlazorApp4.Shared.UnitOfMeasure", b =>
                {
                    b.Property<int>("UnitOfMeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitOfMeasureId"), 1L, 1);

                    b.Property<string>("UnitOfMeasureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitOfMeasureId");

                    b.ToTable("UnitsOfMeasure");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.Property<int>("IngredientsIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsIngredientId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("IngredientRecipe");
                });

            modelBuilder.Entity("BlazorApp4.Shared.Ingredient", b =>
                {
                    b.HasOne("BlazorApp4.Shared.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("Ingredients")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("BlazorApp4.Shared.Recipe", b =>
                {
                    b.HasOne("BlazorApp4.Shared.Cake", "Cake")
                        .WithOne("Recipe")
                        .HasForeignKey("BlazorApp4.Shared.Recipe", "CakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cake");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.HasOne("BlazorApp4.Shared.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp4.Shared.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp4.Shared.Cake", b =>
                {
                    b.Navigation("Recipe")
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp4.Shared.UnitOfMeasure", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
