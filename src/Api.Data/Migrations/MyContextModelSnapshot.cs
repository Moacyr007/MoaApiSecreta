﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CampeonatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TerceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ViceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CampeaoId");

                    b.HasIndex("TerceiroId");

                    b.HasIndex("ViceId");

                    b.ToTable("Campeonato");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeonatoEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<int>("Gols1")
                        .HasColumnType("int");

                    b.Property<int>("Gols2")
                        .HasColumnType("int");

                    b.Property<Guid?>("Time1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Time2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoEntityId");

                    b.HasIndex("Time1Id");

                    b.HasIndex("Time2Id");

                    b.ToTable("Partida");
                });

            modelBuilder.Entity("Domain.Entities.PontuacaoCampeonatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeonatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.Property<Guid?>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("TimeId");

                    b.ToTable("PontuacaoCampeonato");
                });

            modelBuilder.Entity("Domain.Entities.TimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Time");

                    b.HasData(
                        new
                        {
                            Id = new Guid("05365df3-547c-4b26-a7b0-b014455d5279"),
                            Excluido = false,
                            Nome = "Palmeiras"
                        },
                        new
                        {
                            Id = new Guid("ae8b0f02-3ec9-49e8-be6c-6f8f6a1450ef"),
                            Excluido = false,
                            Nome = "Luverdense"
                        },
                        new
                        {
                            Id = new Guid("ce33453c-efee-4041-b6db-043dec8979ca"),
                            Excluido = false,
                            Nome = "Flamengo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CampeonatoEntity", b =>
                {
                    b.HasOne("Domain.Entities.TimeEntity", "Campeao")
                        .WithMany()
                        .HasForeignKey("CampeaoId");

                    b.HasOne("Domain.Entities.TimeEntity", "Terceiro")
                        .WithMany()
                        .HasForeignKey("TerceiroId");

                    b.HasOne("Domain.Entities.TimeEntity", "Vice")
                        .WithMany()
                        .HasForeignKey("ViceId");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.HasOne("Domain.Entities.CampeonatoEntity", null)
                        .WithMany("Partidas")
                        .HasForeignKey("CampeonatoEntityId");

                    b.HasOne("Domain.Entities.TimeEntity", "Time1")
                        .WithMany()
                        .HasForeignKey("Time1Id");

                    b.HasOne("Domain.Entities.TimeEntity", "Time2")
                        .WithMany()
                        .HasForeignKey("Time2Id");
                });

            modelBuilder.Entity("Domain.Entities.PontuacaoCampeonatoEntity", b =>
                {
                    b.HasOne("Domain.Entities.CampeonatoEntity", "Campeonato")
                        .WithMany()
                        .HasForeignKey("CampeonatoId");

                    b.HasOne("Domain.Entities.TimeEntity", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId");
                });
#pragma warning restore 612, 618
        }
    }
}
