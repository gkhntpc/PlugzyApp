using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugzy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateOtpEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Otps",
                newName: "isActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Otps",
                newName: "Status");
        }
    }
}
