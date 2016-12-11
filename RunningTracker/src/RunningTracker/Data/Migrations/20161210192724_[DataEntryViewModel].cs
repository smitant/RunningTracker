using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RunningTracker.Data.Migrations
{
    public partial class DataEntryViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heartrate",
                table: "DataEntryViewModel");

            migrationBuilder.AddColumn<int>(
                name: "HeartrateAvg",
                table: "DataEntryViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeartrateMax",
                table: "DataEntryViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeartrateMin",
                table: "DataEntryViewModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeartrateAvg",
                table: "DataEntryViewModel");

            migrationBuilder.DropColumn(
                name: "HeartrateMax",
                table: "DataEntryViewModel");

            migrationBuilder.DropColumn(
                name: "HeartrateMin",
                table: "DataEntryViewModel");

            migrationBuilder.AddColumn<int>(
                name: "Heartrate",
                table: "DataEntryViewModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
