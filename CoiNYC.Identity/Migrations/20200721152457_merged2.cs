using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class merged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    coiNCYRole = table.Column<string>(nullable: true),
                    SecuredFilesRole = table.Column<string>(nullable: true),
                    AccountExpires = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FidoStoredCredential",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    UserId = table.Column<byte[]>(nullable: true),
                    PublicKey = table.Column<byte[]>(nullable: true),
                    UserHandle = table.Column<byte[]>(nullable: true),
                    SignatureCounter = table.Column<long>(nullable: false),
                    CredType = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    AaGuid = table.Column<Guid>(nullable: false),
                    DescriptorJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FidoStoredCredential", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "SettingContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Long = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    WorkingHours = table.Column<string>(nullable: true),
                    ContactText = table.Column<string>(nullable: true),
                    BuyingAgreement = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmtpHost = table.Column<string>(nullable: true),
                    SmtpPort = table.Column<string>(nullable: true),
                    SmtpUserName = table.Column<string>(nullable: true),
                    SmtpPassword = table.Column<string>(nullable: true),
                    OrderEmail = table.Column<string>(nullable: true),
                    NotificationEmail = table.Column<string>(nullable: true),
                    RegisterEmailTemplate = table.Column<string>(nullable: true),
                    OrderEmailTemplate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingEmails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingSocials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(nullable: true),
                    Google = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingSocials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowcasePositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcasePositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Showcases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ShowcasePositionId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    GroupByCategory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showcases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showcases_ShowcasePositions_ShowcasePositionId",
                        column: x => x.ShowcasePositionId,
                        principalTable: "ShowcasePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowcaseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ShowcaseId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowcaseCategory_Showcases_ShowcaseId",
                        column: x => x.ShowcaseId,
                        principalTable: "Showcases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowcaseCollection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(nullable: false),
                    ShowcaseId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowcaseCollection_Showcases_ShowcaseId",
                        column: x => x.ShowcaseId,
                        principalTable: "Showcases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowcaseProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ShowcaseId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowcaseProduct_Showcases_ShowcaseId",
                        column: x => x.ShowcaseId,
                        principalTable: "Showcases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountExpires", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "IsAdmin", "IsEnabled", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecuredFilesRole", "SecurityStamp", "TwoFactorEnabled", "UserName", "coiNCYRole" },
                values: new object[] { "1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0d5cf288-82c4-4295-93d7-4dbe7acd03ab", "AliceSmith@email.com", true, null, false, false, false, null, "ALICESMITH@EMAIL.COM", "ALICE", "AQAAAAEAACcQAAAAELVd2kivcPO6kvYfZijOZu+r2kGKq1mZPbjY/nNuHhrGw+lrdSdQX93M3errVQQ31A==", null, false, null, "e712b824-7d4c-4245-a37b-e6d2a5d87f36", false, "alice", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountExpires", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "IsAdmin", "IsEnabled", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecuredFilesRole", "SecurityStamp", "TwoFactorEnabled", "UserName", "coiNCYRole" },
                values: new object[] { "2", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ade4950a-a025-4fb7-b4e3-4ded3e0cf95f", "BobSmith@email.com", true, null, false, false, false, null, "BOBSMITH@EMAIL.COM", "BOB", "AQAAAAEAACcQAAAAEIoLorua5WZz6D73fBkCxGuVnE29VEMVqd49p1Wo10lKIsJ0f2oAJCf8D4/+HkuDpw==", null, false, null, "e35d5640-f46b-4371-b138-112fbeab0555", false, "bob", null });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "name", "Alice Smith", "1" },
                    { 2, "given_name", "Alice", "1" },
                    { 3, "family_name", "Smith", "1" },
                    { 4, "email", "AliceSmith@email.com", "1" },
                    { 5, "website", "http://alice.com", "1" },
                    { 11, "email_verified", "True", "1" },
                    { 13, "address", "{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", "1" },
                    { 15, "location", "somewhere", "1" },
                    { 6, "name", "Bob Smith", "2" },
                    { 7, "given_name", "Bob", "2" },
                    { 8, "family_name", "Smith", "2" },
                    { 9, "email", "BobSmith@email.com", "2" },
                    { 10, "website", "http://bob.com", "2" },
                    { 12, "email_verified", "True", "2" },
                    { 14, "address", "{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseCategory_ShowcaseId",
                table: "ShowcaseCategory",
                column: "ShowcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseCollection_ShowcaseId",
                table: "ShowcaseCollection",
                column: "ShowcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseProduct_ShowcaseId",
                table: "ShowcaseProduct",
                column: "ShowcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Showcases_ShowcasePositionId",
                table: "Showcases",
                column: "ShowcasePositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "FidoStoredCredential");

            migrationBuilder.DropTable(
                name: "SettingContacts");

            migrationBuilder.DropTable(
                name: "SettingEmails");

            migrationBuilder.DropTable(
                name: "SettingSocials");

            migrationBuilder.DropTable(
                name: "ShowcaseCategory");

            migrationBuilder.DropTable(
                name: "ShowcaseCollection");

            migrationBuilder.DropTable(
                name: "ShowcaseProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Showcases");

            migrationBuilder.DropTable(
                name: "ShowcasePositions");
        }
    }
}
