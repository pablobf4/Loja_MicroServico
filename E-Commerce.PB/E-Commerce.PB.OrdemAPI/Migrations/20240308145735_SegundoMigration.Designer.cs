﻿// <auto-generated />
using System;
using E_Commerce.PB.OrdemAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.PB.OrdemAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240308145735_SegundoMigration")]
    partial class SegundoMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.PB.OrdemAPI.Model.OrdemDetalhe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IdOrdemCabecalho")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint")
                        .HasColumnName("ProdutoId");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("produto_nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("contar");

                    b.HasKey("Id");

                    b.HasIndex("IdOrdemCabecalho");

                    b.ToTable("order_detail");
                });

            modelBuilder.Entity("E_Commerce.PB.OrdemAPI.Modell.OrdemCabecalho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cvv");

                    b.Property<string>("CupomCodigo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("coupon_code");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2")
                        .HasColumnName("purchase_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("datetime2")
                        .HasColumnName("ordem_time");

                    b.Property<string>("MesAnoExpiracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("expiracao_mes_ano");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numero_cartao");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("primeiro_name");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sobrenome_name");

                    b.Property<bool>("StatusPagamento")
                        .HasColumnType("bit")
                        .HasColumnName("pagamento_status");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("telefone_number");

                    b.Property<int>("TotalItensCarrinho")
                        .HasColumnType("int")
                        .HasColumnName("total_itens");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_id");

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor_compra");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor_desconto");

                    b.HasKey("Id");

                    b.ToTable("Ordem_Cabecalho");
                });

            modelBuilder.Entity("E_Commerce.PB.OrdemAPI.Model.OrdemDetalhe", b =>
                {
                    b.HasOne("E_Commerce.PB.OrdemAPI.Modell.OrdemCabecalho", "OrdemCabecalho")
                        .WithMany("DetalhesPedido")
                        .HasForeignKey("IdOrdemCabecalho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemCabecalho");
                });

            modelBuilder.Entity("E_Commerce.PB.OrdemAPI.Modell.OrdemCabecalho", b =>
                {
                    b.Navigation("DetalhesPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
