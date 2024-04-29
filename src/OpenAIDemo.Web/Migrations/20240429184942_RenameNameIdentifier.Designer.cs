﻿// <auto-generated />
using Haack.AIDemoWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pgvector;

#nullable disable

namespace Haack.AIDemoWeb.Migrations
{
    [DbContext(typeof(AIDemoContext))]
    [Migration("20240429184942_RenameNameIdentifier")]
    partial class RenameNameIdentifier
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "citext");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "vector");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.AssistantThread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AssistantId")
                        .HasColumnType("text");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("ThreadId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FormattedAddress")
                        .HasColumnType("text");

                    b.Property<Point>("Location")
                        .HasColumnType("geometry (point)");

                    b.Property<string>("NameIdentifier")
                        .IsRequired()
                        .HasColumnType("citext");

                    b.Property<string>("TimeZoneId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NameIdentifier")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.UserFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Vector>("Embeddings")
                        .IsRequired()
                        .HasColumnType("vector(1536 )");

                    b.Property<string>("Justification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Content")
                        .IsUnique();

                    b.ToTable("UserFacts");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.AssistantThread", b =>
                {
                    b.HasOne("Haack.AIDemoWeb.Entities.User", "Creator")
                        .WithMany("Threads")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.Contact", b =>
                {
                    b.OwnsMany("Haack.AIDemoWeb.Entities.ContactAddress", "Addresses", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<int>("ContactId")
                                .HasColumnType("integer");

                            b1.Property<string>("Country")
                                .HasColumnType("text");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("text");

                            b1.Property<string>("ExtendedAddress")
                                .HasColumnType("text");

                            b1.Property<string>("FormattedValue")
                                .HasColumnType("text");

                            b1.Property<Point>("Location")
                                .HasColumnType("geometry (point)");

                            b1.Property<string>("PoBox")
                                .HasColumnType("text");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .HasColumnType("text");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("text");

                            b1.Property<string>("Type")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("ContactId");

                            b1.ToTable("ContactAddress");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.OwnsMany("Haack.AIDemoWeb.Entities.ContactEmailAddress", "EmailAddresses", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<int>("ContactId")
                                .HasColumnType("integer");

                            b1.Property<string>("DisplayName")
                                .HasColumnType("text");

                            b1.Property<string>("Type")
                                .HasColumnType("text");

                            b1.Property<string>("Value")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("ContactId");

                            b1.ToTable("ContactEmailAddress");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.OwnsMany("Haack.AIDemoWeb.Entities.ContactName", "Names", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<int>("ContactId")
                                .HasColumnType("integer");

                            b1.Property<string>("FamilyName")
                                .HasColumnType("text");

                            b1.Property<string>("GivenName")
                                .HasColumnType("text");

                            b1.Property<string>("HonorificPrefix")
                                .HasColumnType("text");

                            b1.Property<string>("HonorificSuffix")
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticFamilyName")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticFullname")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticGivenName")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticHonorificPrefix")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticHonorificSuffix")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneticMiddleName")
                                .HasColumnType("text");

                            b1.Property<string>("UnstructuredName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("ContactId");

                            b1.ToTable("ContactName");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("EmailAddresses");

                    b.Navigation("Names");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.UserFact", b =>
                {
                    b.HasOne("Haack.AIDemoWeb.Entities.User", "User")
                        .WithMany("Facts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Haack.AIDemoWeb.Entities.User", b =>
                {
                    b.Navigation("Facts");

                    b.Navigation("Threads");
                });
#pragma warning restore 612, 618
        }
    }
}
