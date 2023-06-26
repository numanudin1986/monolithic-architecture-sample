using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentApp.DataAccess.Migrations
{
    public partial class addcolcreateddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDated",
                table: "AgentRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDated",
                table: "AgentRecords");
        }
    }
}
