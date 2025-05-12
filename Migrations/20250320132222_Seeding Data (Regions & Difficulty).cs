using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataRegionsDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Regions",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Difficuties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2e39cca1-41f5-449b-a95b-17ffdfacae64"), "Mediam" },
                    { new Guid("3767c8ab-dbe7-4790-a8c7-898f8e04f988"), "Easy" },
                    { new Guid("da192823-7fe1-4a8c-bd47-b3aa6a8214ea"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("093dd075-bbe3-43d9-ac27-b0668c8b81c8"), "W", "West", "https://dummyimage.com/600x400/000/fff" },
                    { new Guid("0eb161a0-47b4-4d3f-8f83-8565cb7d1d78"), "E", "East", "https://dummyimage.com/600x400/000/fff" },
                    { new Guid("6548231d-41ca-47a6-80b5-f7ab46fe175c"), "S", "South", "https://dummyimage.com/600x400/000/fff" },
                    { new Guid("ee7ecbba-c423-4272-946c-444b1073a1a0"), "N", "North", "https://dummyimage.com/600x400/000/fff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficuties",
                keyColumn: "Id",
                keyValue: new Guid("2e39cca1-41f5-449b-a95b-17ffdfacae64"));

            migrationBuilder.DeleteData(
                table: "Difficuties",
                keyColumn: "Id",
                keyValue: new Guid("3767c8ab-dbe7-4790-a8c7-898f8e04f988"));

            migrationBuilder.DeleteData(
                table: "Difficuties",
                keyColumn: "Id",
                keyValue: new Guid("da192823-7fe1-4a8c-bd47-b3aa6a8214ea"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("093dd075-bbe3-43d9-ac27-b0668c8b81c8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0eb161a0-47b4-4d3f-8f83-8565cb7d1d78"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6548231d-41ca-47a6-80b5-f7ab46fe175c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ee7ecbba-c423-4272-946c-444b1073a1a0"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Regions",
                newName: "id");
        }
    }
}
