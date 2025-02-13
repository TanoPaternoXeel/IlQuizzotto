using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlQuizzotto.Migrations
{
	/// <inheritdoc />
	public partial class DropMatch : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Session_Match_MatchId",
				table: "Session");

			migrationBuilder.DropIndex(
				name: "IX_Session_MatchId",
				table: "Session");

			migrationBuilder.DropColumn(
				name: "MatchId",
				table: "Session");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "MatchId",
				table: "Session",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.CreateIndex(
				name: "IX_Session_MatchId",
				table: "Session",
				column: "MatchId");

			migrationBuilder.AddForeignKey(
				name: "FK_Session_Match_MatchId",
				table: "Session",
				column: "MatchId",
				principalTable: "Match",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
