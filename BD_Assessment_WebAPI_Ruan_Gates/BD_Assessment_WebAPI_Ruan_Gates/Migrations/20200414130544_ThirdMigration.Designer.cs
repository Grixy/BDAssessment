﻿// <auto-generated />
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    [DbContext(typeof(BatchContext))]
    [Migration("20200414130544_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.Batch", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GrandTotal")
                        .HasColumnType("int");

                    b.Property<int>("NumbersPerBatch")
                        .HasColumnType("int");

                    b.Property<int>("TotalBatches")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchElement", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aggregate")
                        .HasColumnType("int");

                    b.Property<int>("NumbersRemaining")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.ToTable("BatchElements");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.NumberInBatch", b =>
                {
                    b.Property<int>("NumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("NumberId");

                    b.ToTable("BatchNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
