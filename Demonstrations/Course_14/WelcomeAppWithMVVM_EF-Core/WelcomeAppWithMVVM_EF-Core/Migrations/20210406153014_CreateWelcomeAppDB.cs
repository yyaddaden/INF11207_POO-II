using Microsoft.EntityFrameworkCore.Migrations;

namespace WelcomeAppWithMVVM_EF_Core.Migrations
{
    public partial class CreateWelcomeAppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Greetings",
                columns: table => new
                {
                    GreetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greetings", x => x.GreetingId);
                    table.ForeignKey(
                        name: "FK_Greetings_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Title" },
                values: new object[,]
                {
                    { 1, "Étudiant" },
                    { 2, "Ingénieur" },
                    { 3, "Professeur" },
                    { 4, "Directeur" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Greetings_JobId",
                table: "Greetings",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Greetings");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
