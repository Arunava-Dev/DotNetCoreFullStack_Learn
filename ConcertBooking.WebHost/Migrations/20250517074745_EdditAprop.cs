using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertBooking.WebHost.Migrations
{
    /// <inheritdoc />
    public partial class EdditAprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBook",
                table: "Tickets",
                newName: "IsBooked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBooked",
                table: "Tickets",
                newName: "IsBook");
        }
    }
}
