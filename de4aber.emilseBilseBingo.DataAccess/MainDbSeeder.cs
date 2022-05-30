using de4aber.emilseBilseBingo.DataAcess.Entities;

namespace de4aber.emilseBilseBingo.DataAcess
{
    public class MainDbSeeder : IMainDbSeeder
    {
        private readonly MainDbContext _ctx;

        public MainDbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            AddMockData();

            _ctx.SaveChanges();
        }

        private void AddMockData()
        {
            AddPersons();
            AddTileItems();
        }

        private void AddPersons()
        {
            _ctx.Persons.Add(new PersonEntity("Emil"));
            _ctx.Persons.Add(new PersonEntity("Fortmike"));
            _ctx.Persons.Add(new PersonEntity("HovedSkov"));
            _ctx.Persons.Add(new PersonEntity("Rye/Cecilie"));
        }

        private void AddTileItems()
        {
            string[] emilConditions =
            {
                "Dyb stemme", "Pive stemme", "2 Hænder foran øjne", "1 Hånd foran øjne",
                "2 Hænder i hår", "1 Hånd i hår", "Tomat ansigt", "Siger noget dumt", "Jeg smelter",
                "Nej men prøv lige at høre", "Misser i beer pong", "Ironien faktisk er på plads",
                "Laver en reel god joke", "Lyver i Meyer", "Rammer i beer pong", "Tager et shot", "Drikker 1 øl",
                "Økosystem", "Flirter med en pige", "Snakker for at undgå stilhed", "Du nedern",
                "Du pinlig", "Det ironi", "Laver en Joke"
            };

            foreach (string condition in emilConditions) _ctx.TileItemEntities.Add(new TileItemEntity(condition, 0));
        }
    }
}