using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Controllers.SeedingData
{
    public class CategoriesSeeding
    {

        public static List<Category> GetCategoies()
        {
            List<Category> categories = new List<Category>()
            {
                // Seeding Category Level 1
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "CÔNG CỤ DỤNG CỤ",
                    Description = "",
                    ParentId = 0,
                    CategoryRefCode = 1,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "HÀNG HOÁ",
                    Description = "",
                    ParentId = 0,
                    CategoryRefCode = 2,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "DỊCH VỤ",
                    Description = "",
                    ParentId = 0,
                    CategoryRefCode = 2,
                    Status = ActiveStatus.Active
                },
                // Seeding Category Level 2
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "TƯƠI SỐNG",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 21,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "THỰC PHẨM CÔNG NGHỆ",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 22,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "SỮA",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 23,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "NƯỚC UỐNG",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 24,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 8,
                    CategoryName = "ĐỒ UỐNG CÓ CỒN",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 25,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 9,
                    CategoryName = "HOÁ MỸ PHẨM",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 26,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 10,
                    CategoryName = "ĐỒ GIA DỤNG",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 27,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 11,
                    CategoryName = "ĐỒ CHƠI TRẺ EM",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 28,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 12,
                    CategoryName = "NHÃN HÀNG RIÊNG",
                    Description = "",
                    ParentId = 2,
                    CategoryRefCode = 29,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 13,
                    CategoryName = "THANH TOÁN ĐIỆN TỬ",
                    Description = "",
                    ParentId = 3,
                    CategoryRefCode = 31,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 14,
                    CategoryName = "CARD ĐIỆN THOẠI",
                    Description = "",
                    ParentId = 3,
                    CategoryRefCode = 32,
                    Status = ActiveStatus.Active
                },

                // Seeding Category Level 3
                new Category()
                {
                    CategoryId = 15,
                    CategoryName = "Thịt tươi Các Loại",
                    Description = "",
                    ParentId = 4,
                    CategoryRefCode = 211,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 16,
                    CategoryName = "Hải Sản",
                    Description = "",
                    ParentId = 4,
                    CategoryRefCode = 212,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 17,
                    CategoryName = "Rau Củ",
                    Description = "",
                    ParentId = 4,
                    CategoryRefCode = 213,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 18,
                    CategoryName = "Trái Cây",
                    Description = "",
                    ParentId = 4,
                    CategoryRefCode = 214,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 19,
                    CategoryName = "Thực Phẩm Đông Mát",
                    Description = "",
                    ParentId = 4,
                    CategoryRefCode = 215,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 20,
                    CategoryName = "Bánh Kẹo",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 221,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 21,
                    CategoryName = "Mì/bún/miến (noodle)",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 222,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 22,
                    CategoryName = "Trà, Cà Phê",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 223,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 23,
                    CategoryName = "Gia Vị",
                    Description = "Các loại gia vị, nuoc tuong, nước mắm, đường muối…",
                    ParentId = 5,
                    CategoryRefCode = 224,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 24,
                    CategoryName = "Đồ Ăn Vặt",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 225,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 25,
                    CategoryName = "Gạo",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 226,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 26,
                    CategoryName = "Kem",
                    Description = "",
                    ParentId = 5,
                    CategoryRefCode = 227,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 27,
                    CategoryName = "Sữa thanh trùng",
                    Description = "",
                    ParentId = 6,
                    CategoryRefCode = 231,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 28,
                    CategoryName = "Sữa tươi",
                    Description = "",
                    ParentId = 6,
                    CategoryRefCode = 232,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 29,
                    CategoryName = "Sữa đặc",
                    Description = "",
                    ParentId = 6,
                    CategoryRefCode = 233,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 30,
                    CategoryName = "Sữa bột",
                    Description = "",
                    ParentId = 6,
                    CategoryRefCode = 234,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 31,
                    CategoryName = "Bia",
                    Description = "",
                    ParentId = 8,
                    CategoryRefCode = 251,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 32,
                    CategoryName = "Rượu",
                    Description = "",
                    ParentId = 8,
                    CategoryRefCode = 252,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 33,
                    CategoryName = "Tã, giấy các loại",
                    Description = "",
                    ParentId = 9,
                    CategoryRefCode = 261,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 34,
                    CategoryName = "Chăm sóc cá nhân",
                    Description = "Kem đánh răng, bàn chải đánh răng, các loại mỹ phẩm",
                    ParentId = 9,
                    CategoryRefCode = 262,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 35,
                    CategoryName = "Hoá phẩm tẩy rửa",
                    Description = "",
                    ParentId = 9,
                    CategoryRefCode = 263,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 36,
                    CategoryName = "Đồ điện gia dụng",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 271,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 37,
                    CategoryName = "Đồ vệ sinh nhà cửa",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 272,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 38,
                    CategoryName = "Đồ dùng phòng ăn",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 273,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 39,
                    CategoryName = "Đồ dùng cho bếp",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 274,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 40,
                    CategoryName = "Đồ dùng nhà tắm",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 275,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 41,
                    CategoryName = "Đồ dùng phòng khách",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 276,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 42,
                    CategoryName = "Đồ dùng phòng ngủ",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 277,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 43,
                    CategoryName = "Đồ dùng tiện lợi",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 278,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 44,
                    CategoryName = "Đồ dùng văn phòng",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 279,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 45,
                    CategoryName = "Đồ dùng văn phòng",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 279,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 46,
                    CategoryName = "Đồ dùng khác",
                    Description = "",
                    ParentId = 10,
                    CategoryRefCode = 280,
                    Status = ActiveStatus.Active
                },
                // Seeding Category Level 4
                new Category()
                {
                    CategoryId = 47,
                    CategoryName = "Gia súc",
                    Description = "",
                    ParentId = 15,
                    CategoryRefCode = 2111,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 48,
                    CategoryName = "Gia cầm",
                    Description = "",
                    ParentId = 15,
                    CategoryRefCode = 2112,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 49,
                    CategoryName = "Cá",
                    Description = "",
                    ParentId = 16,
                    CategoryRefCode = 2121,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 50,
                    CategoryName = "Nhuyễn thể",
                    Description = "",
                    ParentId = 16,
                    CategoryRefCode = 2122,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 51,
                    CategoryName = "Mực",
                    Description = "",
                    ParentId = 16,
                    CategoryRefCode = 2123,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 52,
                    CategoryName = "Mực",
                    Description = "",
                    ParentId = 16,
                    CategoryRefCode = 2123,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 53,
                    CategoryName = "Rau",
                    Description = "",
                    ParentId = 17,
                    CategoryRefCode = 2131,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 54,
                    CategoryName = "Củ",
                    Description = "",
                    ParentId = 17,
                    CategoryRefCode = 2132,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 55,
                    CategoryName = "Trái cây nội địa",
                    Description = "",
                    ParentId = 18,
                    CategoryRefCode = 2141,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 56,
                    CategoryName = "Trái cây nhập khẩu",
                    Description = "",
                    ParentId = 18,
                    CategoryRefCode = 2142,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 57,
                    CategoryName = "Đồ ngoại nhập",
                    Description = "",
                    ParentId = 19,
                    CategoryRefCode = 2151,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 58,
                    CategoryName = "Thực phẩm khô",
                    Description = "Cá khô, khô mực",
                    ParentId = 19,
                    CategoryRefCode = 2151,
                    Status = ActiveStatus.Active
                },

                // Level 5
                new Category()
                {
                    CategoryId = 59,
                    CategoryName = "Bò",
                    Description = "",
                    ParentId = 47,
                    CategoryRefCode = 21111,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 60,
                    CategoryName = "Heo",
                    Description = "",
                    ParentId = 47,
                    CategoryRefCode = 21112,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 61,
                    CategoryName = "Dê",
                    Description = "",
                    ParentId = 47,
                    CategoryRefCode = 21113,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 62,
                    CategoryName = "Nai",
                    Description = "",
                    ParentId = 47,
                    CategoryRefCode = 21114,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 63,
                    CategoryName = "Gà",
                    Description = "",
                    ParentId = 48,
                    CategoryRefCode = 21121,
                    Status = ActiveStatus.Active
                },
                new Category()
                {
                    CategoryId = 64,
                    CategoryName = "Vịt",
                    Description = "",
                    ParentId = 48,
                    CategoryRefCode = 21122,
                    Status = ActiveStatus.Active
                },
            };

            return categories;
        }
    }
}
