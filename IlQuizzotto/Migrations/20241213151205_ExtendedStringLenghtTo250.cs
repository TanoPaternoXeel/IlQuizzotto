using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlQuizzotto.Migrations
{
	/// <inheritdoc />
	public partial class ExtendedStringLenghtTo250 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Question",
				type: "nvarchar(250)",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<string>(
				name: "NickName",
				table: "Player",
				type: "nvarchar(250)",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Match",
				type: "nvarchar(250)",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Answer",
				type: "nvarchar(250)",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Question",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(250)",
				oldMaxLength: 250);

			migrationBuilder.AlterColumn<string>(
				name: "NickName",
				table: "Player",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(250)",
				oldMaxLength: 250);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Match",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(250)",
				oldMaxLength: 250);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Answer",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(250)",
				oldMaxLength: 250);
		}
	}
}
