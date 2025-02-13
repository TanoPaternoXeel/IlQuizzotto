using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlQuizzotto.Migrations
{
	/// <inheritdoc />
	public partial class ChagngeSession : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Session_Player_PlayerId",
				table: "Session");

			migrationBuilder.DropIndex(
				name: "IX_Session_PlayerId",
				table: "Session");

			migrationBuilder.DropColumn(
				name: "PlayerId",
				table: "Session");

			migrationBuilder.AddColumn<string>(
				name: "PlayerNickName",
				table: "Session",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlayerNickName",
				table: "Session");

			migrationBuilder.AddColumn<Guid>(
				name: "PlayerId",
				table: "Session",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.CreateIndex(
				name: "IX_Session_PlayerId",
				table: "Session",
				column: "PlayerId");

			migrationBuilder.AddForeignKey(
				name: "FK_Session_Player_PlayerId",
				table: "Session",
				column: "PlayerId",
				principalTable: "Player",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
