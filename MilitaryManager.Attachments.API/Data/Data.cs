using System.Collections.Generic;

namespace MilitaryManager.Attachments.API.Data
{
    public static class Data
    {
        public static List<Soldier> Soldiers { get; set; } = new List<Soldier>()
        {
            new Soldier()
            {
                Id = 1,
                Name = "Ivan 1",
                LastName = "Ivanov 1"
            },
            new Soldier()
            {
                Id = 2,
                Name = "Ivan 2",
                LastName = "Ivanov 2"
            },
            new Soldier()
            {
                Id = 3,
                Name = "Ivan 3",
                LastName = "Ivanov 3"
            },
        };

        public static List<MilitaryUnit> Units { get; set; } = new List<MilitaryUnit>()
        {
            new MilitaryUnit()
            {
                Id = 1,
                Name = "unit1",
                Address = "Myloslavska 1"
            },
            new MilitaryUnit()
            {
                Id = 2,
                Name = "unit2",
                Address = "Myloslavska 2"
            },
        };
    }
}