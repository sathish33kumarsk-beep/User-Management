using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User_Management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_Roletypes",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roletypes", x => x.RoleID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_Login_Userdetails",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Middlename = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Login_Userdetails", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Tbl_Login_Userdetails_Tbl_Roletypes_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tbl_Roletypes",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tbl_Roletypes",
                columns: new[] { "RoleID", "Active", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 1, "Manager" },
                    { 3, 1, "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Login_Userdetails_RoleID",
                table: "Tbl_Login_Userdetails",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Login_Userdetails");

            migrationBuilder.DropTable(
                name: "Tbl_Roletypes");
        }
    }
}
