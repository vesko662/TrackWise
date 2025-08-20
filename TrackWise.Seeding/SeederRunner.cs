using TrackWise.Seeding.Seeders;

namespace TrackWise.Seeding
{
    public class SeederRunner
    {
        private readonly IEnumerable<ISeeder> seeders;
        public SeederRunner(IEnumerable<ISeeder> seeders) => this.seeders = seeders;

        public async Task RunAsync()
        {
            foreach (var seeder in seeders)
            {
                if (await seeder.ShouldRunAsync())
                    await seeder.SeedAsync();
            }
        }
    }
}
