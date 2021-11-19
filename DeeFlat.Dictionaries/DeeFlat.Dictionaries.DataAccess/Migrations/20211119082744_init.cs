using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeeFlat.Dictionaries.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Created", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"), new DateTime(2021, 11, 19, 14, 27, 44, 405, DateTimeKind.Local).AddTicks(1265), false, "Россия" },
                    { new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(3772), false, "Казахстан" },
                    { new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(3793), false, "Украина" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Created", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("ac052f47-2523-4c0c-af5b-670eea49fc62"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5013), false, "C#" },
                    { new Guid("f5f8ec83-2f5b-4369-98af-73e6ed41916a"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5261), false, "JavaScript" },
                    { new Guid("3114b7aa-dd6d-43cc-8cd5-dde16413bf6d"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5269), false, "HTML" },
                    { new Guid("d514a61d-11b4-4082-a099-7c0fe13fff28"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(5271), false, ".NET" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Created", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("c710a641-9de3-4846-8916-298b03e63999"), new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4054), false, "Москва" },
                    { new Guid("41b4846b-5b27-4437-b501-06a0e1354652"), new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4608), false, "Санкт-Петербург" },
                    { new Guid("9eda76d7-fc5d-4741-ada9-a51944fb9ab1"), new Guid("4e739bb8-86c2-4757-8241-94338bea2a2f"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4652), false, "Волгоград" },
                    { new Guid("795321fb-2708-4695-8148-fd75e07e5292"), new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4657), false, "Алматы" },
                    { new Guid("25156735-f68d-4d70-87d0-1028d080cdcd"), new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4659), false, "Караганда" },
                    { new Guid("bc3cc28d-1627-4f77-98ea-55fdee8745b0"), new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4665), false, "Астана" },
                    { new Guid("3ada4f6a-0773-4b4e-bee5-4b8fe01e20e8"), new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4667), false, "Киев" },
                    { new Guid("070f5927-f28a-482d-b3e7-61f36c5699b4"), new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4668), false, "Днепр" },
                    { new Guid("f8395499-507c-4fdc-9321-5b016287b490"), new Guid("2b7fad61-2265-4efd-8b3a-86b95b1e51fd"), new DateTime(2021, 11, 19, 14, 27, 44, 406, DateTimeKind.Local).AddTicks(4670), false, "Одесса" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
