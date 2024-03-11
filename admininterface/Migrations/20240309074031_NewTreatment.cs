using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admininterface.Migrations
{
    /// <inheritdoc />
    public partial class NewTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TreatmentTime",
                table: "Treatments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentTime",
                table: "Treatments");
        }
    }
}
