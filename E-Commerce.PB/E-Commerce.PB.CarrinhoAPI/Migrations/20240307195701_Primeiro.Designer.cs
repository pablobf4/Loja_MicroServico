﻿// <auto-generated />
using E_Commerce.PB.CarrinhoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.PB.CarrinhoAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240307195701_Primeiro")]
    partial class Primeiro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.PB.CarrinhoAPI.Model.CarrinhoCabecalho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CuponCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cupon_code");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("carrinho_cabecalho");
                });

            modelBuilder.Entity("E_Commerce.PB.CarrinhoAPI.Model.CarrinhoDetalhe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CarrinhoCabecalhoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Contar")
                        .HasColumnType("int")
                        .HasColumnName("Contar");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoCabecalhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("carrinho_detalhe");
                });

            modelBuilder.Entity("E_Commerce.PB.CarrinhoAPI.Model.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("categoria_nome");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("descricao");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("image_url");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("E_Commerce.PB.CarrinhoAPI.Model.CarrinhoDetalhe", b =>
                {
                    b.HasOne("E_Commerce.PB.CarrinhoAPI.Model.CarrinhoCabecalho", "CarrinhoCabecalho")
                        .WithMany()
                        .HasForeignKey("CarrinhoCabecalhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.PB.CarrinhoAPI.Model.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrinhoCabecalho");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
