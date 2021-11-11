using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeeFlat.Dictionaries.DataAccess.Migrations
{
    public partial class AddCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
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
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Created", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("764b2818-cf87-4823-86ec-50aace252e57"), new DateTime(2021, 11, 11, 17, 5, 55, 451, DateTimeKind.Local).AddTicks(976), false, "Россия" },
                    { new Guid("5df84f5b-5247-4a92-a714-d32cf2681664"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(3246), false, "Казахстан" },
                    { new Guid("f77584e5-6ddc-4a6e-b856-42d240754054"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(3266), false, "Украина" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Created", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("da1721b8-0cf8-4098-8e07-bed7b587a88a"), new Guid("764b2818-cf87-4823-86ec-50aace252e57"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(3523), false, "Москва" },
                    { new Guid("956efb42-ccb1-459f-a9a2-6981f5410c94"), new Guid("764b2818-cf87-4823-86ec-50aace252e57"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4064), false, "Санкт-Петербург" },
                    { new Guid("2dbdc4fe-bdcf-4b41-88c6-b88a503aa5a8"), new Guid("764b2818-cf87-4823-86ec-50aace252e57"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4073), false, "Волгоград" },
                    { new Guid("424f9307-8c17-4bc1-87b2-5629c2044a7a"), new Guid("5df84f5b-5247-4a92-a714-d32cf2681664"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4074), false, "Алматы" },
                    { new Guid("4669f20c-1bbe-41dd-b7d5-ebfbc6bdb97c"), new Guid("5df84f5b-5247-4a92-a714-d32cf2681664"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4076), false, "Караганда" },
                    { new Guid("6a1f5baa-ae40-474a-a0f8-975e8eecc650"), new Guid("5df84f5b-5247-4a92-a714-d32cf2681664"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4082), false, "Астана" },
                    { new Guid("fda27f30-7e52-4750-abcc-0dd919798918"), new Guid("f77584e5-6ddc-4a6e-b856-42d240754054"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4084), false, "Киев" },
                    { new Guid("859d0c88-c2b9-48d0-857a-80deb6a5e94f"), new Guid("f77584e5-6ddc-4a6e-b856-42d240754054"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4086), false, "Днепр" },
                    { new Guid("385b1ff3-2dc4-4fb8-907d-172a63292975"), new Guid("f77584e5-6ddc-4a6e-b856-42d240754054"), new DateTime(2021, 11, 11, 17, 5, 55, 452, DateTimeKind.Local).AddTicks(4130), false, "Одесса" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
