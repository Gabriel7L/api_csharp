﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_csharp.Data;

#nullable disable

namespace api_csharp.Migrations
{
    [DbContext(typeof(DbContextAPI))]
    partial class DbContextAPIModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api_csharp.Models.Contato", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Endereco")
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .HasColumnType("text")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("contato");
                });

            modelBuilder.Entity("api_csharp.Models.Worklist", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Exame")
                        .HasColumnType("text")
                        .HasColumnName("exame");

                    b.Property<string>("Sala")
                        .HasColumnType("text")
                        .HasColumnName("sala");

                    b.HasKey("Id");

                    b.ToTable("worklist");
                });
#pragma warning restore 612, 618
        }
    }
}
