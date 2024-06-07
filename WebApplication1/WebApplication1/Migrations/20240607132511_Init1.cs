using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(253), new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(260), new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(262) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(264), new DateTime(2024, 6, 7, 15, 25, 10, 648, DateTimeKind.Local).AddTicks(266) });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 3, 2, "xa", 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7095), new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7102), new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7106), new DateTime(2024, 6, 5, 21, 9, 59, 814, DateTimeKind.Local).AddTicks(7108) });
        }
    }
}
