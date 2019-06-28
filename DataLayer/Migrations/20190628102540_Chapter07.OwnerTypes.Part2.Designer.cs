﻿// <auto-generated />
using System;
using DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20190628102540_Chapter07.OwnerTypes.Part2")]
    partial class Chapter07OwnerTypesPart2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.EfClasses.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DataLayer.EfClasses.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(512)
                        .IsUnicode(false);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("date");

                    b.Property<string>("Publisher")
                        .HasMaxLength(64);

                    b.Property<bool>("SoftDeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("BookId");

                    b.HasIndex("PublishedOn");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DataLayer.EfClasses.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.Property<byte>("Order");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("DataLayer.EfClasses.LineItem", b =>
                {
                    b.Property<int>("LineItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<decimal>("BookPrice");

                    b.Property<byte>("LineNum");

                    b.Property<short>("NumBooks");

                    b.Property<int>("OrderId");

                    b.HasKey("LineItemId");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("DataLayer.EfClasses.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustomerName");

                    b.Property<DateTime>("DateOrderedUtc");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.EfClasses.OrderInfo", b =>
                {
                    b.Property<int>("OrderInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderNumber");

                    b.HasKey("OrderInfoId");

                    b.ToTable("OrderInfos");
                });

            modelBuilder.Entity("DataLayer.EfClasses.PriceOffer", b =>
                {
                    b.Property<int>("PriceOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("PromotionalText")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("PriceOfferId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("PriceOffers");
                });

            modelBuilder.Entity("DataLayer.EfClasses.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("Comment");

                    b.Property<int>("NumStars");

                    b.Property<string>("VoterName")
                        .HasMaxLength(100);

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("DataLayer.EfClasses.BookAuthor", b =>
                {
                    b.HasOne("DataLayer.EfClasses.Author", "Author")
                        .WithMany("BooksLink")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.EfClasses.Book", "Book")
                        .WithMany("AuthorsLink")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.EfClasses.LineItem", b =>
                {
                    b.HasOne("DataLayer.EfClasses.Book", "ChosenBook")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataLayer.EfClasses.Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.EfClasses.OrderInfo", b =>
                {
                    b.OwnsOne("DataLayer.EfClasses.Address", "BillingAddress", b1 =>
                        {
                            b1.Property<int>("OrderInfoId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City");

                            b1.Property<string>("CountryCodeIso2");

                            b1.Property<string>("NumberAndStreet");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("OrderInfoId");

                            b1.ToTable("OrderInfos");

                            b1.HasOne("DataLayer.EfClasses.OrderInfo")
                                .WithOne("BillingAddress")
                                .HasForeignKey("DataLayer.EfClasses.Address", "OrderInfoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("DataLayer.EfClasses.Address", "DeliveryAddress", b1 =>
                        {
                            b1.Property<int>("OrderInfoId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City");

                            b1.Property<string>("CountryCodeIso2");

                            b1.Property<string>("NumberAndStreet");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("OrderInfoId");

                            b1.ToTable("OrderInfos");

                            b1.HasOne("DataLayer.EfClasses.OrderInfo")
                                .WithOne("DeliveryAddress")
                                .HasForeignKey("DataLayer.EfClasses.Address", "OrderInfoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("DataLayer.EfClasses.Address", "HomeAddress", b1 =>
                        {
                            b1.Property<int>("OrderInfoId");

                            b1.Property<string>("City");

                            b1.Property<string>("CountryCodeIso2");

                            b1.Property<string>("NumberAndStreet");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("OrderInfoId");

                            b1.ToTable("HomeAddress");

                            b1.HasOne("DataLayer.EfClasses.OrderInfo")
                                .WithOne("HomeAddress")
                                .HasForeignKey("DataLayer.EfClasses.Address", "OrderInfoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("DataLayer.EfClasses.PriceOffer", b =>
                {
                    b.HasOne("DataLayer.EfClasses.Book")
                        .WithOne("Promotion")
                        .HasForeignKey("DataLayer.EfClasses.PriceOffer", "BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.EfClasses.Review", b =>
                {
                    b.HasOne("DataLayer.EfClasses.Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
