using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

                migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Description", "Price", "Active", "Created", "CreatedBy" },
                values: new object[,]
                {
                    { 1, "Hamburguesa clasica" , "Jugosa hamburguesa de carne de res 100% grillada, servida con queso cheddar derretido, lechuga fresca, tomate en rodajas, cebolla, pepinillos y un toque de nuestra salsa especial en un pan suave con semillas de sésamo.", 5.99m, true, DateTime.UtcNow, "admin" },
                    { 2, "Pollo Crujiente Wrap", "Tortilla de harina rellena con tiras de pechuga de pollo crujiente, mezcla de lechugas, tomates picados, queso cheddar y aderezo ranch, enrollado y listo para disfrutar en cualquier momento.", 19.99m, true, DateTime.UtcNow, "admin" },
                    // Añadir más productos según necesario
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
