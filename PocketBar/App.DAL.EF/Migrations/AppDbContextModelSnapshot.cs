// <auto-generated />
using System;
using App.DAL.EF;
using Base.Domain.Translation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.DAL.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.AmountUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("AmountUnits");
                });

            modelBuilder.Entity("App.Domain.Cocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImagePath")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("App.Domain.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("AlcoholByVolume")
                        .HasColumnType("real");

                    b.Property<string>("CoverImagePath")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid>("DrinkTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("DrinkTypeId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("App.Domain.DrinkInCocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid>("AmountUnitId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("DrinkId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("AmountUnitId");

                    b.HasIndex("CocktailId");

                    b.HasIndex("DrinkId");

                    b.ToTable("DrinkInCocktails");
                });

            modelBuilder.Entity("App.Domain.DrinkType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("DrinkTypes");
                });

            modelBuilder.Entity("App.Domain.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<LanguageString>("DisplayName")
                        .IsRequired()
                        .HasColumnType("jsonb");

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
                });

            modelBuilder.Entity("App.Domain.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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
                });

            modelBuilder.Entity("App.Domain.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("ExpirationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("PreviousExpirationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PreviousSignature")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Signature")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("App.Domain.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImagePath")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("App.Domain.IngredientInCocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid>("AmountUnitId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("AmountUnitId");

                    b.HasIndex("CocktailId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientInCocktails");
                });

            modelBuilder.Entity("App.Domain.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("GradeValue")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("App.Domain.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<LanguageString>("Description")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("IndexNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("App.Domain.UserCocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CocktailId");

                    b.HasIndex("RatingId");

                    b.ToTable("UserCocktails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("App.Domain.Drink", b =>
                {
                    b.HasOne("App.Domain.DrinkType", "DrinkType")
                        .WithMany("Drinks")
                        .HasForeignKey("DrinkTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DrinkType");
                });

            modelBuilder.Entity("App.Domain.DrinkInCocktail", b =>
                {
                    b.HasOne("App.Domain.AmountUnit", "AmountUnit")
                        .WithMany("DrinkInCocktails")
                        .HasForeignKey("AmountUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Cocktail", "Cocktail")
                        .WithMany("DrinkInCocktails")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Drink", "Drink")
                        .WithMany("DrinkInCocktails")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AmountUnit");

                    b.Navigation("Cocktail");

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("App.Domain.Identity.RefreshToken", b =>
                {
                    b.HasOne("App.Domain.Identity.AppUser", "AppUser")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("App.Domain.IngredientInCocktail", b =>
                {
                    b.HasOne("App.Domain.AmountUnit", "AmountUnit")
                        .WithMany("IngredientInCocktails")
                        .HasForeignKey("AmountUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Cocktail", "Cocktail")
                        .WithMany("IngredientInCocktails")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Ingredient", "Ingredient")
                        .WithMany("IngredientInCocktails")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AmountUnit");

                    b.Navigation("Cocktail");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("App.Domain.Step", b =>
                {
                    b.HasOne("App.Domain.Cocktail", "Cocktail")
                        .WithMany("Steps")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cocktail");
                });

            modelBuilder.Entity("App.Domain.UserCocktail", b =>
                {
                    b.HasOne("App.Domain.Identity.AppUser", "AppUser")
                        .WithMany("UserCocktails")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Cocktail", "Cocktail")
                        .WithMany("UserCocktails")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Rating", "Rating")
                        .WithMany("UserCocktails")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Cocktail");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("App.Domain.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("App.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("App.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("App.Domain.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("App.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.AmountUnit", b =>
                {
                    b.Navigation("DrinkInCocktails");

                    b.Navigation("IngredientInCocktails");
                });

            modelBuilder.Entity("App.Domain.Cocktail", b =>
                {
                    b.Navigation("DrinkInCocktails");

                    b.Navigation("IngredientInCocktails");

                    b.Navigation("Steps");

                    b.Navigation("UserCocktails");
                });

            modelBuilder.Entity("App.Domain.Drink", b =>
                {
                    b.Navigation("DrinkInCocktails");
                });

            modelBuilder.Entity("App.Domain.DrinkType", b =>
                {
                    b.Navigation("Drinks");
                });

            modelBuilder.Entity("App.Domain.Identity.AppUser", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserCocktails");
                });

            modelBuilder.Entity("App.Domain.Ingredient", b =>
                {
                    b.Navigation("IngredientInCocktails");
                });

            modelBuilder.Entity("App.Domain.Rating", b =>
                {
                    b.Navigation("UserCocktails");
                });
#pragma warning restore 612, 618
        }
    }
}
