using Microsoft.EntityFrameworkCore.Migrations;

namespace DohunKim.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_Authors_AuthorName",
                table: "Occupations");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Authors_Authors_AuthorName",
                table: "Project_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Authors_Projects_ProjectName",
                table: "Project_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Languages_Languages_LanguageName",
                table: "Project_Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Languages_Projects_ProjectName",
                table: "Project_Languages");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project_Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Project_Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project_Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Project_Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Occupations",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_Authors_AuthorName",
                table: "Occupations",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Authors_Authors_AuthorName",
                table: "Project_Authors",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Authors_Projects_ProjectName",
                table: "Project_Authors",
                column: "ProjectName",
                principalTable: "Projects",
                principalColumn: "ProjectName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Languages_Languages_LanguageName",
                table: "Project_Languages",
                column: "LanguageName",
                principalTable: "Languages",
                principalColumn: "LanguageName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Languages_Projects_ProjectName",
                table: "Project_Languages",
                column: "ProjectName",
                principalTable: "Projects",
                principalColumn: "ProjectName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_Authors_AuthorName",
                table: "Occupations");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Authors_Authors_AuthorName",
                table: "Project_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Authors_Projects_ProjectName",
                table: "Project_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Languages_Languages_LanguageName",
                table: "Project_Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Languages_Projects_ProjectName",
                table: "Project_Languages");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project_Languages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Project_Languages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project_Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Project_Authors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Occupations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_Authors_AuthorName",
                table: "Occupations",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Authors_Authors_AuthorName",
                table: "Project_Authors",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Authors_Projects_ProjectName",
                table: "Project_Authors",
                column: "ProjectName",
                principalTable: "Projects",
                principalColumn: "ProjectName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Languages_Languages_LanguageName",
                table: "Project_Languages",
                column: "LanguageName",
                principalTable: "Languages",
                principalColumn: "LanguageName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Languages_Projects_ProjectName",
                table: "Project_Languages",
                column: "ProjectName",
                principalTable: "Projects",
                principalColumn: "ProjectName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
