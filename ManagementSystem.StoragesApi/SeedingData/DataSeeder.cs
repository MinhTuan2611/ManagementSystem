using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;

namespace ManagementSystem.StoragesApi.SeedingData
{
    public class DataSeeder
    {
        public static void SeedData(StoragesDbContext context)
        {

            try
            {
                #region Init Animal Part RefCode
                if (!context.AnimalPartRefCodes.Any())
                {
                    List<AnimalPartRefCode> animalPartRefCodes = new List<AnimalPartRefCode>()
                {
                    new AnimalPartRefCode()
                    {
                        PartName = "Mũi",
                        RefCode = "001",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Nọng/má",
                        RefCode = "002",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Thủ/đầu",
                        RefCode = "003",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Tai",
                        RefCode = "004",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Cổ",
                        RefCode = "005",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Sườn vai",
                        RefCode = "006",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Thịt vai",
                        RefCode = "007",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Bắp giò",
                        RefCode = "008",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Dựng/Móng giò",
                        RefCode = "009",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Mỡ lưng",
                        RefCode = "010",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Cốt lết",
                        RefCode = "011",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Thăn",
                        RefCode = "012",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Sườn",
                        RefCode = "013",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Ba rọi",
                        RefCode = "014",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Thịt mông",
                        RefCode = "015",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Thịt đùi",
                        RefCode = "016",
                    },
                    new AnimalPartRefCode()
                    {
                        PartName = "Đuôi",
                        RefCode = "017",
                    },
                };
                    context.AnimalPartRefCodes.AddRange(animalPartRefCodes);
                    context.SaveChanges();
                }

                #endregion

                #region Init Category
                if (!context.Category.Any())
                {
                    List<Category> categories = new List<Category>()
                {
                    // Seeding Category Level 1
                    new Category()
                    {
                        CategoryName = "CÔNG CỤ DỤNG CỤ",
                        Description = "",
                        ParentId = 0,
                        CategoryRefCode = 1,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "HÀNG HOÁ",
                        Description = "",
                        ParentId = 0,
                        CategoryRefCode = 2,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "DỊCH VỤ",
                        Description = "",
                        ParentId = 0,
                        CategoryRefCode = 2,
                        Status = ActiveStatus.Active
                    },
                    // Seeding Category Level 2
                    new Category()
                    {
                        CategoryName = "TƯƠI SỐNG",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 21,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "THỰC PHẨM CÔNG NGHỆ",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 22,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "SỮA",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 23,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "NƯỚC UỐNG",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 24,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "ĐỒ UỐNG CÓ CỒN",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 25,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "HOÁ MỸ PHẨM",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 26,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "ĐỒ GIA DỤNG",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 27,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "ĐỒ CHƠI TRẺ EM",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 28,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "NHÃN HÀNG RIÊNG",
                        Description = "",
                        ParentId = 2,
                        CategoryRefCode = 29,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "THANH TOÁN ĐIỆN TỬ",
                        Description = "",
                        ParentId = 3,
                        CategoryRefCode = 31,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "CARD ĐIỆN THOẠI",
                        Description = "",
                        ParentId = 3,
                        CategoryRefCode = 32,
                        Status = ActiveStatus.Active
                    },

                    // Seeding Category Level 3
                    new Category()
                    {
                        CategoryName = "Thịt tươi Các Loại",
                        Description = "",
                        ParentId = 4,
                        CategoryRefCode = 211,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Hải Sản",
                        Description = "",
                        ParentId = 4,
                        CategoryRefCode = 212,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Rau Củ",
                        Description = "",
                        ParentId = 4,
                        CategoryRefCode = 213,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Trái Cây",
                        Description = "",
                        ParentId = 4,
                        CategoryRefCode = 214,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Thực Phẩm Đông Mát",
                        Description = "",
                        ParentId = 4,
                        CategoryRefCode = 215,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
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
                        CategoryName = "Trà, Cà Phê",
                        Description = "",
                        ParentId = 5,
                        CategoryRefCode = 223,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Gia Vị",
                        Description = "Các loại gia vị, nuoc tuong, nước mắm, đường muối…",
                        ParentId = 5,
                        CategoryRefCode = 224,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ Ăn Vặt",
                        Description = "",
                        ParentId = 5,
                        CategoryRefCode = 225,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Gạo",
                        Description = "",
                        ParentId = 5,
                        CategoryRefCode = 226,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Kem",
                        Description = "",
                        ParentId = 5,
                        CategoryRefCode = 227,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Sữa thanh trùng",
                        Description = "",
                        ParentId = 6,
                        CategoryRefCode = 231,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Sữa tươi",
                        Description = "",
                        ParentId = 6,
                        CategoryRefCode = 232,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Sữa đặc",
                        Description = "",
                        ParentId = 6,
                        CategoryRefCode = 233,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Sữa bột",
                        Description = "",
                        ParentId = 6,
                        CategoryRefCode = 234,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Bia",
                        Description = "",
                        ParentId = 8,
                        CategoryRefCode = 251,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Rượu",
                        Description = "",
                        ParentId = 8,
                        CategoryRefCode = 252,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Tã, giấy các loại",
                        Description = "",
                        ParentId = 9,
                        CategoryRefCode = 261,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Chăm sóc cá nhân",
                        Description = "Kem đánh răng, bàn chải đánh răng, các loại mỹ phẩm",
                        ParentId = 9,
                        CategoryRefCode = 262,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Hoá phẩm tẩy rửa",
                        Description = "",
                        ParentId = 9,
                        CategoryRefCode = 263,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ điện gia dụng",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 271,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ vệ sinh nhà cửa",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 272,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng phòng ăn",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 273,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng cho bếp",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 274,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng nhà tắm",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 275,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng phòng khách",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 276,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng phòng ngủ",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 277,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng tiện lợi",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 278,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng văn phòng",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 279,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng văn phòng",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 279,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ dùng khác",
                        Description = "",
                        ParentId = 10,
                        CategoryRefCode = 280,
                        Status = ActiveStatus.Active
                    },
                    // Seeding Category Level 4
                    new Category()
                    {
                        CategoryName = "Gia súc",
                        Description = "",
                        ParentId = 15,
                        CategoryRefCode = 2111,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Gia cầm",
                        Description = "",
                        ParentId = 15,
                        CategoryRefCode = 2112,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Cá",
                        Description = "",
                        ParentId = 16,
                        CategoryRefCode = 2121,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Nhuyễn thể",
                        Description = "",
                        ParentId = 16,
                        CategoryRefCode = 2122,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Mực",
                        Description = "",
                        ParentId = 16,
                        CategoryRefCode = 2123,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Mực",
                        Description = "",
                        ParentId = 16,
                        CategoryRefCode = 2123,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Rau",
                        Description = "",
                        ParentId = 17,
                        CategoryRefCode = 2131,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Củ",
                        Description = "",
                        ParentId = 17,
                        CategoryRefCode = 2132,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Trái cây nội địa",
                        Description = "",
                        ParentId = 18,
                        CategoryRefCode = 2141,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Trái cây nhập khẩu",
                        Description = "",
                        ParentId = 18,
                        CategoryRefCode = 2142,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Đồ ngoại nhập",
                        Description = "",
                        ParentId = 19,
                        CategoryRefCode = 2151,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Thực phẩm khô",
                        Description = "Cá khô, khô mực",
                        ParentId = 19,
                        CategoryRefCode = 2151,
                        Status = ActiveStatus.Active
                    },

                    // Level 5
                    new Category()
                    {
                        CategoryName = "Bò",
                        Description = "",
                        ParentId = 47,
                        CategoryRefCode = 21111,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Heo",
                        Description = "",
                        ParentId = 47,
                        CategoryRefCode = 21112,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Dê",
                        Description = "",
                        ParentId = 47,
                        CategoryRefCode = 21113,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Nai",
                        Description = "",
                        ParentId = 47,
                        CategoryRefCode = 21114,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Gà",
                        Description = "",
                        ParentId = 48,
                        CategoryRefCode = 21121,
                        Status = ActiveStatus.Active
                    },
                    new Category()
                    {
                        CategoryName = "Vịt",
                        Description = "",
                        ParentId = 48,
                        CategoryRefCode = 21122,
                        Status = ActiveStatus.Active
                    }
                };

                    context.Category.AddRange(categories);
                    context.SaveChanges();
                }
                #endregion

                #region Init Revenue Groups
                if (!context.RevenueGroups.Any())
                {
                    var revenueGroups = new List<RevenueGroup>()
                {
                    new RevenueGroup()
                    {
                        RevenueGroupName = "Sản Phẩm Tươi Sống"
                    },
                    new RevenueGroup()
                    {
                        RevenueGroupName = "Sản Phẩm Khô"
                    }
                };

                    context.RevenueGroups.AddRange(revenueGroups);
                    context.SaveChanges();
                }
                #endregion
            }
            catch
            {

            }
        }
    }
}
