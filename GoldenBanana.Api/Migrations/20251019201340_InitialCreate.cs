using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBanana.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HideoutMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HideoutMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hideouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HideoutMapId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PoeVersion = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HasMTX = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    TimesDownloaded = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hideouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hideouts_HideoutMaps_HideoutMapId",
                        column: x => x.HideoutMapId,
                        principalTable: "HideoutMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hideouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HideoutChangelogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HideoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    FileURL = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HideoutChangelogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HideoutChangelogEntries_Hideouts_HideoutId",
                        column: x => x.HideoutId,
                        principalTable: "Hideouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HideoutComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HideoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HideoutComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HideoutComments_Hideouts_HideoutId",
                        column: x => x.HideoutId,
                        principalTable: "Hideouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HideoutComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HideoutImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HideoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Alt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HideoutImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HideoutImages_Hideouts_HideoutId",
                        column: x => x.HideoutId,
                        principalTable: "Hideouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HideoutTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HideoutId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HideoutTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HideoutTags_Hideouts_HideoutId",
                        column: x => x.HideoutId,
                        principalTable: "Hideouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavoritedHideouts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HideoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoritedHideouts", x => new { x.UserId, x.HideoutId });
                    table.ForeignKey(
                        name: "FK_UserFavoritedHideouts_Hideouts_HideoutId",
                        column: x => x.HideoutId,
                        principalTable: "Hideouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoritedHideouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HideoutChangelogEntries_HideoutId",
                table: "HideoutChangelogEntries",
                column: "HideoutId");

            migrationBuilder.CreateIndex(
                name: "IX_HideoutComments_HideoutId",
                table: "HideoutComments",
                column: "HideoutId");

            migrationBuilder.CreateIndex(
                name: "IX_HideoutComments_UserId",
                table: "HideoutComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HideoutImages_HideoutId",
                table: "HideoutImages",
                column: "HideoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Hideouts_HideoutMapId",
                table: "Hideouts",
                column: "HideoutMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Hideouts_UserId",
                table: "Hideouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HideoutTags_HideoutId",
                table: "HideoutTags",
                column: "HideoutId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritedHideouts_HideoutId",
                table: "UserFavoritedHideouts",
                column: "HideoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HideoutChangelogEntries");

            migrationBuilder.DropTable(
                name: "HideoutComments");

            migrationBuilder.DropTable(
                name: "HideoutImages");

            migrationBuilder.DropTable(
                name: "HideoutTags");

            migrationBuilder.DropTable(
                name: "UserFavoritedHideouts");

            migrationBuilder.DropTable(
                name: "Hideouts");

            migrationBuilder.DropTable(
                name: "HideoutMaps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
