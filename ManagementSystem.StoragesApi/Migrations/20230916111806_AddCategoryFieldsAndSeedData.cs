using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddCategoryFieldsAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryRefCode",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "CategoryRefCode", "CreateBy", "CreateDate", "Description", "ModifyBy", "ModifyDate", "ParentId", "Status" },
                values: new object[,]
                {
                    { 1, "CÔNG CỤ DỤNG CỤ", 1, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1008), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1020), 0, 0 },
                    { 2, "HÀNG HOÁ", 2, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1026), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1026), 0, 0 },
                    { 3, "DỊCH VỤ", 2, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1028), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1028), 0, 0 },
                    { 4, "TƯƠI SỐNG", 21, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1029), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1029), 2, 0 },
                    { 5, "THỰC PHẨM CÔNG NGHỆ", 22, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1030), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1030), 2, 0 },
                    { 6, "SỮA", 23, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1033), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1033), 2, 0 },
                    { 7, "NƯỚC UỐNG", 24, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1034), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1034), 2, 0 },
                    { 8, "ĐỒ UỐNG CÓ CỒN", 25, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1035), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1036), 2, 0 },
                    { 9, "HOÁ MỸ PHẨM", 26, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1036), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1037), 2, 0 },
                    { 10, "ĐỒ GIA DỤNG", 27, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1038), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1039), 2, 0 },
                    { 11, "ĐỒ CHƠI TRẺ EM", 28, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1039), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1040), 2, 0 },
                    { 12, "NHÃN HÀNG RIÊNG", 29, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1040), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1041), 2, 0 },
                    { 13, "THANH TOÁN ĐIỆN TỬ", 31, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1042), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1042), 3, 0 },
                    { 14, "CARD ĐIỆN THOẠI", 32, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1043), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1043), 3, 0 },
                    { 15, "Thịt tươi Các Loại", 211, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1044), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1044), 4, 0 },
                    { 16, "Hải Sản", 212, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1045), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1045), 4, 0 },
                    { 17, "Rau Củ", 213, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1046), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1046), 4, 0 },
                    { 18, "Trái Cây", 214, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1048), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1048), 4, 0 },
                    { 19, "Thực Phẩm Đông Mát", 215, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1049), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1049), 4, 0 },
                    { 20, "Bánh Kẹo", 221, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1050), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1050), 5, 0 },
                    { 21, "Mì/bún/miến (noodle)", 222, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1051), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1051), 5, 0 },
                    { 22, "Trà, Cà Phê", 223, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1052), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1053), 5, 0 },
                    { 23, "Gia Vị", 224, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1053), "Các loại gia vị, nuoc tuong, nước mắm, đường muối…", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1054), 5, 0 },
                    { 24, "Đồ Ăn Vặt", 225, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1055), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1055), 5, 0 },
                    { 25, "Gạo", 226, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1056), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1056), 5, 0 },
                    { 26, "Kem", 227, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1057), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1057), 5, 0 },
                    { 27, "Sữa thanh trùng", 231, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1058), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1058), 6, 0 },
                    { 28, "Sữa tươi", 232, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1059), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1059), 6, 0 },
                    { 29, "Sữa đặc", 233, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1060), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1060), 6, 0 },
                    { 30, "Sữa bột", 234, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1061), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1061), 6, 0 },
                    { 31, "Bia", 251, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1062), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1063), 8, 0 },
                    { 32, "Rượu", 252, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1063), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1064), 8, 0 },
                    { 33, "Tã, giấy các loại", 261, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1064), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1065), 9, 0 },
                    { 34, "Chăm sóc cá nhân", 262, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1067), "Kem đánh răng, bàn chải đánh răng, các loại mỹ phẩm", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1067), 9, 0 },
                    { 35, "Hoá phẩm tẩy rửa", 263, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1068), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1068), 9, 0 },
                    { 36, "Đồ điện gia dụng", 271, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1069), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1069), 10, 0 },
                    { 37, "Đồ vệ sinh nhà cửa", 272, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1070), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1070), 10, 0 },
                    { 38, "Đồ dùng phòng ăn", 273, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1071), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1071), 10, 0 },
                    { 39, "Đồ dùng cho bếp", 274, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1072), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1073), 10, 0 },
                    { 40, "Đồ dùng nhà tắm", 275, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1073), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1074), 10, 0 },
                    { 41, "Đồ dùng phòng khách", 276, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1074), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1075), 10, 0 },
                    { 42, "Đồ dùng phòng ngủ", 277, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1076), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1076), 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "CategoryRefCode", "CreateBy", "CreateDate", "Description", "ModifyBy", "ModifyDate", "ParentId", "Status" },
                values: new object[,]
                {
                    { 43, "Đồ dùng tiện lợi", 278, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1077), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1077), 10, 0 },
                    { 44, "Đồ dùng văn phòng", 279, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1078), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1078), 10, 0 },
                    { 45, "Đồ dùng văn phòng", 279, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1079), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1079), 10, 0 },
                    { 46, "Đồ dùng khác", 280, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1080), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1080), 10, 0 },
                    { 47, "Gia súc", 2111, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1081), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1081), 15, 0 },
                    { 48, "Gia cầm", 2112, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1082), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1082), 15, 0 },
                    { 49, "Cá", 2121, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1083), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1083), 16, 0 },
                    { 50, "Nhuyễn thể", 2122, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1084), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1085), 16, 0 },
                    { 51, "Mực", 2123, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1085), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1086), 16, 0 },
                    { 52, "Mực", 2123, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1087), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1087), 16, 0 },
                    { 53, "Rau", 2131, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1088), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1089), 17, 0 },
                    { 54, "Củ", 2132, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1089), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1090), 17, 0 },
                    { 55, "Trái cây nội địa", 2141, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1090), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1091), 18, 0 },
                    { 56, "Trái cây nhập khẩu", 2142, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1091), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1092), 18, 0 },
                    { 57, "Đồ ngoại nhập", 2151, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1093), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1093), 19, 0 },
                    { 58, "Thực phẩm khô", 2151, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1094), "Cá khô, khô mực", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1094), 19, 0 },
                    { 59, "Bò", 21111, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1095), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1095), 47, 0 },
                    { 60, "Heo", 21112, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1122), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1124), 47, 0 },
                    { 61, "Dê", 21113, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1125), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1125), 47, 0 },
                    { 62, "Nai", 21114, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1126), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1127), 47, 0 },
                    { 63, "Gà", 21121, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1127), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1128), 48, 0 },
                    { 64, "Vịt", 21122, null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1128), "", null, new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1129), 48, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64);

            migrationBuilder.DropColumn(
                name: "CategoryRefCode",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Category");
        }
    }
}
