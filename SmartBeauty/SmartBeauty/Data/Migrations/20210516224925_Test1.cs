using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBeauty.Data.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.SalonID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSpot",
                columns: table => new
                {
                    TimeSpotID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeSpotName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSpot", x => x.TimeSpotID);
                });

            migrationBuilder.CreateTable(
                name: "LastAppointment",
                columns: table => new
                {
                    LastAppointmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastAppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceUsing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastAppointment", x => x.LastAppointmentID);
                    table.ForeignKey(
                        name: "FK_LastAppointment_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalonID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeSpotID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_Salon_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salon",
                        principalColumn: "SalonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_TimeSpot_TimeSpotID",
                        column: x => x.TimeSpotID,
                        principalTable: "TimeSpot",
                        principalColumn: "TimeSpotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalonID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeSpotID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Salon_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salon",
                        principalColumn: "SalonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_TimeSpot_TimeSpotID",
                        column: x => x.TimeSpotID,
                        principalTable: "TimeSpot",
                        principalColumn: "TimeSpotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientID",
                table: "Appointment",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SalonID",
                table: "Appointment",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_StaffID",
                table: "Appointment",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TimeSpotID",
                table: "Appointment",
                column: "TimeSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_LastAppointment_ClientID",
                table: "LastAppointment",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SalonID",
                table: "Staff",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_TimeSpotID",
                table: "Staff",
                column: "TimeSpotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "LastAppointment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "TimeSpot");
        }
    }
}
