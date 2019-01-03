﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REstate.Engine.Repositories.EntityFrameworkCore;

namespace REstate.EntityFrameworkCore.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(REstateDbContext))]
    [Migration("20190103114758_shrink-keys")]
    partial class ShrinkKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.Machine", b =>
                {
                    b.Property<string>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<long>("CommitNumber")
                        .IsConcurrencyToken();

                    b.Property<byte[]>("SchematicBytes");

                    b.Property<string>("StateJson")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.MetadataEntry", b =>
                {
                    b.Property<string>("MachineId")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<string>("Key")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<string>("Value");

                    b.HasKey("MachineId", "Key");

                    b.ToTable("MetadataEntries");
                });

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.Schematic", b =>
                {
                    b.Property<string>("SchematicName")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false);

                    b.Property<byte[]>("SchematicBytes");

                    b.HasKey("SchematicName");

                    b.ToTable("Schematics");
                });

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.StateBagEntry", b =>
                {
                    b.Property<string>("MachineId")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<string>("Key")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<string>("Value");

                    b.HasKey("MachineId", "Key");

                    b.ToTable("StateBagEntries");
                });

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.MetadataEntry", b =>
                {
                    b.HasOne("REstate.Engine.Repositories.EntityFrameworkCore.Machine")
                        .WithMany("MetadataEntries")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("REstate.Engine.Repositories.EntityFrameworkCore.StateBagEntry", b =>
                {
                    b.HasOne("REstate.Engine.Repositories.EntityFrameworkCore.Machine")
                        .WithMany("StateBagEntries")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
