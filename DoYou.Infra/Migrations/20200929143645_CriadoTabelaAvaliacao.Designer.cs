﻿// <auto-generated />
using System;
using DoYou.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoYou.Infra.Migrations
{
    [DbContext(typeof(DoYouContext))]
    [Migration("20200929143645_CriadoTabelaAvaliacao")]
    partial class CriadoTabelaAvaliacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoYou.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estrelas")
                        .HasColumnType("int")
                        .HasMaxLength(1);

                    b.Property<Guid?>("FkEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FkUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FkEmpresa");

                    b.HasIndex("FkUsuario");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("FkProprietario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProprietarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.HasKey("Id");

                    b.HasIndex("FkProprietario");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid?>("FkEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("FkEmpresa");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Mesa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FkEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<bool>("Ocupada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FkEmpresa");

                    b.ToTable("Mesa");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Proprietario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("EmpresaUltimoAcesso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Proprietario");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataAniversario")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("DoYou.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("FkEmpresa");

                    b.HasOne("DoYou.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("FkUsuario");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Empresa", b =>
                {
                    b.HasOne("DoYou.Domain.Entities.Proprietario", null)
                        .WithMany("Empresas")
                        .HasForeignKey("FkProprietario");

                    b.HasOne("DoYou.Domain.Entities.Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId");

                    b.OwnsOne("DoYou.Domain.ObjectValues.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .HasColumnName("EndBairro")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("CEP")
                                .HasColumnName("EndCep")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("Complemento")
                                .HasColumnName("EndComplemento")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("Logradouro")
                                .HasColumnName("EndLogradouro")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Municipio")
                                .HasColumnName("EndMunicipio")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<int>("Numero")
                                .HasColumnName("EndNumero")
                                .HasColumnType("int")
                                .HasMaxLength(10);

                            b1.Property<string>("UF")
                                .HasColumnName("EndUf")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Item", b =>
                {
                    b.HasOne("DoYou.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Itens")
                        .HasForeignKey("FkEmpresa");
                });

            modelBuilder.Entity("DoYou.Domain.Entities.Mesa", b =>
                {
                    b.HasOne("DoYou.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Mesas")
                        .HasForeignKey("FkEmpresa");
                });
#pragma warning restore 612, 618
        }
    }
}
