using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StyleSphere.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE tbl_Favorites ADD CONSTRAINT PK_tbl_Favorites PRIMARY KEY CLUSTERED (FavoriteID)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Favorites",
                table: "tbl_Favorites");
        }
    }
}
