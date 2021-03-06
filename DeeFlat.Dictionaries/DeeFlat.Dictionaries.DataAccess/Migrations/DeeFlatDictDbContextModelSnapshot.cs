// <auto-generated />
using System;
using DeeFlat.Dictionaries.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeeFlat.Dictionaries.DataAccess.Migrations
{
    [DbContext(typeof(DeeFlatDictDbContext))]
    partial class DeeFlatDictDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DeeFlat.Dictionaries.Core.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c710a641-9de3-4846-8916-298b03e63999"),
                            CountryId = new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4054),
                            IsDeleted = false,
                            Name = "Москва"
                        },
                        new
                        {
                            Id = new Guid("41b4846b-5b27-4437-b501-06a0e1354652"),
                            CountryId = new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4608),
                            IsDeleted = false,
                            Name = "Санкт-Петербург"
                        },
                        new
                        {
                            Id = new Guid("9eda76d7-fc5d-4741-ada9-a51944fb9ab1"),
                            CountryId = new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4652),
                            IsDeleted = false,
                            Name = "Волгоград"
                        },
                        new
                        {
                            Id = new Guid("795321fb-2708-4695-8148-fd75e07e5292"),
                            CountryId = new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4657),
                            IsDeleted = false,
                            Name = "Алматы"
                        },
                        new
                        {
                            Id = new Guid("25156735-f68d-4d70-87d0-1028d080cdcd"),
                            CountryId = new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4659),
                            IsDeleted = false,
                            Name = "Караганда"
                        },
                        new
                        {
                            Id = new Guid("bc3cc28d-1627-4f77-98ea-55fdee8745b0"),
                            CountryId = new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4665),
                            IsDeleted = false,
                            Name = "Астана"
                        },
                        new
                        {
                            Id = new Guid("3ada4f6a-0773-4b4e-bee5-4b8fe01e20e8"),
                            CountryId = new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4667),
                            IsDeleted = false,
                            Name = "Киев"
                        },
                        new
                        {
                            Id = new Guid("070f5927-f28a-482d-b3e7-61f36c5699b4"),
                            CountryId = new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4668),
                            IsDeleted = false,
                            Name = "Днепр"
                        },
                        new
                        {
                            Id = new Guid("f8395499-507c-4fdc-9321-5b016287b490"),
                            CountryId = new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4670),
                            IsDeleted = false,
                            Name = "Одесса"
                        });
                });

            modelBuilder.Entity("DeeFlat.Dictionaries.Core.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 405, DateTimeKind.Local).AddTicks(1265),
                            IsDeleted = false,
                            Name = "Россия"
                        },
                        new
                        {
                            Id = new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(3772),
                            IsDeleted = false,
                            Name = "Казахстан"
                        },
                        new
                        {
                            Id = new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(3793),
                            IsDeleted = false,
                            Name = "Украина"
                        });
                });

            modelBuilder.Entity("DeeFlat.Dictionaries.Core.Domain.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac052f47-2523-4c0c-af5b-670eea49fc62"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5013),
                            IsDeleted = false,
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("f5f8ec83-2f5b-4369-98af-73e6ed41916a"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5261),
                            IsDeleted = false,
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = new Guid("3114b7aa-dd6d-43cc-8cd5-dde16413bf6d"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5269),
                            IsDeleted = false,
                            Name = "HTML"
                        },
                        new
                        {
                            Id = new Guid("d514a61d-11b4-4082-a099-7c0fe13fff28"),
                            Created = new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5271),
                            IsDeleted = false,
                            Name = ".NET"
                        });
                });

            modelBuilder.Entity("DeeFlat.Dictionaries.Core.Domain.City", b =>
                {
                    b.HasOne("DeeFlat.Dictionaries.Core.Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DeeFlat.Dictionaries.Core.Domain.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
