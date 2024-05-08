using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedServiceSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidToDate",
                table: "ServiceSubscriptions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "ServiceSubscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTime",
                table: "ServiceSubscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ServiceSubscriptions");

            migrationBuilder.DropColumn(
                name: "TransactionTime",
                table: "ServiceSubscriptions");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ValidToDate",
                table: "ServiceSubscriptions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
