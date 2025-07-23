using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Seeding.Seeders
{
    public class SeederRunner
    {
        private readonly IEnumerable<ISeeder> _seeders;
        public SeederRunner(IEnumerable<ISeeder> seeders) => _seeders = seeders;

        public async Task RunAsync()
        {
            foreach (var seeder in _seeders)
            {
                if (await seeder.ShouldRunAsync())
                    await seeder.SeedAsync();
            }
        }
    }
}
