using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMomentum.Services.ClassesAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixedClassModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassesCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassWeekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    WeekId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWeekday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassWeekday_Classess_Id",
                        column: x => x.Id,
                        principalTable: "Classess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassWeekday_Weekday_Id",
                        column: x => x.Id,
                        principalTable: "Weekday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classess_ClassesCode",
                table: "Classess",
                column: "ClassesCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassFeedback");

            migrationBuilder.DropTable(
                name: "ClassWeekday");

            migrationBuilder.DropTable(
                name: "Classess");

            migrationBuilder.DropTable(
                name: "Weekday");
        }
    }
}
