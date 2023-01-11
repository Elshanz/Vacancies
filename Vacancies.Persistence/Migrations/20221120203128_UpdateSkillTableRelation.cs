using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacancies.Persistence.Migrations
{
    public partial class UpdateSkillTableRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skills_curriculum_vitaes_curriculum_vitae_id",
                table: "skills");

            migrationBuilder.DropForeignKey(
                name: "fk_skills_vacancies_vacancy_id",
                table: "skills");

            migrationBuilder.DropIndex(
                name: "ix_skills_curriculum_vitae_id",
                table: "skills");

            migrationBuilder.DropIndex(
                name: "ix_skills_vacancy_id",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "curriculum_vitae_id",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "vacancy_id",
                table: "skills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "curriculum_vitae_id",
                table: "skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vacancy_id",
                table: "skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_skills_curriculum_vitae_id",
                table: "skills",
                column: "curriculum_vitae_id");

            migrationBuilder.CreateIndex(
                name: "ix_skills_vacancy_id",
                table: "skills",
                column: "vacancy_id");

            migrationBuilder.AddForeignKey(
                name: "fk_skills_curriculum_vitaes_curriculum_vitae_id",
                table: "skills",
                column: "curriculum_vitae_id",
                principalTable: "curriculum_vitaes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_skills_vacancies_vacancy_id",
                table: "skills",
                column: "vacancy_id",
                principalTable: "vacancies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
