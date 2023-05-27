using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMR_Service.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionDescription = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    ServiceProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderName = table.Column<string>(maxLength: 50, nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.ServiceProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Tune",
                columns: table => new
                {
                    TuneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tune", x => x.TuneID);
                });

            migrationBuilder.CreateTable(
                name: "FunctionGroup",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    FunctionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionGroup", x => new { x.GroupID, x.FunctionID });
                    table.ForeignKey(
                        name: "FK_FunctionGroup_Function_FunctionID",
                        column: x => x.FunctionID,
                        principalTable: "Function",
                        principalColumn: "FunctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionGroup_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 500, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    AvatarLink = table.Column<string>(nullable: true),
                    ServiceProviderID = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 10, DateTimeKind.Local).AddTicks(2090)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_ServiceProvider_ServiceProviderID",
                        column: x => x.ServiceProviderID,
                        principalTable: "ServiceProvider",
                        principalColumn: "ServiceProviderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderID = table.Column<int>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 500, nullable: false),
                    ServiceDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_ServiceProvider_ServiceProviderID",
                        column: x => x.ServiceProviderID,
                        principalTable: "ServiceProvider",
                        principalColumn: "ServiceProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 500, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    AvatarLink = table.Column<string>(nullable: true),
                    TuneID = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 30, DateTimeKind.Local).AddTicks(3489)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Disturb = table.Column<bool>(nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Tune_TuneID",
                        column: x => x.TuneID,
                        principalTable: "Tune",
                        principalColumn: "TuneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDescription = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: true),
                    ContentFB = table.Column<string>(nullable: true),
                    StarRate = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 19, DateTimeKind.Local).AddTicks(3536)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_Feedback_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifyContent = table.Column<string>(maxLength: 200, nullable: false),
                    Time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 21, DateTimeKind.Local).AddTicks(3554)),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notification_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceContract",
                columns: table => new
                {
                    ServiceContractID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceContract", x => x.ServiceContractID);
                    table.ForeignKey(
                        name: "FK_ServiceContract_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceContract_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupID, x.UserID });
                    table.ForeignKey(
                        name: "FK_GroupUser_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFunction",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    FunctionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFunction", x => new { x.UserID, x.FunctionID });
                    table.ForeignKey(
                        name: "FK_UserFunction_Function_FunctionID",
                        column: x => x.FunctionID,
                        principalTable: "Function",
                        principalColumn: "FunctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFunction_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceContractID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true),
                    PaymentID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    Expiry = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true),
                    NameOnCard = table.Column<string>(nullable: true),
                    TransferTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 27, DateTimeKind.Local).AddTicks(3483)),
                    Days = table.Column<int>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_ServiceContract_ServiceContractID",
                        column: x => x.ServiceContractID,
                        principalTable: "ServiceContract",
                        principalColumn: "ServiceContractID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TuneID",
                table: "Customer",
                column: "TuneID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ServiceProviderID",
                table: "Employee",
                column: "ServiceProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CustomerID",
                table: "Feedback",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ServiceID",
                table: "Feedback",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionGroup_FunctionID",
                table: "FunctionGroup",
                column: "FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserID",
                table: "GroupUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CustomerID",
                table: "Notification",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceProviderID",
                table: "Service",
                column: "ServiceProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceContract_CustomerID",
                table: "ServiceContract",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceContract_ServiceID",
                table: "ServiceContract",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerID",
                table: "Transaction",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PaymentID",
                table: "Transaction",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ServiceContractID",
                table: "Transaction",
                column: "ServiceContractID");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeID",
                table: "User",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFunction_FunctionID",
                table: "UserFunction",
                column: "FunctionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "FunctionGroup");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserFunction");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ServiceContract");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Tune");

            migrationBuilder.DropTable(
                name: "ServiceProvider");
        }
    }
}
