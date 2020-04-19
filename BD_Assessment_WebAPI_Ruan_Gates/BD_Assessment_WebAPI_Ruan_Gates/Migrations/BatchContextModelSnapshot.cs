﻿// <auto-generated />
using System;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    [DbContext(typeof(BatchContext))]
    partial class BatchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("BatchAndNumberInputRequestId")
                        .HasColumnType("int");

                    b.Property<int>("GrandTotal")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("BatchAndNumberInputRequestId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchAndNumberInput", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Batches")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Numbers")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("RequestId");

                    b.ToTable("BatchAndNumberInput");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchElement", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aggregate")
                        .HasColumnType("int");

                    b.Property<int>("BatchNumber")
                        .HasColumnType("int");

                    b.Property<int?>("BatchRequestId")
                        .HasColumnType("int");

                    b.Property<int>("NumbersRemaining")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.HasIndex("BatchRequestId");

                    b.ToTable("BatchElements");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.NumberInBatch", b =>
                {
                    b.Property<int>("NumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchElementBatchId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("NumberId");

                    b.HasIndex("BatchElementBatchId");

                    b.ToTable("BatchNumbers");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.Batch", b =>
                {
                    b.HasOne("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchAndNumberInput", "BatchAndNumberInput")
                        .WithMany()
                        .HasForeignKey("BatchAndNumberInputRequestId");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchElement", b =>
                {
                    b.HasOne("BD_Assessment_WebAPI_Ruan_Gates.Models.Batch", "Batch")
                        .WithMany("BatchElements")
                        .HasForeignKey("BatchRequestId");
                });

            modelBuilder.Entity("BD_Assessment_WebAPI_Ruan_Gates.Models.NumberInBatch", b =>
                {
                    b.HasOne("BD_Assessment_WebAPI_Ruan_Gates.Models.BatchElement", "BatchElement")
                        .WithMany("NumbersInBatch")
                        .HasForeignKey("BatchElementBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
