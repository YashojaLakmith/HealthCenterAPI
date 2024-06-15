using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticTypes",
                columns: table => new
                {
                    DiagnosticTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiagnosticTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosticTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDiagnosys = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticTypes", x => x.DiagnosticTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Gender = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Gender);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    MedicineType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.MedicineType);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethod = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethod);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMedicines",
                columns: table => new
                {
                    MeasurementUnit = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMedicines", x => x.MeasurementUnit);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBase",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBase", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeBase_Genders_Gender1",
                        column: x => x.Gender1,
                        principalTable: "Genders",
                        principalColumn: "Gender",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientBase",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    IndependentPatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBase", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_PatientBase_Genders_Gender1",
                        column: x => x.Gender1,
                        principalTable: "Genders",
                        principalColumn: "Gender");
                    table.ForeignKey(
                        name: "FK_PatientBase_PatientBase_IndependentPatientId",
                        column: x => x.IndependentPatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicineType1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitOfMeasurementMeasurementUnit = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineTypes_MedicineType1",
                        column: x => x.MedicineType1,
                        principalTable: "MedicineTypes",
                        principalColumn: "MedicineType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_UnitsOfMedicines_UnitOfMeasurementMeasurementUnit",
                        column: x => x.UnitOfMeasurementMeasurementUnit,
                        principalTable: "UnitsOfMedicines",
                        principalColumn: "MeasurementUnit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminRolesSysAdmin",
                columns: table => new
                {
                    AdminsEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRolesSysAdmin", x => new { x.AdminsEmployeeId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_AdminRolesSysAdmin_AdminRoles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "AdminRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminRolesSysAdmin_EmployeeBase_AdminsEmployeeId",
                        column: x => x.AdminsEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReports",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Resource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuerEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_MedicalReports_EmployeeBase_IssuerEmployeeId",
                        column: x => x.IssuerEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerVisit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SessionDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    SessionCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_EmployeeBase_DoctorEmployeeId",
                        column: x => x.DoctorEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Rooms_Room1",
                        column: x => x.Room1,
                        principalTable: "Rooms",
                        principalColumn: "Room");
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Credentials_EmployeeBase_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credentials_PatientBase_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidPatientPatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceIssuerEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentModePaymentMethod = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInvoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_PaymentInvoices_EmployeeBase_InvoiceIssuerEmployeeId",
                        column: x => x.InvoiceIssuerEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_PaymentInvoices_PatientBase_PaidPatientPatientId",
                        column: x => x.PaidPatientPatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_PaymentInvoices_PaymentMethods_PaymentModePaymentMethod",
                        column: x => x.PaymentModePaymentMethod,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedDoctorEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IssuedPharmacistEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescriptions_EmployeeBase_IssuedDoctorEmployeeId",
                        column: x => x.IssuedDoctorEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_EmployeeBase_IssuedPharmacistEmployeeId",
                        column: x => x.IssuedPharmacistEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Prescriptions_PatientBase_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    QueryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepliedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderPatientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.QueryId);
                    table.ForeignKey(
                        name: "FK_Queries_PatientBase_SenderPatientId",
                        column: x => x.SenderPatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticRequests",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestedDoctorEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicalReportReportId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_DiagnosticRequests_DiagnosticTypes_DiagnosticTypeId",
                        column: x => x.DiagnosticTypeId,
                        principalTable: "DiagnosticTypes",
                        principalColumn: "DiagnosticTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosticRequests_EmployeeBase_RequestedDoctorEmployeeId",
                        column: x => x.RequestedDoctorEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_DiagnosticRequests_MedicalReports_MedicalReportReportId",
                        column: x => x.MedicalReportReportId,
                        principalTable: "MedicalReports",
                        principalColumn: "ReportId");
                    table.ForeignKey(
                        name: "FK_DiagnosticRequests_PatientBase_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentState = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientBase_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentInvoiceInvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BillIssuedByEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_EmployeeBase_BillIssuedByEmployeeId",
                        column: x => x.BillIssuedByEmployeeId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_PatientBase_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientBase",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_PaymentInvoices_PaymentInvoiceInvoiceId",
                        column: x => x.PaymentInvoiceInvoiceId,
                        principalTable: "PaymentInvoices",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.CreateTable(
                name: "PrescribedMedicines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Units = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrescriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribedMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescribedMedicines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRolesSysAdmin_RolesRoleId",
                table: "AdminRolesSysAdmin",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SessionId",
                table: "Appointments",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillIssuedByEmployeeId",
                table: "Bills",
                column: "BillIssuedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientId",
                table: "Bills",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentInvoiceInvoiceId",
                table: "Bills",
                column: "PaymentInvoiceInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_EmployeeId",
                table: "Credentials",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_PatientId",
                table: "Credentials",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticRequests_DiagnosticTypeId",
                table: "DiagnosticRequests",
                column: "DiagnosticTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticRequests_MedicalReportReportId",
                table: "DiagnosticRequests",
                column: "MedicalReportReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticRequests_PatientId",
                table: "DiagnosticRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticRequests_RequestedDoctorEmployeeId",
                table: "DiagnosticRequests",
                column: "RequestedDoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBase_Gender1",
                table: "EmployeeBase",
                column: "Gender1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_IssuerEmployeeId",
                table: "MedicalReports",
                column: "IssuerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineType1",
                table: "Medicines",
                column: "MedicineType1");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UnitOfMeasurementMeasurementUnit",
                table: "Medicines",
                column: "UnitOfMeasurementMeasurementUnit");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBase_Gender1",
                table: "PatientBase",
                column: "Gender1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBase_IndependentPatientId",
                table: "PatientBase",
                column: "IndependentPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInvoices_InvoiceIssuerEmployeeId",
                table: "PaymentInvoices",
                column: "InvoiceIssuerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInvoices_PaidPatientPatientId",
                table: "PaymentInvoices",
                column: "PaidPatientPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInvoices_PaymentModePaymentMethod",
                table: "PaymentInvoices",
                column: "PaymentModePaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_MedicineId",
                table: "PrescribedMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_PrescriptionId",
                table: "PrescribedMedicines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IssuedDoctorEmployeeId",
                table: "Prescriptions",
                column: "IssuedDoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IssuedPharmacistEmployeeId",
                table: "Prescriptions",
                column: "IssuedPharmacistEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_SenderPatientId",
                table: "Queries",
                column: "SenderPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_DoctorEmployeeId",
                table: "Sessions",
                column: "DoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Room1",
                table: "Sessions",
                column: "Room1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRolesSysAdmin");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "DiagnosticRequests");

            migrationBuilder.DropTable(
                name: "PrescribedMedicines");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "PaymentInvoices");

            migrationBuilder.DropTable(
                name: "DiagnosticTypes");

            migrationBuilder.DropTable(
                name: "MedicalReports");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DropTable(
                name: "UnitsOfMedicines");

            migrationBuilder.DropTable(
                name: "EmployeeBase");

            migrationBuilder.DropTable(
                name: "PatientBase");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
