using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GammingCenter.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableSlots",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SlotDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSlots", x => x.SlotId);
                });

            migrationBuilder.CreateTable(
                name: "BookingTypes",
                columns: table => new
                {
                    BookingTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTypes", x => x.BookingTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayersNo = table.Column<int>(type: "int", nullable: false),
                    CompetitionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DevicesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.CompetitionId);
                    table.ForeignKey(
                        name: "FK_Competition_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingDevices",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HourlyPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDevices", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_GamingDevices_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamingDevices_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GamingDeviceId = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    BookingTypeId = table.Column<int>(type: "int", nullable: false),
                    AvailableSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AvailableSlots_AvailableSlotId",
                        column: x => x.AvailableSlotId,
                        principalTable: "AvailableSlots",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingTypes_BookingTypeId",
                        column: x => x.BookingTypeId,
                        principalTable: "BookingTypes",
                        principalColumn: "BookingTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_GamingDevices_GamingDeviceId",
                        column: x => x.GamingDeviceId,
                        principalTable: "GamingDevices",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visitorId = table.Column<int>(type: "int", nullable: false),
                    deviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_GamingDevices_deviceId",
                        column: x => x.deviceId,
                        principalTable: "GamingDevices",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Visitors_visitorId",
                        column: x => x.visitorId,
                        principalTable: "Visitors",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    paymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    paymentStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    bookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AvailableSlotId",
                table: "Bookings",
                column: "AvailableSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingTypeId",
                table: "Bookings",
                column: "BookingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GamingDeviceId",
                table: "Bookings",
                column: "GamingDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VisitorId",
                table: "Bookings",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_RoomId",
                table: "Competition",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDevices_CategoryId",
                table: "GamingDevices",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDevices_RoomId",
                table: "GamingDevices",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_bookingId",
                table: "Payments",
                column: "bookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_deviceId",
                table: "Reviews",
                column: "deviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_visitorId",
                table: "Reviews",
                column: "visitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AvailableSlots");

            migrationBuilder.DropTable(
                name: "BookingTypes");

            migrationBuilder.DropTable(
                name: "GamingDevices");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
