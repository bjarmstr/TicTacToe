﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.Repositories.Repositories;

namespace TicTacToe.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<int>>("Gameboard")
                        .HasColumnType("integer[]");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StartPlayer")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Winner")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.GamePlayer", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.HasOne("TicTacToe.Models.Entities.Player", null)
                        .WithMany("Games")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.GamePlayer", b =>
                {
                    b.HasOne("TicTacToe.Models.Entities.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicTacToe.Models.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.Navigation("GamePlayers");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
