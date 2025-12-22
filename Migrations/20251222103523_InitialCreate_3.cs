using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuction.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is_lottery",
                table: "Gifts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Is_lottery",
                table: "Gifts",
                newName: "Is_lotorry");
        }
    }
}
