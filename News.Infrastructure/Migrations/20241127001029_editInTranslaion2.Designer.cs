﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.Infrastructure.Data;

#nullable disable

namespace News.Infrastructure.Migrations
{
    [DbContext(typeof(NewsDbContext))]
    [Migration("20241127001029_editInTranslaion2")]
    partial class editInTranslaion2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("News.Domain.Entities.Images", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("NewsId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("News.Domain.Entities.Language", b =>
                {
                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("News.Domain.Entities.New", b =>
                {
                    b.Property<int>("NewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("language")
                        .HasColumnType("int");

                    b.HasKey("NewId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("News.Domain.Entities.NewTranslation", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranslationId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("NewId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TranslationId");

                    b.HasIndex("NewId");

                    b.ToTable("newsTranslations");
                });

            modelBuilder.Entity("News.Domain.Entities.Images", b =>
                {
                    b.HasOne("News.Domain.Entities.New", "New")
                        .WithMany("Image")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("New");
                });

            modelBuilder.Entity("News.Domain.Entities.NewTranslation", b =>
                {
                    b.HasOne("News.Domain.Entities.New", "New")
                        .WithMany("Translations")
                        .HasForeignKey("NewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("New");
                });

            modelBuilder.Entity("News.Domain.Entities.New", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
