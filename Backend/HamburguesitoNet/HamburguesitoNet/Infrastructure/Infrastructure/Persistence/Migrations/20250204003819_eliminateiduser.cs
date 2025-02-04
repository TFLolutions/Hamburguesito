using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class eliminateiduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UserTenants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "UserTenants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
