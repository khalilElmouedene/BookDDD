using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDDD.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreStatut = table.Column<int>(type: "int", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    DateRemove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlPicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    DateRemove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    PostStatuts = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalMembre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreSignaledId = table.Column<int>(type: "int", nullable: false),
                    MembreWhoSignalId = table.Column<int>(type: "int", nullable: false),
                    CommenterSignaler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalMembre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalMembre_Membres_MembreSignaledId",
                        column: x => x.MembreSignaledId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignalMembre_Membres_MembreWhoSignalId",
                        column: x => x.MembreWhoSignalId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    DateRemove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CommentaireStatut = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostSignal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    MembreSignalId = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSignal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostSignal_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostSignal_Membres_MembreSignalId",
                        column: x => x.MembreSignalId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostSignal_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeReact = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reacts_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reacts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentSignal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    MembreSignalId = table.Column<int>(type: "int", nullable: false),
                    MembreSignalCommentId = table.Column<int>(type: "int", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentSignal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentSignal_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentSignal_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentSignal_Membres_MembreSignalCommentId",
                        column: x => x.MembreSignalCommentId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MembreId",
                table: "Comments",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentSignal_CommentsId",
                table: "CommentSignal",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentSignal_MembreId",
                table: "CommentSignal",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentSignal_MembreSignalCommentId",
                table: "CommentSignal",
                column: "MembreSignalCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MembreId",
                table: "Posts",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSignal_MembreId",
                table: "PostSignal",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSignal_MembreSignalId",
                table: "PostSignal",
                column: "MembreSignalId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSignal_PostId",
                table: "PostSignal",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_MembreId",
                table: "Reacts",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_PostId",
                table: "Reacts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalMembre_MembreSignaledId",
                table: "SignalMembre",
                column: "MembreSignaledId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalMembre_MembreWhoSignalId",
                table: "SignalMembre",
                column: "MembreWhoSignalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentSignal");

            migrationBuilder.DropTable(
                name: "PostSignal");

            migrationBuilder.DropTable(
                name: "Reacts");

            migrationBuilder.DropTable(
                name: "SignalMembre");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Membres");
        }
    }
}
