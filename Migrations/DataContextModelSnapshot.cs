﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bitacora.API.Data;

namespace bitacora.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("bitacora.API.Models.Actividad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("horaFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("horaInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("bitacora.API.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bitacora.API.Models.Actividad", b =>
                {
                    b.HasOne("bitacora.API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}