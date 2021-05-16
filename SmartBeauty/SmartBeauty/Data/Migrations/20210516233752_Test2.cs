using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "ServiceID",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceID",
                table: "Appointment",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_ServiceID",
                table: "Appointment",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_ServiceID",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
