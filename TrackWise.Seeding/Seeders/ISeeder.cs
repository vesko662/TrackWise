using System;

namespace TrackWise.Seeding.Seeders
{
    public interface ISeeder
    {
        public Task<bool> ShouldRunAsync();
        public Task SeedAsync();
    }
}
