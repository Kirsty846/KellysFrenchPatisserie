using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatisserieAPI.Migrations
{
    public partial class productType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CelebrationCake_FlavourId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlavourId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fudge_FlavourId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fudge_Size",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IcingFlavour",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tiers",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flavour",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavour", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CelebrationCake_FlavourId",
                table: "Products",
                column: "CelebrationCake_FlavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FlavourId",
                table: "Products",
                column: "FlavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fudge_FlavourId",
                table: "Products",
                column: "Fudge_FlavourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Flavour_CelebrationCake_FlavourId",
                table: "Products",
                column: "CelebrationCake_FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Flavour_FlavourId",
                table: "Products",
                column: "FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Flavour_Fudge_FlavourId",
                table: "Products",
                column: "Fudge_FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            UpdateOrInsertFlavour(migrationBuilder, name: "White Chocolate", code: "WC");
            UpdateOrInsertFlavour(migrationBuilder, name: "Milk Chocolate", code: "MC");
            UpdateOrInsertFlavour(migrationBuilder, name: "Dark Chocolate", code: "DC");
            UpdateOrInsertFlavour(migrationBuilder, name: "Orange", code: "OR");
            UpdateOrInsertFlavour(migrationBuilder, name: "Vanilla", code: "VA");
            UpdateOrInsertFlavour(migrationBuilder, name: "Strawberry", code: "SB");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Flavour_CelebrationCake_FlavourId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Flavour_FlavourId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Flavour_Fudge_FlavourId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Flavour");

            migrationBuilder.DropIndex(
                name: "IX_Products_CelebrationCake_FlavourId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FlavourId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Fudge_FlavourId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CelebrationCake_FlavourId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FlavourId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fudge_FlavourId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fudge_Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IcingFlavour",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tiers",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");
        }

        private void UpdateOrInsertFlavour(MigrationBuilder migrationBuilder, string name, string code)
        {
            migrationBuilder.Sql(@$"IF(EXISTS(SELECT 'X' FROM Flavour WHERE Id = '{code}'))
                                        UPDATE Flavour 
                                        SET Name = '{name}'
                                        WHERE Id = '{code}'
                                    ELSE
                                        INSERT INTO Flavour(Id, Name) VALUES ('{code}', '{name}')");
        }

    }
}
