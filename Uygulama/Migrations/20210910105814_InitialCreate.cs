using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uygulama.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Durum",
                columns: table => new
                {
                    DurumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurumAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durum", x => x.DurumId);
                });

            migrationBuilder.CreateTable(
                name: "Emlak",
                columns: table => new
                {
                    EmlakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmlakAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yetkili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emlak", x => x.EmlakId);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    SehirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.SehirId);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    TipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.TipId);
                    table.ForeignKey(
                        name: "FK_Tip_Durum_DurumId",
                        column: x => x.DurumId,
                        principalTable: "Durum",
                        principalColumn: "DurumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmlakId = table.Column<int>(type: "int", nullable: true),
                    MustKategori = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriId);
                    table.ForeignKey(
                        name: "FK_Musteriler_Emlak_EmlakId",
                        column: x => x.EmlakId,
                        principalTable: "Emlak",
                        principalColumn: "EmlakId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    SehirlerSehirId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_Ilceler_Sehirler_SehirlerSehirId",
                        column: x => x.SehirlerSehirId,
                        principalTable: "Sehirler",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    MahalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MahalleAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlceId = table.Column<int>(type: "int", nullable: false),
                    IlcelerIlceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.MahalleId);
                    table.ForeignKey(
                        name: "FK_Mahalleler_Ilceler_IlcelerIlceId",
                        column: x => x.IlcelerIlceId,
                        principalTable: "Ilceler",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfoy",
                columns: table => new
                {
                    PortfoyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdaSayisi = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isınma = table.Column<int>(type: "int", nullable: false),
                    Kat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false),
                    MahalleId = table.Column<int>(type: "int", nullable: false),
                    MahallelerMahalleId = table.Column<int>(type: "int", nullable: true),
                    DurumId = table.Column<int>(type: "int", nullable: false),
                    TipId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfoy", x => x.PortfoyId);
                    table.ForeignKey(
                        name: "FK_Portfoy_Mahalleler_MahallelerMahalleId",
                        column: x => x.MahallelerMahalleId,
                        principalTable: "Mahalleler",
                        principalColumn: "MahalleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Portfoy_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfoy_Tip_TipId",
                        column: x => x.TipId,
                        principalTable: "Tip",
                        principalColumn: "TipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IlanResim",
                columns: table => new
                {
                    IlanResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfoyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlanResim", x => x.IlanResimId);
                    table.ForeignKey(
                        name: "FK_IlanResim_Portfoy_PortfoyId",
                        column: x => x.PortfoyId,
                        principalTable: "Portfoy",
                        principalColumn: "PortfoyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IlanResim_PortfoyId",
                table: "IlanResim",
                column: "PortfoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_SehirlerSehirId",
                table: "Ilceler",
                column: "SehirlerSehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Mahalleler_IlcelerIlceId",
                table: "Mahalleler",
                column: "IlcelerIlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_EmlakId",
                table: "Musteriler",
                column: "EmlakId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfoy_MahallelerMahalleId",
                table: "Portfoy",
                column: "MahallelerMahalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfoy_MusteriId",
                table: "Portfoy",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfoy_TipId",
                table: "Portfoy",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Tip_DurumId",
                table: "Tip",
                column: "DurumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IlanResim");

            migrationBuilder.DropTable(
                name: "Portfoy");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "Emlak");

            migrationBuilder.DropTable(
                name: "Durum");

            migrationBuilder.DropTable(
                name: "Sehirler");
        }
    }
}
