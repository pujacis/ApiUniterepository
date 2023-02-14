using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "TaskPerson");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "TaskPerson");

            migrationBuilder.DropColumn(
                name: "UploadFile",
                table: "TaskPerson");

            migrationBuilder.DropColumn(
                name: "contentType",
                table: "TaskPerson");

            migrationBuilder.AlterColumn<string>(
                name: "base64data",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TaskPerson");

            migrationBuilder.AlterColumn<string>(
                name: "base64data",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "TaskPerson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UploadFile",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contentType",
                table: "TaskPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
