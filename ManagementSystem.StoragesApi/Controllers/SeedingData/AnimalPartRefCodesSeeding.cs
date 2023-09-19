using ManagementSystem.Common.Entities;

namespace ManagementSystem.StoragesApi.Controllers.SeedingData
{
    public class AnimalPartRefCodesSeeding
    {
        public static List<AnimalPartRefCode> GenerateAnimalPartRefCodes()
        {
            List<AnimalPartRefCode> animalPartRefCodes = new List<AnimalPartRefCode>()
            {
                new AnimalPartRefCode()
                {
                    AnimalPartId = 1,
                    PartName = "Mũi",
                    RefCode = "001",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 2,
                    PartName = "Nọng/má",
                    RefCode = "002",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 3,
                    PartName = "Thủ/đầu",
                    RefCode = "003",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 4,
                    PartName = "Tai",
                    RefCode = "004",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 5,
                    PartName = "Cổ",
                    RefCode = "005",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 6,
                    PartName = "Sườn vai",
                    RefCode = "006",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 7,
                    PartName = "Thịt vai",
                    RefCode = "007",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 8,
                    PartName = "Bắp giò",
                    RefCode = "008",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 9,
                    PartName = "Dựng/Móng giò",
                    RefCode = "009",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 10,
                    PartName = "Mỡ lưng",
                    RefCode = "010",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 11,
                    PartName = "Cốt lết",
                    RefCode = "011",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 12,
                    PartName = "Thăn",
                    RefCode = "012",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 13,
                    PartName = "Sườn",
                    RefCode = "013",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 14,
                    PartName = "Ba rọi",
                    RefCode = "014",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 15,
                    PartName = "Thịt mông",
                    RefCode = "015",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 16,
                    PartName = "Thịt đùi",
                    RefCode = "016",
                },
                new AnimalPartRefCode()
                {
                    AnimalPartId = 17,
                    PartName = "Đuôi",
                    RefCode = "017",
                },
            };

            return animalPartRefCodes;
        }
    }
}
