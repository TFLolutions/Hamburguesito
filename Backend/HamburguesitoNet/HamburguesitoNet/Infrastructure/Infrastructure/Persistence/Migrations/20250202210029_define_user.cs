using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class define_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTenants",
                table: "UserTenants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTenants",
                table: "UserTenants",
                columns: new[] { "UserId", "IdTenant" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTenants",
                table: "UserTenants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTenants",
                table: "UserTenants",
                columns: new[] { "IdUser", "IdTenant" });
        }
    }
}
