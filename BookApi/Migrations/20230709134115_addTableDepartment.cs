using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApi.Migrations
{
    /// <inheritdoc />
    public partial class addTableDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Auther_AutherID",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "AutherID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Auther",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_DepartmentID",
                table: "Book",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Auther_AutherID",
                table: "Book",
                column: "AutherID",
                principalTable: "Auther",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Departments_DepartmentID",
                table: "Book",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Auther_AutherID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Departments_DepartmentID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Book_DepartmentID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Auther");

            migrationBuilder.AlterColumn<int>(
                name: "AutherID",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Auther_AutherID",
                table: "Book",
                column: "AutherID",
                principalTable: "Auther",
                principalColumn: "ID");
        }
    }
}
