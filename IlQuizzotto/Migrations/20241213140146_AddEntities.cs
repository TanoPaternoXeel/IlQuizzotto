using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlQuizzotto.Migrations
{
	/// <inheritdoc />
	public partial class AddEntities : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Match",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Match", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Player",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					NickName = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Player", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Question",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Question", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Answer",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Correct = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Answer", x => x.Id);
					table.ForeignKey(
						name: "FK_Answer_Question_QuestionId",
						column: x => x.QuestionId,
						principalTable: "Question",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Session",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Session", x => x.Id);
					table.ForeignKey(
						name: "FK_Session_Answer_AnswerId",
						column: x => x.AnswerId,
						principalTable: "Answer",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Session_Match_MatchId",
						column: x => x.MatchId,
						principalTable: "Match",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Session_Player_PlayerId",
						column: x => x.PlayerId,
						principalTable: "Player",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Answer_QuestionId",
				table: "Answer",
				column: "QuestionId");

			migrationBuilder.CreateIndex(
				name: "IX_Session_AnswerId",
				table: "Session",
				column: "AnswerId");

			migrationBuilder.CreateIndex(
				name: "IX_Session_MatchId",
				table: "Session",
				column: "MatchId");

			migrationBuilder.CreateIndex(
				name: "IX_Session_PlayerId",
				table: "Session",
				column: "PlayerId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Session");

			migrationBuilder.DropTable(
				name: "Answer");

			migrationBuilder.DropTable(
				name: "Match");

			migrationBuilder.DropTable(
				name: "Player");

			migrationBuilder.DropTable(
				name: "Question");
		}
	}
}
