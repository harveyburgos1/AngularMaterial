using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.EFCore.Infra.Migrations
{
    public partial class AddedTrainingTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    TrainingID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.TrainingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
