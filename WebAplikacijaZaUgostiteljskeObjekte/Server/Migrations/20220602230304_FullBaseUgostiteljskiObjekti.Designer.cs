﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    [DbContext(typeof(Data))]
    [Migration("20220602230304_FullBaseUgostiteljskiObjekti")]
    partial class FullBaseUgostiteljskiObjekti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UgostiteljskiObjektId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.Jela", b =>
                {
                    b.Property<int>("JelaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JelaId"), 1L, 1);

                    b.Property<decimal>("Cjena")
                        .HasColumnType("money");

                    b.Property<string>("NazivJela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UgostiteljskiObjektId")
                        .HasColumnType("int");

                    b.HasKey("JelaId");

                    b.ToTable("Jela");
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.Ocjene", b =>
                {
                    b.Property<int>("OcjeneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OcjeneId"), 1L, 1);

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<string>("UgostiteljskiObjektiId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OcjeneId");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.UgostiteljskiObjekti", b =>
                {
                    b.Property<int>("UgostiteljskiObjektiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UgostiteljskiObjektiId"), 1L, 1);

                    b.Property<string>("UgostiteljskiObjektiEmali")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UgostiteljskiObjektiKontakt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UgostiteljskiObjektiLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UgostiteljskiObjektiNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UgostiteljskiObjektiProsjecnaOcjena")
                        .HasColumnType("real");

                    b.Property<string>("UgostiteljskiObjektiSlika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UgostiteljskiObjektiId");

                    b.ToTable("UgostiteljskiObjekti");
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.Comment", b =>
                {
                    b.HasOne("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
