using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DAL.EF.Migrations
{
    public partial class Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkInCocktails_Cocktails_CocktailId",
                table: "DrinkInCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInCocktails_Cocktails_CocktailId",
                table: "IngredientInCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Cocktails_CocktailId",
                table: "Steps");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkInCocktails_Cocktails_CocktailId",
                table: "DrinkInCocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInCocktails_Cocktails_CocktailId",
                table: "IngredientInCocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Cocktails_CocktailId",
                table: "Steps",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkInCocktails_Cocktails_CocktailId",
                table: "DrinkInCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInCocktails_Cocktails_CocktailId",
                table: "IngredientInCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Cocktails_CocktailId",
                table: "Steps");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkInCocktails_Cocktails_CocktailId",
                table: "DrinkInCocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInCocktails_Cocktails_CocktailId",
                table: "IngredientInCocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Cocktails_CocktailId",
                table: "Steps",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
