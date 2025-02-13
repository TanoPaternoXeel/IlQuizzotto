using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlQuizzotto.Migrations
{
	/// <inheritdoc />
	public partial class AddedSessionMatchIdProperty : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "MatchId",
				table: "Session",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "MatchId",
				table: "Session");
		}
	}
}
